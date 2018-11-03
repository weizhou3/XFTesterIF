using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFTesterIF.Models
{
    public class GpibCommDataModel
    {
        public int[] SOT { get; set; }
        public int[] BIN { get; set; }
        public int[] EOT { get; set; }

        public string SQBstr { get; set; }
        public int[] Spbyte { get; set; }
        public string setSpbyte { get; set; }
        public string rdSpbyte { get; set; }

        public string RxStr { get; set; }
        public string TxStr { get; set; }
        public string[] RxBIN { get; set; }

        public string wrtCmd { get; set; }
        public string RdCmd { get; set; }

        public GpibCommDataModel()
        {

        }
        
    }
}
