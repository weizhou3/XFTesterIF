using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using XFTesterIF;

namespace XFTesterIF.TesterIFConnection
{
    public class RS232Connector : ITesterIFConnection
    {
        public string Protocol { get; set; }
        public string IFport { get; set; }
        public string ReadFromTester()
        {
            throw new NotImplementedException();
        }

        public void RunTestSequence(TesterIFType iFType, TesterIFProtocol iFProtocol)
        {
            throw new NotImplementedException();
        }

        public bool SendToTester(string String)
        {
            throw new NotImplementedException();
        }

        public void StopTestSequence()
        {
            throw new NotImplementedException();
        }
    }
}
