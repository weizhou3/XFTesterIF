using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFTesterIF.PLCConnection;

namespace XFTesterIF.Models
{
    public class PlcBitModel
    {
        public string MemArea { get; private set; }
        public int WordAddress { get; private set; }
        public int BitAddress { get; private set; }
        public string WordAddressStr { get; private set; }
        public string BitAddressStr { get; private set; }
        public int Value { get; set; }

        
        public void SetAddressStr()
        {
            WordAddressStr = WordAddress.ToString().PadLeft(4, '0');
            BitAddressStr = BitAddress.ToString().PadLeft(2, '0');
        }

        public void SetMemArea(string memArea)
        {
            MemArea = memArea;
        }

        public void SetBitAddress(int bitAddress)
        {
            if (bitAddress > -1 && bitAddress <= OmronFINsClass.Width_Word)
                BitAddress = bitAddress;
        }

        public void SetWordAddress(int wordAddress)
        {
            if (wordAddress>-1)
            {
                WordAddress = wordAddress;
            }
            WordAddressStr = WordAddress.ToString().PadLeft(4, '0');
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="memArea">Bit memory area, WR or HR</param>
        /// <param name="wordAddress">Word address that bit is belonged to 0-511</param>
        /// <param name="bitAddress">Bit address 0-15</param>
        /// <param name="value">Bit value 0 or 1</param>
        public PlcBitModel(PlcMemArea memArea, int wordAddress, int bitAddress, int value)
        {
            if (wordAddress<OmronFINsClass.Size_WR && bitAddress<OmronFINsClass.Width_Word)
            {
                switch (memArea)
                {
                    case PlcMemArea.CIO:
                        MemArea = "C";
                        break;
                    case PlcMemArea.WR:
                        MemArea = "W";
                        break;
                    case PlcMemArea.HR:
                        MemArea = "H";
                        break;
                    case PlcMemArea.AR:
                        MemArea = "A";
                        break;
                    case PlcMemArea.DM:
                        MemArea = "D";
                        break;
                    case PlcMemArea.WR_bit:
                        MemArea = "W";
                        break;
                    default:
                        break;
                }
                WordAddress = wordAddress;
                BitAddress = bitAddress;
                WordAddressStr = OmronFINsProcessor.HexConvert10(wordAddress.ToString()).PadLeft(4, '0');
                BitAddressStr = OmronFINsProcessor.HexConvert10(bitAddress.ToString()).PadLeft(2, '0');
                Value = value;
            }
        }

        public void SetValue(int value)
        {
            if (value==0||value==1)
            {
                Value = value;
            }
        }

        public void SetValue(string value)
        {
            if (value == "0" || value == "1")
            {
                Value = int.Parse(value);
            }
        }

        public PlcBitModel(string memArea, int wordAddress, int bitAddress, string value)
        {
            MemArea = memArea.ToUpper();
            WordAddress = wordAddress;
            BitAddress = bitAddress;
            WordAddressStr = OmronFINsProcessor.HexConvert10(wordAddress.ToString()).PadLeft(4, '0');
            BitAddressStr = OmronFINsProcessor.HexConvert10(bitAddress.ToString()).PadLeft(2, '0');
            if (value=="0"||value=="1")
            {
                Value = int.Parse(value);
            }
            
        }

        public PlcBitModel(string memArea,int wordAddress, int bitAddress)
        {
            MemArea = memArea.ToUpper();
            WordAddress = wordAddress;
            BitAddress = bitAddress;
            WordAddressStr = OmronFINsProcessor.HexConvert10(wordAddress.ToString()).PadLeft(4, '0');
            BitAddressStr = OmronFINsProcessor.HexConvert10(bitAddress.ToString()).PadLeft(2, '0');
        }

        public PlcBitModel()
        {

        }
    }
}
