using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XFTesterIF.Models;

namespace XFTesterIF.PLCConnection
{
    public class OmronFINsTestingConnector : IPlcTestingConnection
    {
        public SerialPort PlcPort { get; private set; }
        //public PlcTestingCommDataModel CommData { get; set; }

        public string[] PlcStageCode { get; } = new string[6] { "0000", "0001", "0007", "000F", "001F", "007F" };

        public OmronFINsTestingConnector(SerialPort port)
        {
            PlcPort = port;
            //CommData = new PlcTestingCommDataModel();
        }
        public OmronFINsTestingConnector()
        {

        }

        /// <summary>
        /// Get the SOT from PLC
        /// </summary>
        /// <param name="timeout_ms">SOT time out</param>
        /// <param name="ct">Cancellation Token</param>
        /// <param name="progress">Progress Report Model</param>
        /// <returns>Comm Data Model with SOT information</returns>
        public async Task<int[]> GetSOTAsync(CancellationToken ct,
            IProgress<ProgressReportModel> progress, MessageBasedSession mbSession)
        {
            PlcTestingCommDataModel CommData = new PlcTestingCommDataModel();
            //int[] SOT = new int[4];
            ProgressReportModel report = new ProgressReportModel();
            DateTimeOffset startTime = DateTimeOffset.Now;
            bool timedout = false;
            bool canceled = false;
            bool SOTready = false;

            DateTimeOffset idleStartTime = DateTimeOffset.Now;

            //report.ErrMsg = "start time: "+testStartTime.ToString();
            //progress.Report(report);
            //int timeLeft = timeout - (int)elapsedTime.TotalMilliseconds;

            //initializeGpib(mbSession);

            await Task.Run(() =>
            {
                while (true)
                {
                    if (ct.IsCancellationRequested)
                    {
                        canceled = true;
                        break;
                    }
                    //if (timeout_ms>0 && DateTimeOffset.Now.Subtract(startTime).TotalMilliseconds > timeout_ms)
                    //{
                    //    timedout = true;
                    //    break;
                    //}
                    var elapsedTime = DateTimeOffset.Now - idleStartTime;
                    if ((int)elapsedTime.TotalMilliseconds > 180000)
                    {
                        bool succ = GlobalIF.TesterIF.WakeUpPort(mbSession);
                        if (!succ)
                        {
                            //report.ClrReport();
                            //report.ErrMsg = "GPIB comm LOST, please restart GPIB";
                            //report.CriticalErr = true;
                            //progress.Report(report);
                            throw new NotImplementedException("GPIB comm LOST, please restart GPIB");                            
                        }
                        //report.ClrReport();
                        //report.ErrMsg = "GPIB comm OK.." + DateTimeOffset.Now.ToString(); ;
                        //progress.Report(report);
                        idleStartTime = DateTimeOffset.Now;
                    }

                    string plcRxStr = OmronFINsProcessor.GenericRdPLC(PlcMemArea.WR, "379", "383", PlcPort);
                    CommData = OmronFINsProcessor.ParseSOT(plcRxStr);//Extract SOT
                    if (plcRxStr != null)
                    {
                        switch (getSOTstage(CommData))
                        {
                            case 0:
                                ReportStage(PlcStageCode[1]);//inform PLC test conn is ready
                                break;
                            case 2://SOT is ready
                                SOTready = true;
                                ReportStage(PlcStageCode[3]);
                                break;
                            case 5://Previous cycle completed
                                ReportStage(PlcStageCode[1]);//inform PLC test conn is ready
                                break;
                            default:
                                break;
                        }

                        if (SOTready)
                        {
                            break;
                        }
                    }
                }
            });

            if (timedout)
            {
                throw new TimeoutException("SOT is taking too long.. Check PLC connection");
            }
            else if (canceled)
            {
                throw new OperationCanceledException("The test operation is canceled..");
            }

            if (SOTready)
            {
                return CommData.SOT;
            }
            else
            {
                return null;
            }
        }

        public async Task<int[]> SimulateGetSOTAsync(CancellationToken ct, IProgress<ProgressReportModel> progress)
        {
            PlcTestingCommDataModel CommData = new PlcTestingCommDataModel();
            int[] SOT = new int[4];
            ProgressReportModel report = new ProgressReportModel();
            DateTimeOffset startTime = DateTimeOffset.Now;
            bool timedout = false;
            bool canceled = false;
            bool SOTready = false;

            if (!PlcPort.IsOpen)
            {
                PlcPort.Open();
            }

            await Task.Run(() =>
            {
                while (true)
                {
                    if (ct.IsCancellationRequested)
                    {
                        canceled = true;
                        break;
                    }
                    //if (timeout_ms>0 && DateTimeOffset.Now.Subtract(startTime).TotalMilliseconds > timeout_ms)
                    //{
                    //    timedout = true;
                    //    break;
                    //}

                    string plcRxStr = OmronFINsProcessor.GenericRdPLC(PlcMemArea.WR, "379", "383", PlcPort);
                    CommData = OmronFINsProcessor.ParseSOT(plcRxStr);//Extract SOT
                    if (plcRxStr != null)
                    {
                        switch (getSOTstage(CommData))
                        {
                            case 0:
                                ReportStage(PlcStageCode[1]);//inform PLC test conn is ready

                                #region test code
                                Thread.Sleep(500);
                                ReportStage(PlcStageCode[2]);
                                break;
                            case 1:
                                ReportStage(PlcStageCode[2]);
                                break;
                            #endregion

                            case 2://SOT is ready
                                SOTready = true;
                                ReportStage(PlcStageCode[3]);
                                break;
                            case 5://Previous cycle completed
                                ReportStage(PlcStageCode[1]);//inform PLC test conn is ready
                                break;
                            default:
                                break;
                        }

                        if (SOTready)
                        {
                            break;
                        }
                    }
                }
            });

            if (timedout)
            {
                throw new TimeoutException("SOT is taking too long.. Check PLC connection");
            }
            else if (canceled)
            {
                throw new OperationCanceledException("The operation is canceled..");
            }

            if (SOTready)
            {
                return CommData.SOT;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Send the Test Results BIN/EOT to PLC
        /// </summary>
        /// <param name="TestResult">Test Result in CommData Model</param>
        /// <returns>Send successful or not</returns>
        public bool SendResult(GpibCommDataModel TestResult)
        {
            string BinStr = "";
            for (int i = 0; i < 4; i++)
            {
                BinStr = BinStr + TestResult.RxBIN[i];
            }
            bool R = OmronFINsProcessor.GenericWrtPLC(PlcMemArea.WR, "384", "387", BinStr, PlcPort, out string expmsg);
            if (R)
            {
                ReportStage(PlcStageCode[4]);

                //#region test code
                //ReportStage(PlcStageCode[5]);
                //#endregion

            }
            return R;
        }

        /// <summary>
        /// Report current stage code to PLC
        /// </summary>
        /// <param name="stageCode">stage code: 0 not ready, 1 ready, 2 SOT ready, 3 beging test, 4 EOT, 5 BIN read by PLC </param>
        /// <returns></returns>
        private bool ReportStage(string stageCode)
        {
            return OmronFINsProcessor.GenericWrtPLC(PlcMemArea.WR, "379", "379", stageCode, PlcPort, out string expmsg);
        }

        /// <summary>
        /// Check if SOT contains any valid data
        /// </summary>
        /// <param name="SOT"></param>
        /// <returns></returns>
        private int getSOTstage(PlcTestingCommDataModel SOT)
        {
            if (SOT == null)
            {
                return 0;
            }
            else
            {
                return Array.IndexOf(PlcStageCode, SOT.PlcStage);
            }
        }

        public void SetPort(SerialPort serialPort)
        {
            PlcPort = serialPort;
        }
    }
}
