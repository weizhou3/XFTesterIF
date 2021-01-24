using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XFTesterIF.Models;
using NationalInstruments.Visa;
using System.IO.Ports;
using XFTesterIF.TesterIFConnection;
using System.IO;

namespace XFTesterIF
{
    public class TestWorker
    {
        private MessageBasedSession mbSession { get; set; }
        private string ResourceName { get; set; }
        private string HandlerAddress { get; set; }
        private string GpibCardAddress { get; set; }
        private int[] DUT_CS { get; set; }
        private bool resultValid { get; set; }

        //public SerialPort GpibPort { get; set; }
        public TestWorker(string portNumber, string CS_DUT, string handlerAddress)
        {
            //GpibPort = port;
            ResourceName = "ASRL" + portNumber + "::INSTR";
            DUT_CS = new int[4] { 0, 0, 0, 0 };
            HandlerAddress = handlerAddress;
            for (int i = 0; i < 4; i++)
            {
                DUT_CS[i] = int.Parse(CS_DUT.Substring(i, 1));
            }
        }
        public async void RunTest(int timeout, CancellationToken ct, IProgress<ProgressReportModel> progress)
        {
            ProgressReportModel report = new ProgressReportModel();
            bool state = false;
            
            using (var rmSession = new ResourceManager())
            {
                try
                {
                    mbSession = (MessageBasedSession)rmSession.Open(ResourceName);
                    initializeGpib(mbSession);
                    state = true;
                }
                catch (Exception exp)
                {
                    state = false;
                    report.ClrReport();
                    report.ErrMsg = exp.Message;
                    report.CriticalErr = true;
                    progress.Report(report);

                }
            }

            while (state)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }
                try
                {
                    int[] SOT = { 0, 0, 0, 0 };
                    await Task.Delay(200);
                    if (GlobalIF.DebugMode)
                    {
                        SOT = GlobalIF.DebugSOT;
                    }
                    else
                    {
                        SOT = await GlobalIF.plcTestingConnection.GetSOTAsync(ct, progress, mbSession);
                    }
                    //1.get SOT from PLC
                    //int[] SOT = await GlobalIF.plcTestingConnection.GetSOTAsync(ct, progress, mbSession); 
                    //int[] SOT = { 1, 1, 0, 1 };//TODO --  comment for production

                    if (SOT != null && SOT.Any(v => v == 1))
                    {
                        //2.Send SOT to tester and wait for result
                        GpibCommDataModel TestResult = await GlobalIF.TesterIF.GetTestResultAsync(mbSession, SOT, DUT_CS, timeout, ct, progress);
                        //GpibCommDataModel TestResult = await GlobalIF.TesterIF.SimulatingGetTestResultAsync(mbSession, SOT, DUT_CS, timeout, ct, progress);

#region
                        //debug session
                        List<string> debugMsgs = debugOutput(TestResult);
                        report.ClrReport();
                        report.DebugMsgs = debugMsgs;
                        report.DebugMsg = true;
                        progress.Report(report);

                        //debug session end
#endregion

                        //3. verify result --TODO: add result verification
                        resultValid = verifyResult(TestResult);

                        if (resultValid)
                        {
                            //4. Parse test result and send result to PLC
                            TestResult = parseTestResult(TestResult);
#region
                            List<string> debugMsg = new List<string>();
                            debugMsg.Add("From test worker: TestResult..");
                            debugMsg.AddRange(TestResult.RxBIN);
                            report.DebugMsg = true;
                            report.DebugMsgs.Clear();
                            report.DebugMsgs.AddRange(debugMsg);
                            progress.Report(report);
#endregion
                            GlobalIF.plcTestingConnection.SendResult(TestResult);
                        }
                        else
                        {
                            report.ClrReport();
                            report.ErrMsg = "Invalid BIN data, please verify tester driver settings and restart GPIB";
                            report.CriticalErr = true;
                            progress.Report(report);
                            break;
                        }
                    }                   

                }
                catch (NotImplementedException exp)
                {
                    if (state)
                    {
                        mbSession.Dispose();
                    }
                    report.ClrReport();                    
                    report.ErrMsg = exp.Message;
                    report.CriticalErr = true;
                    progress.Report(report);
                    break;
                }
                catch(TimeoutException exp)
                {
                    report.ClrReport();
                    report.ErrMsg = exp.Message;
                    progress.Report(report);
                }
                catch (Exception exp)
                {
                    //report.ErrMsg = exp.Message;
                    report.ClrReport();
                    report.PercentageCompleted = 0;
                    progress.Report(report);
                    //break;
                }

            }
            if (state)
            {
                mbSession.Dispose();
            }
            //else
            //{
            //    throw new NotImplementedException("");
            //}
            
        }

        private GpibCommDataModel parseTestResult(GpibCommDataModel testResult)
        {
            GpibCommDataModel retResult = new GpibCommDataModel();

            for (int i = 0; i < 4; i++)
            {
                if (testResult.BIN[i]>0)
                {
                    if (testResult.BIN[i] == 31)
                    {
                        testResult.BIN[i] = 16;
                    }
                    retResult.RxBIN[i] = DataManipulateHelper.HexConvert10(Math.Pow(2, testResult.BIN[i] - 1).ToString()).PadLeft(4, '0');  
                }
            }
            return retResult;

            //PLCWB.BIN[i] = HexConvert10(Math.Pow(2, CoRB.BIN[i] - 1).ToString()).PadLeft(4, '0');
        }

        private void initializeGpib(MessageBasedSession mbSession)
        {
            //NIGpibHelper.GpibWrite(mbSession, "stat s\r");

            //NIGpibHelper.GpibWrite(mbSession, "caddr\r");
            //string stats = NIGpibHelper.GpibRead(mbSession);

            //HandlerAddress = TBoxAddress.Text;
            NIGpibHelper.GpibWrite(mbSession, "caddr " + HandlerAddress + "\r"); //set handler address to 1 设置Handler地址
            NIGpibHelper.GpibWrite(mbSession, "rsc 0\r");//disable system controller 交出controller权力

            NIGpibHelper.GpibWrite(mbSession, "tmo 1\r");
            NIGpibHelper.GpibWrite(mbSession, "rsv \\x00\r");

            //NIGpibHelper.GpibWrite(mbSession, "caddr 3\r");
            //NIGpibHelper.GpibWrite(mbSession, "caddr\r");
            //for (int i = 0; i < 10; i++)
            //{
            //    string stats = NIGpibHelper.GpibRead(mbSession);
            //}
            
        }

        private bool verifyResult(GpibCommDataModel result)
        {
            return true;
        }

        private List<string> debugOutput (GpibCommDataModel result)
        {
            List<string> lines = new List<string>();
            lines.Add("BIN: " + string.Join(" ", result.BIN));
            lines.Add("cmdType: " + result.cmdType);
            lines.Add("EOT: " + string.Join(" ", result.EOT));
            lines.Add("RxStr: " + result.RxStr);
            lines.Add("RxBIN:");
            lines.AddRange(result.RxBIN);
            return lines;
        }
    }
}
