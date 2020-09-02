using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFTesterIF
{
    public static class DataManipulateHelper
    {
        /// <summary>
        /// convert binary string to hex string
        /// </summary>
        /// <param name="str2">Binary string</param>
        /// <returns>Hex string</returns>
        public static string HexConvert2(string str2)
        {
            string str16 = Convert.ToInt32(str2, 2).ToString("X");
            return str16;
        }

        /// <summary>
        /// Convert decimal string to hex string
        /// </summary>
        /// <param name="str10">Decimal string</param>
        /// <returns>Hex string</returns>
        public static string HexConvert10(string str10)
        {
            string str16 = Convert.ToInt32(str10, 10).ToString("X");
            return str16;
        }

        /// <summary>
        /// Convert Hexdecimal string to binary string
        /// </summary>
        /// <param name="str16">Hex string</param>
        /// <returns>Binary string</returns>
        public static string BinaryConvert16(string str16)
        {
            string str2 = String.Join(String.Empty,
             str16.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            return str2;
        }

        /// <summary>
        /// replace char at s.index with newChar
        /// </summary>
        /// <param name="s">Original string</param>
        /// <param name="index">Index where char need to be replaced</param>
        /// <param name="newChar">New char</param>
        /// <returns>String with replaced Char at Index</returns>
        public static string ReplaceAt(string s, int index, char newChar)//
        {
            char[] chars = s.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }

        /// <summary>
        /// Convert Binary string to ASCII string 
        /// </summary>
        /// <param name="bin">Binary String</param>
        /// <returns>ASCII string</returns>
        public static string BinaryToASCII(string bin)
        {
            string ascii = string.Empty;

            for (int i = 0; i < bin.Length; i += 8)
            {
                ascii += (char)BinaryToDecimal(bin.Substring(i, 8));
            }

            return ascii;
        }

        /// <summary>
        /// Convert Binary string to int
        /// </summary>
        /// <param name="bin">Binary string</param>
        /// <returns>Decimal number</returns>
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
        
    }
}
