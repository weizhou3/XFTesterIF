using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XFTesterIF;
using XFTesterIF.Models;

namespace XFTesterIF.TesterIFConnection
{
    public interface ITesterIFConnection
    {

        //Progress<ProgressReportModel> progress { get; set; }
        //bool SendToTester(string String);
        //string ReadFromTester(MessageBasedSession messageBasedSession);
        //GpibCommDataModel RunTestSequence(TesterIFType iFType,TesterIFProtocol iFProtocol, MessageBasedSession messageBasedSession);

        //void SetCommTimeout(int timeOutms);
        void SetPort(SerialPort port);
        void SetResourceName(string resourceName);
        void SetDUTMapping(string mapping);
        bool WakeUpPort(MessageBasedSession mbSession);
        Task<GpibCommDataModel> GetTestResultAsync(MessageBasedSession mbSession, int[]SOT, int[]DUT_CS, int timeout_ms, CancellationToken ct, IProgress<ProgressReportModel> progress);
        Task<GpibCommDataModel> SimulatingGetTestResultAsync(MessageBasedSession mbSession, int[] SOT, int[]DUT_CS, int timeout_ms, CancellationToken ct, IProgress<ProgressReportModel> progress);
        
        //bool InitializeIFPort(SerialPort serialPort);
        //Task<GpibCommDataModel> RunTestSequenceAsync(TesterIFType iFType, TesterIFProtocol iFProtocol, MessageBasedSession messageBasedSession);


    }
}
