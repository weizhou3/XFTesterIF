using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFTesterIF;
using XFTesterIF.Models;

namespace XFTesterIF.TesterIFConnection
{
    public interface ITesterIFConnection
    {
        bool SendToTester(string String);
        string ReadFromTester(MessageBasedSession messageBasedSession);
        GpibCommDataModel RunTestSequence(TesterIFType iFType,TesterIFProtocol iFProtocol, MessageBasedSession messageBasedSession);
        void StopTestSequence();
    }
}
