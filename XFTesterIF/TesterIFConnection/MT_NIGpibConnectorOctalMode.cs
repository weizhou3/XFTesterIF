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
using XFTesterIF.TesterIFConnection;

namespace XFTesterIF.TesterIFConnection
{
    public class MT_NIGpibConnectorOctalMode : ITesterIFConnection
    {
        //CancellationTokenSource cts = new CancellationTokenSource();
        //public event Action<Progress<ProgressReportModel>> ProgressChanged;
        //public event Action<ProgressReportModel> ProgressChanged;
        //public Progress<ProgressReportModel> progress { get; set; } = new Progress<ProgressReportModel>();
        // = new Progress<ProgressReportModel>();
        public string MappingCS_DUT { get; private set; }
        //private MessageBasedSession mbSession { get; set; }
        public SerialPort GpibPort { get; private set; }
        public string ResourceName { get; private set; }
        public int CommTimeout_ms { get; private set; }

        public MT_NIGpibConnectorOctalMode(SerialPort serialPort, string ResourceName, string mappingCSDUT, int commTimeout_ms)
        {
            //Initialize mbSession for NI GPIB
            GpibPort = serialPort;
            this.ResourceName = ResourceName;
            MappingCS_DUT = mappingCSDUT;
            CommTimeout_ms = commTimeout_ms;
        }
        public MT_NIGpibConnectorOctalMode()
        {

        }
        
        /// <summary>
        /// Get the Test Result from Tester
        /// </summary>
        /// <param name="SOT">SOT array</param>
        /// <param name="timeout_ms">EOT time out</param>
        /// <param name="ct">Cancellation Token</param>
        /// <param name="progress">Progress Report</param>
        /// <returns>Test Result in Commd Data Model</returns>
        public async Task<GpibCommDataModel> GetTestResultAsync(MessageBasedSession mbSession, int[]SOT, 
            int[]DUT_CS, int timeout_ms, CancellationToken ct, IProgress<ProgressReportModel> progress)
        {
            DateTimeOffset startTime = DateTimeOffset.Now;
            GpibCommDataModel retResult = new GpibCommDataModel();
            ProgressReportModel report = new ProgressReportModel();
            double totalSteps = 6;
            bool timedOut = false;
            bool canceled = false;
            string BINStr = null;

            //ATN check
            //Issue SRQ then wait LACS
            //Wait "SITES?"
            //Wait TACS then send SOT
            //Wait LACS then initiate read
            //Read and parse BIN

            //Task0. Wait ATN then issue SRQ
            await Task.Run(() =>
            {
                string retString=null;                

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
                    if (retString != null && retString.Contains("Ivi.Visa.IOTimeoutException"))
                    {
                        NIGpibHelper.GpibWrite(mbSession, "stat n\r");
                    }

#region debug

                    List<string> debugMsg = new List<string>();
                    debugMsg.Add("From MT Octal Mode: 0/6 Waiting ATN..");
                    debugMsg.Add(retString);
                    report.DebugMsg = true;
                    report.DebugMsgs.Clear();
                    report.DebugMsgs.AddRange(debugMsg);
                    progress.Report(report);
                    //BINStr = "A BIN 2 F BIN 7 E BIN 1";//TODO -- commment for production
#endregion

                    retString = NIGpibHelper.GpibRead(mbSession);
                    if (NIGpibHelper.CheckGpibStats(4, retString))//4
                    {
                        NIGpibHelper.GpibWrite(mbSession, "rsv \\x00\r"); //reset spbyte
                        NIGpibHelper.GpibWrite(mbSession, "rsv \\x60\r"); //spbyte: 0110 0000
                        break;
                    }
                    //retString = NIGpibHelper.GpibRead(mbSession);
                    //retString = retString.Replace("\\r", "").Replace("\\n", "");
                    //int.TryParse(retString, out int stats);
                    //int bitAnd = stats & (1 << 4);
                    //if (bitAnd == 1 << 4)
                    //{
                    //    break;
                    //}                    
                }
            });

            
            //Task1. Wait LACS and issue read SITES?
            if (!timedOut && !canceled)
            {
                await Task.Run(() =>
                {
                    report.ClrReport();
                    report.PercentageCompleted = (int)(1 / totalSteps * 100);
                    report.StageMsg = "DUT ready, Waiting for Tester to issue SITE request..";
                    report.CS = SOT;
                    progress.Report(report);

                    string retString = null;
                    
                    //NIGpibHelper.GpibWrite(mbSession, "rd #30\r");//TODO-- during debugging need to verify is sending RD request once is enough

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
                        if (retString != null && retString.Contains("Ivi.Visa.IOTimeoutException"))
                        {
                            NIGpibHelper.GpibWrite(mbSession, "stat n\r");
                        }
                        retString = NIGpibHelper.GpibRead(mbSession);

                        #region debug

                        List<string> debugMsg = new List<string>();
                        debugMsg.Add("From MT Octal Mode: 1/6 Waiting LACS for SITES?..");
                        debugMsg.Add(retString);
                        report.DebugMsg = true;
                        report.DebugMsgs.Clear();
                        report.DebugMsgs.AddRange(debugMsg);
                        progress.Report(report);
                        //BINStr = "A BIN 2 F BIN 7 E BIN 1";//TODO -- commment for production
                        #endregion

                        if (NIGpibHelper.CheckGpibStats(2, retString))//2
                        {
                            NIGpibHelper.GpibWrite(mbSession, "rd #30\r"); //read for SITES?
                            break;
                        }
                        //retString = NIGpibHelper.GpibRead(mbSession);
                        //retString = retString.Replace("\\r", "").Replace("\\n", "");
                        //int.TryParse(retString, out int stats);
                        //int bitAnd = stats & (1 << 2);
                        //if (bitAnd == 1 << 2)
                        //{
                        //    break;
                        //}                        
                    }
                }); 
            }

            //Task2. read SITES?
            if (!timedOut && !canceled)
            {
                await Task.Run(() =>
                {
                    //TODO -- find out why clear report clears the SOT too
                    //report.ClrReport();
                    report.PercentageCompleted = (int)(2 / totalSteps * 100);
                    report.StageMsg = "DUT ready, Waiting for Tester to issue SITE request..";
                    report.CS = SOT;
                    progress.Report(report);

                    string retString = "";

                    while (true)
                    {                        
                        retString = NIGpibHelper.GpibRead(mbSession);

                        #region
                        //debug
                        List<string> debugMsg = new List<string>();
                        debugMsg.Add("From MT Octal Mode: 2/6 Waiting for Tester SITES?..");
                        debugMsg.Add(retString);
                        report.DebugMsg = true;
                        report.DebugMsgs.Clear();
                        report.DebugMsgs.AddRange(debugMsg);
                        progress.Report(report);
                        #endregion

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
                        //retString = "SITES?"; //TODO-- commment for production
                        if (retString != null && retString.Contains("SITES?"))
                        {
                            break;
                        }
                        Thread.Sleep(10);
                        //await Task.Delay(10);
                    }
                });
            }

            //Task3. Wait TACS then send SOT
            if (!timedOut && !canceled)
            {
                await Task.Run(() =>
                {
                    //report.ClrReport();
                    report.PercentageCompleted = (int)(3 / totalSteps * 100);
                    report.StageMsg = "DUT ready, Waiting for Tester to issue SITE request..";
                    report.CS = SOT;
                    progress.Report(report);

                    string retString = null;
                    List<string> activeDUTs = MTGpibProcessor.GetActiveDUT(SOT, DUT_CS);
                    string SOTStr = MTGpibProcessor.GetSOTStr(SOT, DUT_CS);
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
                        if (retString != null && retString.Contains("Ivi.Visa.IOTimeoutException"))
                        {
                            NIGpibHelper.GpibWrite(mbSession, "stat n\r");
                        }

                        retString = NIGpibHelper.GpibRead(mbSession);

                        #region debug

                        List<string> debugMsg = new List<string>();
                        debugMsg.Add("From MT Octal Mode: 3/6 Waiting for TACS to send SOT.." + "SOT str = " + SOTStr);
                        debugMsg.Add(retString);
                        report.DebugMsg = true;
                        report.DebugMsgs.Clear();
                        report.DebugMsgs.AddRange(debugMsg);
                        progress.Report(report);
                        //BINStr = "A BIN 2 F BIN 7 E BIN 1";//TODO -- commment for production
                        #endregion

                        if (NIGpibHelper.CheckGpibStats(3,retString))//3
                        {   
                            NIGpibHelper.GpibWrite(mbSession, "wrt\n" + SOTStr + "\r");//send SOT str to tester
                            break;
                        }
                        //retString = retString.Replace("\\r", "").Replace("\\n", "");
                        //int.TryParse(retString, out int stats);
                        //int bitAnd = stats & (1 << 3);
                        //if (bitAnd == 1 << 3)
                        //{
                        //    break;
                        //}
                    }
                });
            }

            //Task4. wait LACS and initiate read BIN
            if (!timedOut && !canceled)
            {
                await Task.Run(() =>
                {
                    //report.ClrReport();
                    report.PercentageCompleted = (int)(4 / totalSteps * 100);
                    report.StageMsg = "BIN ready, reading from tester..";
                    report.CS = SOT;
                    progress.Report(report);

                    string retString = null;

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
                        if (retString != null && retString.Contains("Ivi.Visa.IOTimeoutException"))
                        {
                            NIGpibHelper.GpibWrite(mbSession, "stat n\r");
                        }

                        retString = NIGpibHelper.GpibRead(mbSession);
                        
                        #region debug

                        List<string> debugMsg = new List<string>();
                        debugMsg.Add("From MT Octal Mode: 4/6 waiting LACS to receive BIN..");
                        debugMsg.Add(retString);
                        report.DebugMsg = true;
                        report.DebugMsgs.Clear();
                        report.DebugMsgs.AddRange(debugMsg);
                        progress.Report(report);
                        //BINStr = "A BIN 2 F BIN 7 E BIN 1";//TODO -- commment for production
                        #endregion

                        if (NIGpibHelper.CheckGpibStats(2, retString))//2
                        {
                            NIGpibHelper.GpibWrite(mbSession, "rd #50\r");//initiate read from tester
                            break;
                        }
                    }
                });
            }

            //Task5. Read BIN
            if (!timedOut && !canceled)
            {
                await Task.Run(() =>
                {
                    //report.ClrReport();
                    report.PercentageCompleted = (int)(5 / totalSteps * 100);
                    report.StageMsg = "BIN ready, reading from tester..";
                    report.CS = SOT;
                    progress.Report(report);

                    string retString = null;

                    List<string> activeDUTs = MTGpibProcessor.GetActiveDUT(SOT, DUT_CS);

                    //string highestDUT = getMaxDUT(SOT, DUT_CS);
                    //List<string> activeDUTs = MTGpibProcessor.GetActiveDUT(SOT, DUT_CS);
                    //string SOTStr = MTGpibProcessor.GetSOTStr(SOT, DUT_CS);
                    //NIGpibHelper.GpibWrite(mbSession, "wrt\n" + SOTStr + "\r");//send SOT str to tester
                    Thread.Sleep(10);
                    //NIGpibHelper.GpibWrite(mbSession, "rd #50\r"); --2019.5.23

                    while (true)//implementing original gpibstage 14
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
                        if (BINStr != null && MTGpibProcessor.CheckBinComplete(activeDUTs, BINStr))
                        {
                            break;
                        }
                        //retString = NIGpibHelper.GpibRead(mbSession);--2019.5.23
                        //if (retString!=null)--2019.5.23
                        else if (BINStr == null || !MTGpibProcessor.CheckBinComplete(activeDUTs, BINStr))
                        {
                            //NIGpibHelper.GpibWrite(mbSession, "rd #50\r");
                            //Thread.Sleep(30);
                            retString = NIGpibHelper.GpibRead(mbSession);

    #region debug

                            List<string> debugMsg = new List<string>();
                            debugMsg.Add("From MT Octal Mode: 5/6 Received BIN str.." + "SOT = " + string.Join("", SOT));
                            debugMsg.Add(retString);
                            report.DebugMsg = true;
                            report.DebugMsgs.Clear();
                            report.DebugMsgs.AddRange(debugMsg);
                            progress.Report(report);
                            //BINStr = "A BIN 2 F BIN 7 E BIN 1";//TODO -- commment for production
    #endregion
                            if (retString.Contains("A BIN") || retString.Contains("B BIN") || retString.Contains("C BIN") || retString.Contains("D BIN")
                                || retString.Contains("E BIN") || retString.Contains("F BIN") || retString.Contains("G BIN") || retString.Contains("H BIN"))
                            {
                                BINStr += retString;
                                //if (!BINStr.Contains(highestDUT))
                                //{
                                //    NIGpibHelper.GpibWrite(mbSession, "rd #50\r");
                                //}--2019.5.23
                            }
                            else if (retString != null && retString.Contains("Ivi.Visa.IOTimeoutException"))
                            {
                                NIGpibHelper.GpibWrite(mbSession, "rd #50\r");
                            }
                        }
                    }
                }); 
            }

            //Task6. Parse the string then return CommData
            if (timedOut)
            {
                //mbSession.Dispose();
                //report.ClrReport();
                //report.ErrMsg = "EOT has timed out";
                //progress.Report(report);
                throw new TimeoutException("EOT has timed out");
            }
            else if (canceled)
            {
                //mbSession.Dispose();
                report.ErrMsg = "Testing operation has been canceled";
                progress.Report(report);
                ct.ThrowIfCancellationRequested();
                return null;
            }
            else
            {   
                retResult = MTGpibProcessor.GpibDecipher(BINStr, DUT_CS);

#region
                //debug
                List<string> debugMsg = new List<string>();
                debugMsg.Add("From MT Octal Mode 6/6 1/2: BINStr..");
                debugMsg.Add(BINStr);
                debugMsg.Add("From MT Octal Mode 6/6 2/2: Parsed BIN result..");
                debugMsg.AddRange(retResult.RxBIN);
                report.DebugMsg = true;
                report.DebugMsgs.Clear();
                report.DebugMsgs.AddRange(debugMsg);
                progress.Report(report);
#endregion

                BINStr = null;

                //report.ClrReport();
                report.PercentageCompleted = (int)(6 / totalSteps * 100);
                report.StageMsg = "BIN result obtained, Test cycle finished..";
                report.CS = SOT;
                report.BIN = retResult.BIN;
                progress.Report(report);

                //mbSession.Dispose();
                return retResult;
            }
        }

        /// <summary>
        /// The original version of While loop reading bin 
        /// </summary>
        /// <param name="SOT">SOT array</param>
        /// <param name="timeout_ms">EOT time out</param>
        /// <param name="ct">Cancellation Token</param>
        /// <param name="progress">Progress Report</param>
        /// <returns>Test Result in Comm data model</returns>
        public async Task<GpibCommDataModel> GetTestResultAsync_CompleteVer(MessageBasedSession mbSession, int[] SOT, int[]DUT_CS, int timeout_ms, CancellationToken ct, IProgress<ProgressReportModel> progress)
        {
            //using (var rmSession = new ResourceManager())
            //{
            //    try
            //    {
            //        mbSession = (MessageBasedSession)rmSession.Open(ResourceName);
            //    }
            //    catch (Exception exp)
            //    {
            //        throw new NotImplementedException("Can not open new MB session, " + exp.Message);
            //    }
            //}

            DateTimeOffset startTime = DateTimeOffset.Now;
            GpibCommDataModel retResult = new GpibCommDataModel();
            ProgressReportModel report = new ProgressReportModel();
            bool timedOut = false;
            bool canceled = false;
            string BINStr = null;
            int totalSteps = 6;

            //Task1: Wait for ATN
            await Task.Run(() =>
            {
                string RStr = null;
                int bitAnd = 0;

                NIGpibHelper.GpibWrite(mbSession, "rsv \\x00\r");
                //GpibWrite("rsv \\x60\r"); //set SRQ bit 5,6
                NIGpibHelper.GpibWrite(mbSession, "wait 16\r");//wait for ATN 16

                report.ClrReport();
                report.PercentageCompleted = 1 / totalSteps * 100;
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
                    RStr = RStr.Replace("\\r", "").Replace("\\n", "");
                    try { bitAnd = int.Parse(RStr) & 16; }
                    catch (Exception) { }
                }
            });

            //Task2. Send DUT ready and wait to be addressed as listener
            await Task.Run(() => 
            {
                string RStr = null;
                int bitAnd = 0;

                NIGpibHelper.GpibWrite(mbSession, "rsv \\x60\r");//set SRQ bit 5,6
                NIGpibHelper.GpibWrite(mbSession, "wait \\x4\r");//wait for addressed as listener

                report.PercentageCompleted = 2 / totalSteps * 100;
                report.StageMsg = "DUT ready, Waiting for Tester Communucation Request..";
                report.CS = SOT;
                progress.Report(report);

                while (RStr == null || bitAnd != 4)
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
                    RStr = RStr.Replace("\\r", "").Replace("\\n", "");
                    try { bitAnd = int.Parse(RStr) & 4; }
                    catch (Exception) { }
                }
            });

            //Task3: Wait for SITES?
            await Task.Run(() =>
            {
                string RStr = null;

                NIGpibHelper.GpibWrite(mbSession, "rd #30\r");

                report.PercentageCompleted = 3 / totalSteps * 100;
                report.StageMsg = "DUT ready, Waiting for Tester to issue SITE request..";
                report.CS = SOT;
                progress.Report(report);

                while (RStr == null || !RStr.Contains("SITES?"))//wait SITES?
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
                    RStr = NIGpibHelper.GpibRead(mbSession);//SITES?
                }
            });

            
            //Task4: Send SOT string and wait for to be addressed as lisenter
            await Task.Run(() =>
            {
                string RStr = null;
                int bitAnd = 0;
                string SOTStr = MTGpibProcessor.GetSOTStr(SOT,DUT_CS);
                NIGpibHelper.GpibWrite(mbSession, "wrt\n" + SOTStr + "\r");//send SOT str to tester
                NIGpibHelper.GpibWrite(mbSession, "wait 4\r");//req LACS

                report.PercentageCompleted = 4 / totalSteps * 100;
                report.StageMsg = "SOT sent to Tester, Testing in progress..";
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

                    RStr = NIGpibHelper.GpibRead(mbSession);//LACS
                    RStr = RStr.Replace("\\r", "").Replace("\\n", "");
                    try { bitAnd = int.Parse(RStr) & 4; }
                    catch (Exception) { }
                }
            });

            //Task5: Wait for valid BIN string, 
            await Task.Run(() =>
            {
                string retString = null;
                string highestDUT = getMaxDUT(SOT, DUT_CS);
                NIGpibHelper.GpibWrite(mbSession, "rd #50\r");//read BIN from GPIB

                report.PercentageCompleted = 5 / totalSteps * 100;
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
                    if (BINStr != null && BINStr.Contains(highestDUT))
                    {
                        break;
                    }

                    Thread.Sleep(10);
                    retString = NIGpibHelper.GpibRead(mbSession);
                    if (retString != null)
                    {
                        if (retString.Contains("A BIN") || retString.Contains("B BIN") || retString.Contains("C BIN") || retString.Contains("D BIN")
                         || retString.Contains("E BIN") || retString.Contains("F BIN") || retString.Contains("G BIN") || retString.Contains("H BIN"))
                        {
                            BINStr += retString;
                            if (!BINStr.Contains(highestDUT))
                            {
                                NIGpibHelper.GpibWrite(mbSession, "rd #50\r");
                            }
                        }
                    }
                }
            });

            //Parse the string then return CommData
            if (timedOut)
            {
                BINStr = null;
                throw new TimeoutException("EOT has timed out");
            }
            else if (canceled)
            {
                BINStr = null;
                ct.ThrowIfCancellationRequested();
                return null;
            }
            else
            {
                retResult = MTGpibProcessor.GpibDecipher(BINStr, DUT_CS);

                report.PercentageCompleted = 6 / totalSteps * 100;
                report.StageMsg = "BIN result obtained, Test cycle finished..";
                report.CS = SOT;
                report.BIN = retResult.BIN;
                progress.Report(report);

                BINStr = null;
                return retResult;
            }
        }

        /// <summary>
        /// Get the highest DUT string
        /// </summary>
        /// <param name="SOT">SOT array</param>
        /// <returns>Highest DUT string</returns>
        private string getMaxDUT(int[] SOT, int[] DUT_CS)
        {
            string S = "";
            int[] CS = new int[4];
            //int[] DUT_CS = new int[4];
            for (int i = 0; i < 4; i++)
            {
                //DUT_CS[i] = int.Parse(MappingCS_DUT.Substring(i, 1));
                CS[i] = DUT_CS[i] * SOT[i];
            }

            int MaxValue = CS.Max();
            //int MaxIndex = MT.DUT_CS.ToList().IndexOf(MaxValue);

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
                case 5:
                    S = "E BIN";
                    break;
                case 6:
                    S = "F BIN";
                    break;
                case 7:
                    S = "G BIN";
                    break;
                case 8:
                    S = "H BIN";
                    break;
            }
            return S;
        }
        
        /// <summary>
        /// Return the Spbyte with SRQ set to 1
        /// </summary>
        /// <param name="SOT">SOT array</param>
        /// <returns>Spbyte</returns>
        public string SetSRQ(int[]SOT)
        {
            string spbyte;
            int[] Spbyte = new int[8];
            //set SPByte per SOT
            Spbyte[1] = 1;//enable SRQ @ bit6
            Spbyte[0] = 0;
            for (int i = 0; i < 4; i++)//set SOT CS1-CS4 @ bit0..3
            {
                Spbyte[7 - i] = SOT[i];
            }
            //convert spbyte array to hex string
            string[] array1 = Array.ConvertAll(Spbyte, element => element.ToString());
            spbyte = string.Join("", array1);
            spbyte = DataManipulateHelper.HexConvert2(spbyte);
            return spbyte;

        }
               
        public void SetCommTimeout(int timeOutms)
        {
            CommTimeout_ms = timeOutms;
        }

        public void SetPort(SerialPort port)
        {
            GpibPort = port;
            //if (!GpibPort.IsOpen)
            //{
            //    GpibPort.Open();
            //}

        }
        public void SetResourceName(string resourceName)
        {
            ResourceName = resourceName;
        }
        public void SetDUTMapping(string mapping)
        {
            MappingCS_DUT = mapping;
        }


        /// <summary>
        /// Test code with NI instrument simulator
        /// </summary>
        /// <param name="SOT"></param>
        /// <param name="timeout_ms"></param>
        /// <param name="ct"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        public async Task<GpibCommDataModel> SimulatingGetTestResultAsync(MessageBasedSession mbSession, int[] SOT, int[]DUT_CS, int timeout_ms, CancellationToken ct, IProgress<ProgressReportModel> progress)
        {
            //if (!GpibPort.IsOpen)
            //{
            //    GpibPort.Open();
            //}

            //using (var rmSession = new ResourceManager())
            //{
            //    try
            //    {
            //        mbSession = (MessageBasedSession)rmSession.Open(ResourceName);
            //    }
            //    catch (Exception exp)
            //    {
            //        throw new NotImplementedException("Can not open new MB session, " + exp.Message);
            //    }
            //}

            DateTimeOffset startTime = DateTimeOffset.Now;
            GpibCommDataModel retResult = new GpibCommDataModel();
            ProgressReportModel report = new ProgressReportModel();
            int totalSteps = 3;
            bool timedOut = false;
            bool canceled = false;
            string BINStr = null;



            //Task1: Issue DUT ready and Await Tester SITES?
            await Task.Run(() =>
            {
                string retString = null;
                NIGpibHelper.GpibWrite(mbSession, "wrt 3\n" + "CONFIGURE:VOLTAGE:AC 3.3,0.0001\r"); //send config to Digital Multimeter
                

                report.PercentageCompleted = 1 / totalSteps * 100;
                report.StageMsg = "DUT ready, Waiting for Tester to issue SITE request..";
                report.CS = SOT;
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

                    retString = NIGpibHelper.GpibRead(mbSession);
                    if (retString != null)
                    {
                        report.StageMsg = retString;
                        progress.Report(report);
                        break;
                    }
                    Thread.Sleep(10);
                }
            });

            //Task2. Send SOT string and wait for valid BIN string
            await Task.Run(() =>
            {
                string retString = null;
                string highestDUT = getMaxDUT(SOT, DUT_CS);
                string SOTStr = MTGpibProcessor.GetSOTStr(SOT,DUT_CS);
                NIGpibHelper.GpibWrite(mbSession, "wrt 3\n" + "MEAS?" + "\r");//send measure request to DM
                while (true)
                {
                    NIGpibHelper.GpibWrite(mbSession, "stat n\r");
                    string tempStr = NIGpibHelper.GpibRead(mbSession);
                    if (tempStr.Contains("\\r"))
                    {
                        tempStr = tempStr.Replace("\\r", "");
                    }
                    if (tempStr.Contains("\\n"))
                    {
                        tempStr = tempStr.Replace("\\n", "");
                    }
                    if (int.TryParse(tempStr, out int stat))
                    {
                        int ATN = stat & 16;
                        if (ATN==16)
                        {
                            NIGpibHelper.GpibWrite(mbSession, "wrt 3\n" + "MEAS?" + "\r");
                            break;
                        }
                        else
                        {
                            break;
                        }
                    } 
                }
                Thread.Sleep(10);
                NIGpibHelper.GpibWrite(mbSession, "rd #50 3\r");
                report.PercentageCompleted = 2 / totalSteps * 100;
                report.StageMsg = "msg from the instrument: "+ NIGpibHelper.GpibRead(mbSession);
                report.CS = SOT;
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

                    if (BINStr != null)
                    {
                        break;
                    }

                    Thread.Sleep(10);
                    retString = NIGpibHelper.GpibRead(mbSession);
                    if (retString.Contains("\\r"))
                    {
                        retString = retString.Replace("\\r", "");
                    }
                    if (retString.Contains("\\n"))
                    {
                        retString = retString.Replace("\\n", "");
                    }
                    if (retString != null && int.TryParse(retString,out int result))
                    {
                        if (result!=0)
                        {
                            BINStr += result.ToString();
                        }
                        
                            
                    }
                }
            });

            //3. Parse the string then return CommData
            if (timedOut)
            {
                //mbSession.Dispose();
                throw new TimeoutException("EOT has timed out");
            }
            else if (canceled)
            {
                //mbSession.Dispose();
                ct.ThrowIfCancellationRequested();
                return null;
            }
            else
            {
                retResult.BIN = SOT;
                
                report.PercentageCompleted = 3 / totalSteps * 100;
                report.StageMsg = "BIN result obtained: "+BINStr;
                report.CS = SOT;
                report.BIN = retResult.BIN;
                progress.Report(report);
                BINStr = null;

                //mbSession.Dispose();
                return retResult;
            }
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
