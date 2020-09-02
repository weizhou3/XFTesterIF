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

namespace XFTesterIF
{
    public class TestWorker
    {
        private MessageBasedSession mbSession { get; set; }
        private string ResourceName { get; set; }
        private string HandlerAddress { get; set; }
        private string GpibCardAddress { get; set; }
        private int[] DUT_CS { get; set; }
        //public SerialPort GpibPort { get; set; }
        public TestWorker(string portNumber, string CS_MTDUT, string handlerAddress)
        {
            //GpibPort = port;
            ResourceName = "ASRL" + portNumber + "::INSTR";
            DUT_CS = new int[4] { 0, 0, 0, 0 };
            HandlerAddress = handlerAddress;
            for (int i = 0; i < 4; i++)
            {
                DUT_CS[i] = int.Parse(CS_MTDUT.Substring(i, 1));
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
                    //report.ClrReport();
                    //report.ErrMsg = "Session created..";
                    //progress.Report(report);
                    state = true;
                }
                catch (Exception exp)
                {
                    state = false;
                    report.ClrReport();
                    report.ErrMsg = exp.Message;
                    report.CriticalErr = true;
                    progress.Report(report);
                    //throw new Exception("");
                    //throw new NotImplementedException("Can not open new MB session, " + exp.Message);
                }
            }

            //initializeGpib(mbSession);
            while (state)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }

                try
                {

                    //await Task.Delay(500);
                    //1.get SOT from PLC
                    int[] SOT = await GlobalIF.plcTestingConnection.GetSOTAsync(ct, progress, mbSession);

                    //2.Send SOT to tester and wait for result
                    GpibCommDataModel TestResult = await GlobalIF.TesterIF.GetTestResultAsync(mbSession, SOT, DUT_CS, timeout, ct, progress);
                    //GpibCommDataModel TestResult = await GlobalIF.TesterIF.SimulatingGetTestResultAsync(mbSession, SOT, DUT_CS, timeout, ct, progress);

                    //3. parse test result and send to PLC
                    TestResult = parseTestResult(TestResult);
                    GlobalIF.plcTestingConnection.SendResult(TestResult);
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
            NIGpibHelper.GpibWrite(mbSession, "stat \r");
            //HandlerAddress = TBoxAddress.Text;
            NIGpibHelper.GpibWrite(mbSession, "caddr " + HandlerAddress + "\r"); //set handler address to 1 设置Handler地址
            NIGpibHelper.GpibWrite(mbSession, "rsc 0\r");//disable system controller 交出controller权力

            NIGpibHelper.GpibWrite(mbSession, "tmo 1\r");
            NIGpibHelper.GpibWrite(mbSession, "rsv \\x00\r");

            //GpibWrite("stat \r");
            //HandlerAddress = TBoxAddress.Text;
            //GpibWrite("caddr " + HandlerAddress + "\r"); //set handler address to 1 设置Handler地址

            
            //GpibWrite("rsc 0\r");//disable system controller 交出controller权力

   
            //GpibWrite("tmo 1\r");
            //GpibCommOK = GpibWrite("rsv \\x00\r");


        }
    }
}
