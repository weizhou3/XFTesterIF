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
    public interface IPlcTestingConnection
    {
        Task<int[]> GetSOTAsync(CancellationToken ct, IProgress<ProgressReportModel> progress, MessageBasedSession mbSession);
        bool SendResult(GpibCommDataModel TestResult);
        void SetPort(SerialPort serialPort);
        //bool ReportStage(string stageCode);
    }
}
