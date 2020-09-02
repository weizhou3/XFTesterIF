using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFTesterIF.Models;

namespace XFTesterIF.TesterIFConnection
{
    public static class RSGpibProcessor
    {
        public static string SetSRQ(GpibCommDataModel GpibData)//Set SRQ and Spbyte
        {
            string spbyte;
            int[] Spbyte = new int[8];
            //set SPByte per SOT
            Spbyte[1] = 1;//enable SRQ @ bit6
            Spbyte[0] = 0;
            for (int i = 0; i < 4; i++)//set SOT CS1-CS4 @ bit0..3
            {
                Spbyte[7 - i] = GpibData.SOT[i];
            }

            //convert spbyte array to hex string
            string[] array1 = Array.ConvertAll(Spbyte, element => element.ToString());
            spbyte = string.Join("", array1);
            spbyte = GlobalIF.HexConvert2(spbyte);
            return spbyte;
        }

        public static GpibCommDataModel GpibDecipher(string S)
        {
            GpibCommDataModel retCommData = new GpibCommDataModel();
            S = S.Replace("NGER", " ").Replace("NSER", " ").Replace("\\n", " ").Replace("\\r", " ");
            if (S.Contains("A BIN") || S.Contains("B BIN") || S.Contains("C BIN") || S.Contains("D BIN"))
            {
                int[] BIN = new int[4];
                retCommData.cmdType = "BIN!";
                BIN = BinAssign(S);
                for (int i = 0; i < 4; i++)
                {
                    if (BIN[i] > 0) { retCommData.EOT[i] = 1; }
                    else { retCommData.EOT[i] = 0; }

                    retCommData.BIN[i] = BIN[i];
                }
                // f.Cmd = true;
            }
            else if (string.Compare(S, "ID?") == 0) { retCommData.cmdType = "ID?";  }
            else if (string.Compare(S, "HSS?") == 0) { retCommData.cmdType = "HSS?";  }
            else if (string.Compare(S, "SITES?") == 0) { retCommData.cmdType = "SITES?";  }
            else if (string.Compare(S, "STA!") == 0) { retCommData.cmdType = "STA!";  }
            else if (string.Compare(S, "STO!") == 0) { retCommData.cmdType = "STO!";  }
            else if (string.Compare(S, "ID") == 0) { retCommData.cmdType = "ID!";  }
            else if (string.Compare(S, "TMP") == 0) { retCommData.cmdType = "TMP!";  }
            else if (string.Compare(S, "TMP?") == 0) { retCommData.cmdType = "TMP?";  }
            else if (string.Compare(S, "TMPCS?") == 0) { retCommData.cmdType = "TMPCS?";  }
            else if (string.Compare(S, "AFX?") == 0) { retCommData.cmdType = "AFX?";  }
            else if (string.Compare(S, "AFX!") == 0) { retCommData.cmdType = "AFX!";  }
            else { retCommData.cmdType = "Invalid";  }

            return retCommData;
        }

        private static int[] BinAssign(string RxS)//translate received BIN to BIN class. 
        {
            RxS = RxS.Trim();
            RxS = RxS.Replace("\0", "");

            string[] parts = RxS.Split(' ');
            int[] binCS = new int[4] { 0, 0, 0, 0 };
            string[] RxBIN = new string[4];

            for (int i = 0; i < parts.Length; i++)
            {
                if (string.Compare(parts[i], "A") == 0) { RxBIN[0] = parts[i + 2].Trim(); binCS[0] = int.Parse(RxBIN[0]); }
                if (string.Compare(parts[i], "B") == 0) { RxBIN[1] = parts[i + 2].Trim(); binCS[1] = int.Parse(RxBIN[1]); }
                if (string.Compare(parts[i], "C") == 0) { RxBIN[2] = parts[i + 2].Trim(); binCS[2] = int.Parse(RxBIN[2]); }
                if (string.Compare(parts[i], "D") == 0) { RxBIN[3] = parts[i + 2].Trim(); binCS[3] = int.Parse(RxBIN[3]); }
            }
            return binCS;
        }

    }
}
