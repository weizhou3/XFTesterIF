using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using XFTesterIF;
using NationalInstruments.Visa;
using XFTesterIF.Models;
using System.IO.Ports;
using System.Threading;

namespace XFTesterIF.TesterIFConnection
{
    public class RS232Connector : ITesterIFConnection
    {
        public string Protocol { get; set; }
        public string IFport { get; set; }
        public Progress<ProgressReportModel> progress { get; set; } = new Progress<ProgressReportModel>();

        public Task<GpibCommDataModel> GetTestResultAsync(MessageBasedSession mbSession, 
            int[] SOT, int[]DUT_CS, int timeout_ms, CancellationToken ct, IProgress<ProgressReportModel> progress)
        {
            throw new NotImplementedException();
        }

        public bool InitializeIFPort(SerialPort serialPort)
        {
            throw new NotImplementedException();
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

        public void StopTestSequence()
        {
            throw new NotImplementedException();
        }

        public void WakeUpPort()
        {
            throw new NotImplementedException();
        }

        public bool WakeUpPort(MessageBasedSession mbSession)
        {
            throw new NotImplementedException();
        }
    }
}
