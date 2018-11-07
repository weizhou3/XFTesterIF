using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFTesterIF.Models;

namespace XFTesterIF.TesterIFConnection
{
    public static class MTGpibProcessor
    {
        public static readonly string[] SQBByte = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ":", ";", "<", "=", ">", "?" };

        public static int[] DUT_CS { set; get; } = new int[4];

  

        /// <summary>
        /// return the MT protocol SOT spbyte in ASCII
        /// </summary>
        /// <param name="gpibData">SOT data model to be sent to Tester</param>
        /// <returns>The ASCII string represnts sites are ready for test</returns>
        private static string getSOTStr_MT(GpibCommDataModel gpibData)
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
                            X[8 - j] = gpibData.SOT[i];
                        else
                            Y[12 - j] = gpibData.SOT[i];
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

        private static int[] BinAssign_MT(string RxS)//translate received BIN to BIN class. 
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


    }
}
