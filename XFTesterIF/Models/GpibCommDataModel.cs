using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFTesterIF.Models
{
    public class GpibCommDataModel
    {
        public int[] SOT { get; set; } = new int[4];
        public int[] BIN { get; set; } = new int[4];
        public int[] EOT { get; set; } = new int[4];

        public string SQBstr { get; set; }
        public int[] Spbyte { get; set; }
        public string setSpbyte { get; set; }
        public string rdSpbyte { get; set; }

        public string RxStr { get; set; }
        public string TxStr { get; set; }
        public string[] RxBIN { get; set; } = new string[4] { "0000","0000","0000","0000"};

        public string wrtCmd { get; set; }
        public string RdCmd { get; set; }
        public string cmdType { get; set; }

        public GpibCommDataModel()
        {

        }
        
    }
}
