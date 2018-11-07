using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.Visa;
using XFTesterIF;
using XFTesterIF.Models;

namespace XFTesterIF.TesterIFConnection
{
    public class NIGpibConnector : ITesterIFConnection
    {
  
        //public string Protocol { get; set; }
        public string ReadFromTester(MessageBasedSession messageBasedSession)
        {   
            return NIGpibHelper.GpibRead(messageBasedSession);
        }

        public GpibCommDataModel RunTestSequence(TesterIFType iFType, TesterIFProtocol iFProtocol, MessageBasedSession mbSession)
        {
            switch (iFType)
            {
                case TesterIFType.NIGPIB:
                    if (iFProtocol==TesterIFProtocol.MTGPIB)
                    {
                        return runTest_MT(mbSession);
                    }
                    else if (iFProtocol==TesterIFProtocol.RSGPIB)
                    {
                        return runTest_RS(mbSession);
                    }
                    else { return null; }
                    //break;
                case TesterIFType.RS232:
                    return null;
                    //break;
                case TesterIFType.TTL:
                    return null;
                    //break;
                default:
                    return null;
                    //break;
            }
        }

        public bool SendToTester(string String)
        {
            //TODO -  add GPIB Read code
            throw new NotImplementedException();
        }

        public void StopTestSequence()
        {
            throw new NotImplementedException();
        }

    

        private GpibCommDataModel runTest_MT(MessageBasedSession mbSession)
        {

        }

        private GpibCommDataModel runTest_RS(MessageBasedSession mbSession)
        {

        }
    }
}
