using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFTesterIF.Models
{
    public class ProgressReportModel
    {
        public int PercentageCompleted { get; set; } = 0;
        //public GpibCommDataModel DataReceived { get; set; } = new GpibCommDataModel();
        public string StageMsg { get; set; } = "Starting..";
        public string ErrMsg { get; set; } = "";
        public int[] CS { get; set; } = new int[4] { 0, 0, 0, 0 };
        public int[] BIN { get; set; } = new int[4] { 0, 0, 0, 0 };
        public bool CriticalErr { get; set; } = false;

        public void ClrReport()
        {
            PercentageCompleted = 0;
            StageMsg = "";
            ErrMsg = "";
            CriticalErr = false;
            for (int i = 0; i < 4; i++)
            {
                CS[i] = 0;
                BIN[i] = 0;
            }
        }
    }
}
