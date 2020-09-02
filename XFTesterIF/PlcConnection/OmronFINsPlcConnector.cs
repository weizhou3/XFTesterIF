using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using XFOPI_Library.Models;
using System.Threading;
using System.Diagnostics;

namespace XFOPI_Library.PLCConnection
{
    //This is the event publisher. UI update service is the Event Subscriber
    public class OmronFINsPlcConnector
    {
        public SerialPort mainPort { get; set; }


        public OmronFINsPlcConnector(SerialPort mainPort)
        {
            this.mainPort = mainPort;
            if (!mainPort.IsOpen)
            {
                try
                {
                    mainPort.Open();
                }
                catch (Exception)
                {   
                }
                
            }   
        }

        //1- Define the Event Handler (delegate)
        //public delegate void PlcReadingCompletedEventHandler(object source, EventArgs args);

        //2- Define an event based on the Event Handler
        //public event PlcReadingCompletedEventHandler PlcReadingCompleted;

        //Do steps 1,2 in one line
        public event EventHandler<PlcFinishReadEventArgs> PlcReadingCompleted;
        //public event EventHandler<PlcFinishReadEventArgs> PlcReadingProgressChanged;
        public event EventHandler<PlcFinishWriteEventArgs> PlcWritingCompleted;
        //public event EventHandler<PlcFinishReadEventArgs> PlcWritingProgressChanged;

        //3- Raise the Event
        //protected virtual void OnPlcReadingCompleted(List<PlcWordModel> receivedData)
        //{
        //    //if (PlcReadingCompleted!=null)
        //    //{
        //    //    PlcReadingCompleted(this, new PlcDataEventArgs() { PlcData= receivedData});
        //    //}
        //    PlcReadingCompleted?.Invoke(this, new PlcDataEventArgs() { BitsSent = WrtBitList,
        //                WordsSent = WrtWordList, ExpMsgBit = expMsgBit, ExpMsgWord = expMsgWord });
        //}
        //protected virtual void OnPlcReadingProgressChanged(int currentValue)
        //{
        //    PlcReadingProgressChanged?.Invoke(this, new PlcDataEventArgs() { CurrentValue = currentValue });
        //}


        //The actual method to read PLC
        //public void ReadPlc_AllData(SerialPort port)
        //{
        //    List<PlcWordModel> receivedData = new List<PlcWordModel>();
        //    //read all words from PLC as string
        //    //put string into words
        //    //return list words
        //    OnPlcReadingCompleted(receivedData);
        //}

        /// <summary>
        /// Read all data in the PLC W,H,D area, then Write the UI data to PLC every t_interval ms 
        /// </summary>
        /// <param name="t_interval">time between each read</param>
        /// <param name="cancellationToken">Cancel operation token</param>
        /// <returns>Async Task</returns>
        public async Task PlcDataExchangeAllAsync(int t_interval, CancellationToken cancellationToken)
        {
            while (true)
            {
                await Task.Run(() =>
                {
                    //1.Read all from PLC to Words
                    //List<PlcWordModel> retDataW = new List<PlcWordModel>();
                    Stopwatch stopwatch1 = new Stopwatch();
                    Stopwatch stopwatch2 = new Stopwatch();
                    stopwatch1.Start();
                    OmronFINsProcessor.ReadAllWords(mainPort, out long t_ReadAll);//>1s


                    //stopwatch1.Start();
                    //OmronFINsProcessor.WordsToBits(PlcMemArea.WR);//>2s
                    //stopwatch1.Stop();
                    //OmronFINsProcessor.WordsToBits(PlcMemArea.HR);

                    //OmronFINsProcessor.ReadAllDMWords(mainPort);

                    //stopwatch1.Start();
                    //OmronFINsProcessor.ReadAllBits(mainPort);
                    //stopwatch1.Stop();
                    //2.Transfer value from Words/bits to DataNames
                    
                    PlcDataMapper.DMWordsToData();//4ms
                    
                    PlcDataMapper.BitsToData();//14ms
                    
                    //3. Transfer from DataNames to RWlist then Raise EventArgs and let UI to retrieve the data
                    //UI will subscribe to this event and retrieve data from RWlist
                    
                    lock (PlcDataMapper._RWlistLock)
                    {
                        PlcDataMapper.DataToRList();
                    }
                    stopwatch1.Stop();

                    PlcReadingCompleted.Raise(this, new PlcFinishReadEventArgs(){ ticks=stopwatch1.ElapsedTicks, _ms=stopwatch1.ElapsedMilliseconds } );

                    //SimulateWlist();//Simulate the test data

                    
                    //new 4. generate the write words and bits lists based on Wlist only 
                    List<PlcWordModel> WrtWordList = new List<PlcWordModel>();
                    List<PlcBitModel> WrtBitList = new List<PlcBitModel>();

                    if (PlcDataMapper.DataNameValue_Wlist.Count>0)
                    {
                        lock (PlcDataMapper._WlistLock)
                        {
                            WrtWordList = PlcDataMapper.WListGenerateWordList(WrtWordList);
                            WrtBitList = PlcDataMapper.WListGenerateBitList(WrtBitList);
                            //PlcDataMapper.WListToData();
                            PlcDataMapper.DataNameValue_Wlist.Clear();
                        }
                        stopwatch2.Start();
                        //new 5. write the data individually to PLC then raise complete event
                        bool BitsWrtSuccessed = OmronFINsProcessor.WriteBits(mainPort, WrtBitList, out string expMsgBit);
                        bool WordsWrtSuccessed = OmronFINsProcessor.WriteWords(mainPort, WrtWordList, out string expMsgWord);
                        //6.Write the data to PLC then Raise the written event
                        //OmronFINsProcessor.WriteAllWords(mainPort);
                        stopwatch2.Stop();
                        PlcWritingCompleted.Raise(this, new PlcFinishWriteEventArgs()
                        {
                            _ms = stopwatch2.ElapsedMilliseconds,
                            BitsSent = WrtBitList,
                            WordsSent = WrtWordList,
                            ExpMsgBit = expMsgBit,
                            ExpMsgWord = expMsgWord
                        });
                    }
                    
                    
                });
                Thread.Sleep(t_interval);
                if (cancellationToken.IsCancellationRequested)
                    break;
            }

        }

        private void SimulateWlist()
        {
            int i = 0;
            foreach (var typeBool in PlcDataMapper.TypeBools)
            {
                PlcDataMapper.DataNameValue_Wlist.Add(typeBool.Name, "1");
            }
            foreach (var typeUshort in PlcDataMapper.TypeUshorts)
            {
                PlcDataMapper.DataNameValue_Wlist.Add(typeUshort.Name, i.ToString());
                i++;
            }
            foreach (var typeUint in PlcDataMapper.TypeUints)
            {
                PlcDataMapper.DataNameValue_Wlist.Add(typeUint.Name, i.ToString());
                i++;
            }
        }

        

       






    }
}
