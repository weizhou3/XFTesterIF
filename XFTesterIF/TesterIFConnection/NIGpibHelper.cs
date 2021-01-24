using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFTesterIF.TesterIFConnection
{
    public static class NIGpibHelper
    {
        
        public static bool GpibWrite(MessageBasedSession mbSession, string TxStr)
        {
            try
            {
                string textToWrite = ReplaceCommonEscapeSequences(TxStr);
                mbSession.RawIO.Write(TxStr);
                //mbSession.RawIO.BeginRead
                return true;
            }
            catch (Exception) { return false; }
        }

        public static string GpibRead(MessageBasedSession mbSession)
        {
            try
            {
                string RxStr = InsertCommonEscapeSequences(mbSession.RawIO.ReadString());
                return RxStr;
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }

        public static string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }

        public static string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }

        public static bool CheckGpibStats(int bit, string retString)
        {
            retString = retString.Replace("\\r", "").Replace("\\n", "");
            int.TryParse(retString, out int stats);
            int bitAnd = stats & (1 << bit);
            if (bitAnd == 1 << bit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
