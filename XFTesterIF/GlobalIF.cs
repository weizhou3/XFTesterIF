﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFTesterIF;
using XFTesterIF.TesterIFConnection;

namespace XFTesterIF
{
    public static class GlobalIF
    {
        public static ITesterIFConnection IFConnection { get; private set; }
        
        public static void InitializeIFConnections(TesterIFType IFType, TesterIFProtocol IFProtocol)
        {
            switch (IFType)
            {
                case TesterIFType.NIGPIB:
                    NIGpibConnector gpib = new NIGpibConnector();
                    IFConnection = gpib;
                    //gpib.IFport = IFport;

                    //switch (IFProtocol)
                    //{
                    //    case TesterIFProtocol.MTGPIB:
                    //         NIGpibConnector gpib
                            
                    //        break;
                    //    case TesterIFProtocol.RSGPIB:
                    //        gpib.Protocol = "RSGPIB";
                    //        break;
                    //    case TesterIFProtocol.RSRS232:
                    //        gpib.Protocol = "invalid";
                    //        break;
                    //    default:
                    //        break;
                    //}
                    break;
                case TesterIFType.RS232:
                    RS232Connector rs232 = new RS232Connector();
                    IFConnection = rs232;
                    //rs232.IFport = IFport;

                    //switch (IFProtocol)
                    //{
                    //    case TesterIFProtocol.MTGPIB:
                    //        rs232.Protocol = "invalid";
                    //        break;
                    //    case TesterIFProtocol.RSGPIB:
                    //        rs232.Protocol = "invalid";
                    //        break;
                    //    case TesterIFProtocol.RSRS232:
                    //        rs232.Protocol = "RSRS232";
                    //        break;
                    //    default:
                    //        break;
                    //}
                    break;
                default:
                    break;
            }
        }
        
        public static string AppKeyLookup(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static string GetGpibPort(string GpibCardAddress)
        {
            return  $"ASRL{GpibCardAddress}::INSTR";
        }

        public static string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }

        public static string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }

        #region data manipulation methods
        public static string HexConvert2(string str2)//convert binary string to hex string
        {
            string str16 = Convert.ToInt32(str2, 2).ToString("X");
            return str16;
        }

        public static string HexConvert10(string str10)//convert decimal string to hex string
        {
            string str16 = Convert.ToInt32(str10, 10).ToString("X");
            return str16;
        }

        public static string BinaryConvert16(string str16)//convert Hexdecimal string to binary string
        {
            //string str2 = Convert.ToInt64(str16, 16).ToString();
            string str2 = String.Join(String.Empty,
             str16.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            return str2;
        }

        public static string ReplaceAt(string s, int index, char newChar)//replace char at s.index with newChar
        {
            char[] chars = s.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }

        public static string BinaryToASCII(string bin)
        {
            string ascii = string.Empty;

            for (int i = 0; i < bin.Length; i += 8)
            {
                ascii += (char)BinaryToDecimal(bin.Substring(i, 8));
            }

            return ascii;
        }

        public static int BinaryToDecimal(string bin)
        {
            int binLength = bin.Length;
            double dec = 0;

            for (int i = 0; i < binLength; ++i)
            {
                dec += ((byte)bin[i] - 48) * Math.Pow(2, ((binLength - i) - 1));
            }

            return (int)dec;
        }
        #endregion data manipulation methods
    }
}
