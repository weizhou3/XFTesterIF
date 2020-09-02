using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFTesterIF.PLCConnection;

namespace XFTesterIF.Models
{
    /// <summary>
    /// The model for one PLC word, contains Binary, Hex and Bits values
    /// To address a single bits, use List to find matching MemoryArea and WordNumber, then.Bits[BitNumber]
    /// </summary>
    public class PlcWordModel
    {
        //public string MemoryArea { get; private set; }
        //public int WordAddress { get { return this.WAddress; } }

        public string ValueStrHex { get { return _hexValueStr; } }
        public string ValueStrBinary { get { return _binaryValueStr; } }
        public string MemoryArea { get; set; }
        public int WordAddress { get; set; }
        //public string Name { get; set; }
        //public PlcWordAddressModel PlcWordAddress { get; private set; } = new PlcWordAddressModel();
        public List<int> Bits { get; private set; } = new List<int>(OmronFINsClass.Width_Word);
        public List<PlcBitModel> plcBits { get; private set; } = new List<PlcBitModel>();
        

        private string _hexValueStr { get; set; }
        private string _binaryValueStr { get; set; }
                
        public PlcWordModel()
        {
            for (int i = 0; i < OmronFINsClass.Width_Word; i++)
            {
                Bits.Add(0);
                plcBits.Add(new PlcBitModel("", -1, i));
            }

            //this.MemArea = MemoryArea;
            //this.WAddress = Wcounter++;
            //if (Wcounter == OmronFINsClass.Size_WR)
            //    throw new InvalidOperationException("Max number of Word address is reached!!");

            //PlcWordAddress.WordAddress = Wcounter++;
        }

        public PlcWordModel(string memArea, int wordAddress)
        {
            MemoryArea = memArea.ToUpper();
            WordAddress = wordAddress;
            for (int i = 0; i < OmronFINsClass.Width_Word; i++)
            {
                Bits.Add(0);
                plcBits.Add(new PlcBitModel(memArea, wordAddress, i));
            }
        }

        public PlcWordModel(string memArea, int wordAddress, string valueStrHex)
        {
            MemoryArea = memArea.ToUpper();
            WordAddress = wordAddress;
            for (int i = 0; i < OmronFINsClass.Width_Word; i++)
            {
                Bits.Add(0);
                plcBits.Add(new PlcBitModel(memArea, wordAddress, i));
            }
            SetValue(valueStrHex);
            SetAllBitsValue();
        }

        public PlcWordModel(PlcMemArea memArea, int wordAddress, string valueStrHex)
        {
            switch (memArea)
            {
                case PlcMemArea.CIO:
                    MemoryArea = "C";
                    break;
                case PlcMemArea.WR:
                    MemoryArea = "W";
                    break;
                case PlcMemArea.HR:
                    MemoryArea = "H";
                    break;
                case PlcMemArea.AR:
                    MemoryArea = "A";
                    break;
                case PlcMemArea.DM:
                    MemoryArea = "D";
                    break;
                default:
                    break;
            }
            WordAddress = wordAddress;
            for (int i = 0; i < OmronFINsClass.Width_Word; i++)
            {
                Bits.Add(0);
                plcBits.Add(new PlcBitModel(MemoryArea, wordAddress, i));
            }
            SetValue(valueStrHex);
            SetAllBitsValue();
            
        }

        /// <summary>
        /// Set the Word Hex value
        /// </summary>
        /// <param name="ValueStr">The Hex Value string</param>
        public void SetValue(string ValueStr)
        {
            _hexValueStr = ValueStr.PadLeft(4,'0');
            _binaryValueStr = OmronFINsProcessor.BinaryConvert16(_hexValueStr).PadLeft(16,'0');
            SetAllBitsValue();
        }
        
        //public void SetValue(ushort Value)
        //{

        //}


        public void SetMemoryArea(string MemoryArea)
        {
            //PlcWordAddress.MemoryArea = MemoryArea.ToUpper();
            this.MemoryArea = MemoryArea.ToUpper();
            foreach (var bit in plcBits)
            {
                bit.SetMemArea(this.MemoryArea);
            }
        }

        public void SetWordAddress(int WordAddress)
        {
            //this.PlcWordAddress.WordAddress = WordAddress;
            this.WordAddress = WordAddress;
            foreach (var bit in plcBits)
            {
                bit.SetWordAddress(this.WordAddress);
            }
        }

        /// <summary>
        /// Set a value of a individual Bit inside a Word. Update Word value
        /// </summary>
        /// <param name="BitNumber">The address of individual Bit</param>
        /// <param name="BitValue">Value to be set 0 or 1</param>
        public void SetBitValue(int BitAddress, int BitValue)
        {
            if (BitValue==0||BitValue==1)
            {
                Bits[BitAddress] = BitValue;
                List<int> BitsReversed = new List<int>(Bits);
                BitsReversed.Reverse();
                _binaryValueStr = string.Join("", BitsReversed);
                _hexValueStr = OmronFINsProcessor.HexConvert2(_binaryValueStr); 
            }
        }

        /// <summary>
        /// Get the value of the Word in hex
        /// </summary>
        /// <returns>Word hex value string</returns>
        //public string GetValueStr()
        //{
        //    return _hexValueStr;
        //}

        private void SetAllBitsValue()
        {   
            for (int i = 0; i < OmronFINsClass.Width_Word; i++)
            {
                Bits[i] = int.Parse(_binaryValueStr[OmronFINsClass.Width_Word - 1 - i].ToString());
                plcBits[i].Value = Bits[i];
            }

        }

    }
}
