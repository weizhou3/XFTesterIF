using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.Visa;
using XFTesterIF;
using XFTesterIF.Models;
using System.Threading;
using System.IO.Ports;

namespace XFTesterIF.TesterIFConnection
{
    public class RS_NIGpibConnector : ITesterIFConnection
    {
        public string MappingCS_DUT { get; private set; }       
        public SerialPort GpibPort { get; private set; }
        public string ResourceName { get; private set; }
        public int CommTimeout_ms { get; private set; }

        public RS_NIGpibConnector(SerialPort serialPort, string ResourceName, string mappingCSDUT, int commTimeout_ms)
        {
            GpibPort = serialPort;
            this.ResourceName = ResourceName;
            MappingCS_DUT = mappingCSDUT;
            CommTimeout_ms = commTimeout_ms;
        }
        public RS_NIGpibConnector()
        {

        }
        public async Task<GpibCommDataModel> GetTestResultAsync(MessageBasedSession mbSession, int[] SOT, 
            int[]DUT_CS, int timeout_ms, CancellationToken ct, IProgress<ProgressReportModel> progress)
        {
            DateTimeOffset startTime = DateTimeOffset.Now;
            GpibCommDataModel retResult = new GpibCommDataModel();
            ProgressReportModel report = new ProgressReportModel();
            double totalSteps = 4;
            bool timedOut = false;
            bool canceled = false;
            string BINStr = null;

            //Task1: wait for ATN
            await Task.Run(() =>
            {
                string RStr = null;
                int bitAnd = 0;

                NIGpibHelper.GpibWrite(mbSession, "rsv \\x00\r");
                //GpibWrite("rsv \\x60\r"); //set SRQ bit 5,6
                NIGpibHelper.GpibWrite(mbSession, "wait 16\r");//wait for ATN 16

                report.ClrReport();
                report.PercentageCompleted = (int)(1 / totalSteps * 100);
                report.StageMsg = "Waiting for Tester Attention..";
                report.CS = SOT;
                progress.Report(report);

                while (RStr == null || bitAnd != 16)
                //!RStr.Contains("ATN"))
                {
                    if (ct.IsCancellationRequested || canceled)
                    {
                        canceled = true;
                        break;
                    }
                    if (DateTimeOffset.Now.Subtract(startTime).TotalMilliseconds > timeout_ms || timedOut)
                    {
                        timedOut = true;
                        break;
                    }

                    RStr = NIGpibHelper.GpibRead(mbSession);//ATN

#region
                    //debug
                    List<string> debugMsg = new List<string>();
                    debugMsg.Add("From RS mode: Waiting for ATN status..");
                    debugMsg.Add(RStr);
                    report.DebugMsg = true;
                    report.DebugMsgs.Clear();
                    report.DebugMsgs.AddRange(debugMsg);
                    progress.Report(report);
#endregion

                    RStr = RStr.Replace("\\r", "").Replace("\\n", "");
                    try { bitAnd = int.Parse(RStr) & 16; }
                    catch (Exception) { }
                }
            });
            //Task2: Send SOT and wait for LACS
            if (!timedOut && !canceled)
            {
                await Task.Run(() =>
                    {
                        string RStr = null;
                        int bitAnd = 0;
                        string SPbyte = getSpbyte(SOT);
                        NIGpibHelper.GpibWrite(mbSession, "rsv \\x" + SPbyte + "\r");
                        NIGpibHelper.GpibWrite(mbSession, "wait 4\r");

                        report.ClrReport();
                        report.PercentageCompleted = (int)(2 / totalSteps * 100);
                        report.StageMsg = "SOT sent, Waiting for Tester BIN..";
                        report.CS = SOT;
                        progress.Report(report);

                        while (RStr == null || bitAnd != 4)
                        {
                            if (ct.IsCancellationRequested || canceled)
                            {
                                canceled = true;
                                break;
                            }
                            if (DateTimeOffset.Now.Subtract(startTime).TotalMilliseconds > timeout_ms || timedOut)
                            {
                                timedOut = true;
                                break;
                            }

                            RStr = NIGpibHelper.GpibRead(mbSession);

#region
                    //debug
                            List<string> debugMsg = new List<string>();
                            debugMsg.Add("From RS mode: Waiting for LACS status..");
                            debugMsg.Add(RStr);
                            report.DebugMsg = true;
                            report.DebugMsgs.Clear();
                            report.DebugMsgs.AddRange(debugMsg);
                            progress.Report(report);
#endregion
                            RStr = RStr.Replace("\\r", "").Replace("\\n", "");
                            try { bitAnd = int.Parse(RStr) & 4; }
                            catch (Exception) { }
                        }
                    }); 
            }


            //Task3: Read BIN 
            if (!timedOut && !canceled)
            {
                await Task.Run(() =>
                {
                        string retString = null;
                        string highestDUT = getMaxDUT(SOT);
                        NIGpibHelper.GpibWrite(mbSession, "rd #50\r");//read BIN from GPIB

                        report.ClrReport();
                        report.PercentageCompleted = (int)(3 / totalSteps * 100);
                        report.StageMsg = "Receiving BIN result..";
                        progress.Report(report);

                        while (true)
                        {
                            if (ct.IsCancellationRequested || canceled)
                            {
                                canceled = true;
                                break;
                            }
                            if (DateTimeOffset.Now.Subtract(startTime).TotalMilliseconds > timeout_ms || timedOut)
                            {
                                timedOut = true;
                                break;
                            }
                            if (BINStr != null && BINStr.Contains(highestDUT))//need to check all DUTs
                            {
                                break;
                            }

                            Thread.Sleep(10);
                            retString = NIGpibHelper.GpibRead(mbSession);

#region
                    //debug
                            List<string> debugMsg = new List<string>();
                            debugMsg.Add("From RS mode: BIN result..");
                            debugMsg.Add(retString);
                            report.DebugMsg = true;
                            report.DebugMsgs.Clear();
                            report.DebugMsgs.AddRange(debugMsg);
                            progress.Report(report);
#endregion

                            if (retString != null)
                            {
                                if (retString.Contains("A BIN") || retString.Contains("B BIN")
                                || retString.Contains("C BIN") || retString.Contains("D BIN"))
                                {
                                    BINStr += retString;
                                    if (!BINStr.Contains(highestDUT))//TODO -- may need to check all active DUT
                                    {
                                        NIGpibHelper.GpibWrite(mbSession, "rd #50\r");
                                    }
                                }
                            }
                        }
                }); 
            }

            //Send result to PLC
            if (timedOut)
            {
                throw new TimeoutException("EOT has timed out");
            }
            else if (canceled)
            {
                //mbSession.Dispose();
                report.StageMsg = "Testing operation has been canceled";
                progress.Report(report);
                ct.ThrowIfCancellationRequested();
                return null;
            }
            else
            {
                retResult = RSGpibProcessor.GpibDecipher(BINStr);
                BINStr = null;

                report.ClrReport();
                report.PercentageCompleted = (int)(4 / totalSteps * 100);
                report.StageMsg = "BIN result obtained, Test cycle finished..";
                report.CS = SOT;
                report.BIN = retResult.BIN;
                progress.Report(report);

                //mbSession.Dispose();
                return retResult;
            }
        }

        private string getSpbyte(int[] SOT)
        {
            string spbyte;
            int[] Spbyte = new int[8];
            Spbyte[1] = 1;
            Spbyte[0] = 0;
            for (int i = 0; i < 4; i++)//set SOT CS1-CS4 @ bit0..3
            {
                Spbyte[7 - i] = SOT[i];
            }

            string[] array1 = Array.ConvertAll(Spbyte, element => element.ToString());
            spbyte = string.Join("", array1);
            spbyte = DataManipulateHelper.HexConvert2(spbyte);
            return spbyte;
        }

        

        private string getMaxDUT(int[] SOT)
        {
            string S = "";
            int MaxValue = 0;
            for (int i = 0; i < 4; i++)
            {
                if (SOT[i]==1)
                {
                    MaxValue = i+1;
                }
            }

            switch (MaxValue)
            {
                case 1:
                    S = "A BIN";
                    break;
                case 2:
                    S = "B BIN";
                    break;
                case 3:
                    S = "C BIN";
                    break;
                case 4:
                    S = "D BIN";
                    break;                
            }
            return S;
        }
        public void SetDUTMapping(string mapping)
        {
            throw new NotImplementedException();
        }

        public void SetPort(SerialPort port)
        {
            throw new NotImplementedException();
        }

        public void SetResourceName(string resourceName)
        {
            throw new NotImplementedException();
        }

        public Task<GpibCommDataModel> SimulatingGetTestResultAsync(MessageBasedSession mbSession, int[] SOT, int[]DUT_CS, int timeout_ms, CancellationToken ct, IProgress<ProgressReportModel> progress)
        {
            throw new NotImplementedException();
        }

        public bool WakeUpPort(MessageBasedSession mbSession)
        {
            bool succ = NIGpibHelper.GpibWrite(mbSession, "rsc 0\r");
            if (!succ)
            {
                return false;
            }
            else
                return true;
        }
    }
}
