using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFTesterIF.Models;
using System.Threading;

namespace XFTesterIF.TesterIFConnection
{
    public static class MTGpibProcessor
    {
        public static readonly string[] SQBByte = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ":", ";", "<", "=", ">", "?" };

        //public static int[] DUT_CS { set; private get; } = new int[4];

        /// <summary>
        /// return the MT protocol SOT spbyte in ASCII
        /// </summary>
        /// <param name="gpibData">SOT data model to be sent to Tester</param>
        /// <returns>The ASCII string represnts sites are ready for test</returns>
        public static string GetSOTStr(int[] SOT, int[] DUT_CS)
        {
            string StrX = "";
            string StrY = "";
            string BinStr = "";
            int[] X = new int[8] { 0, 0, 1, 1, 0, 0, 0, 0 };//bit 0..3 <-> DUT 1..4 the prefix is 3 ->0011
            int[] Y = new int[8] { 0, 0, 1, 1, 0, 0, 0, 0 };//bit 0..3 <-> DUT 5..8

            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (DUT_CS[i] == j)
                    {
                        if (j < 5)
                            X[8 - j] = SOT[i];
                        else
                            Y[12 - j] = SOT[i];
                    }
                }
            }
            string[] arrayX = Array.ConvertAll(X, element => element.ToString());
            string[] arrayY = Array.ConvertAll(Y, element => element.ToString());
            StrX = string.Join("", arrayX);
            StrY = string.Join("", arrayY);
            BinStr = GlobalIF.BinaryToASCII(StrX) + GlobalIF.BinaryToASCII(StrY);
            return BinStr;
        }

        

        private static int[] BinAssign_MT(string RxS, int[] DUT_CS)//translate received BIN to BIN class. 
        {
            RxS = RxS.Trim();
            RxS = RxS.Replace("\0", "");

            string[] parts = RxS.Split(' ');
            int[] binCS = new int[4] { 0, 0, 0, 0 };
            string[] RxBIN = new string[8];
            //int[] index = new int[4];

            for (int i = 0; i < parts.Length; i++)
            {
                if (string.Compare(parts[i], "BIN") != 0 && parts[i].Contains("A")) { RxBIN[0] = parts[i + 2].Trim(); }//binCS[0] = int.Parse(RxBIN[0]); }
                if (string.Compare(parts[i], "BIN") != 0 && parts[i].Contains("B")) { RxBIN[1] = parts[i + 2].Trim(); }
                if (string.Compare(parts[i], "BIN") != 0 && parts[i].Contains("C")) { RxBIN[2] = parts[i + 2].Trim(); }
                if (string.Compare(parts[i], "BIN") != 0 && parts[i].Contains("D")) { RxBIN[3] = parts[i + 2].Trim(); }
                if (string.Compare(parts[i], "BIN") != 0 && parts[i].Contains("E")) { RxBIN[4] = parts[i + 2].Trim(); }
                if (string.Compare(parts[i], "BIN") != 0 && parts[i].Contains("F")) { RxBIN[5] = parts[i + 2].Trim(); }
                if (string.Compare(parts[i], "BIN") != 0 && parts[i].Contains("G")) { RxBIN[6] = parts[i + 2].Trim(); }
                if (string.Compare(parts[i], "BIN") != 0 && parts[i].Contains("H")) { RxBIN[7] = parts[i + 2].Trim(); }
            }

            for (int i = 0; i < 4; i++)
            {
                //index[0] = MT.DUT_CS[0] - 1;
                if (RxBIN[DUT_CS[i] - 1] != null)
                    binCS[i] = int.Parse(RxBIN[DUT_CS[i] - 1]);
            }
            return binCS;
        }

        /// <summary>
        /// Generate SOT string to be sent to tester
        /// </summary>
        /// <param name="mappingCS_DUT">CS DUT mapping</param>
        /// <param name="SOT">SOT array</param>
        /// <returns>The SOT string</returns>
        public static string GenerateSOTStr(string mappingCS_DUT, int[]SOT)
        {
            string StrX = "";
            string StrY = "";
            string BinStr = "";
            int[] CS_DUT = mapCS_DUT(mappingCS_DUT);
            int[] X = new int[8] { 0, 0, 1, 1, 0, 0, 0, 0 };//bit 0..3 <-> DUT 1..4
            int[] Y = new int[8] { 0, 0, 1, 1, 0, 0, 0, 0 };//bit 0..3 <-> DUT 5..8

            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (CS_DUT[i] == j)
                    {
                        if (j < 5)
                            X[8 - j] = SOT[i];
                        else
                            Y[12 - j] = SOT[i];
                    }
                }
            }
            string[] arrayX = Array.ConvertAll(X, element => element.ToString());
            string[] arrayY = Array.ConvertAll(Y, element => element.ToString());
            StrX = string.Join("", arrayX);
            StrY = string.Join("", arrayY);
            BinStr = DataManipulateHelper.BinaryToASCII(StrX) + DataManipulateHelper.BinaryToASCII(StrY);
            return BinStr;
        }

        private static int[] mapCS_DUT(string mappingCS_DUT)
        {
            
            return Array.ConvertAll(mappingCS_DUT.ToCharArray(), c => int.Parse(c.ToString()));
        }

        /// <summary>
        /// Parse the received string into CommDataModel
        /// </summary>
        /// <param name="S">Received string</param>
        /// <param name="mappingCS_DUT">CS DUT mapping</param>
        /// <returns>Parsed CommDataModel with received data</returns>
        public static GpibCommDataModel GpibDecipher(string S, int[] DUT_CS)
        {
            GpibCommDataModel retCommData = new GpibCommDataModel();
            S = S.Replace("NGER", " ").Replace("NSER", " ").Replace("\\n", " ").Replace("\\r", " ");
            
            if (S.Contains("A BIN") || S.Contains("B BIN") || S.Contains("C BIN") || S.Contains("D BIN")
                || S.Contains("E BIN") || S.Contains("F BIN") || S.Contains("G BIN") || S.Contains("H BIN"))
            {
                //int[] BIN = new int[4];
                retCommData.cmdType = "BIN!";
                retCommData.BIN = BinAssign_MT(S,DUT_CS);
                for (int i = 0; i < 4; i++)
                {
                    if (retCommData.BIN[i] > 0) { retCommData.EOT[i] = 1; }
                    else { retCommData.EOT[i] = 0; }

                    //retCommData.BIN[i] = BIN[i];
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

    }
}
