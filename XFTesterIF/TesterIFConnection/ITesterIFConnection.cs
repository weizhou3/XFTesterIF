using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFTesterIF;

namespace XFTesterIF.TesterIFConnection
{
    public interface ITesterIFConnection
    {
        bool SendToTester(string String);
        string ReadFromTester();
        void RunTestSequence(TesterIFType iFType,TesterIFProtocol iFProtocol);
        void StopTestSequence();
    }
}
