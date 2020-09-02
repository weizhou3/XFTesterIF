using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFTesterIF.Models
{
    public class PlcTestingCommDataModel
    {
        public string PlcStage { get; set; } = null;
        //PLC Stage Code: [0] not ready, [1] ready, [2] SOT ready, [3] beging GPIB with tester, [4] EOT, [5] BIN read by PLC
        //public string[] PlcStageCode { get; } = new string[6] { "0000", "0001", "0007", "000F", "001F", "007F" };
        public int[] SOT { get; set; } = new int[4];
        public int[] BIN { get; set; } = new int[4];
        public int[] EOT { get; set; } = new int[4];
    }
}
