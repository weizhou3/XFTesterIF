using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFTesterIF;

namespace XFTesterIF_UI
{
    public partial class DebugPage : Form
    {
        private int DebugSOT_CS1 { get; set; }
        private int DebugSOT_CS2 { get; set; }
        private int DebugSOT_CS3 { get; set; }
        private int DebugSOT_CS4 { get; set; }
        //private bool debugMode { get; set; }

        public DebugPage()
        {
            InitializeComponent();
            DebugSOT_CS1 = 0;
            DebugSOT_CS2 = 0;
            DebugSOT_CS3 = 0;
            DebugSOT_CS4 = 0;
            //debugMode = DebugMode;
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            //debugMode = false;
            //GlobalIF.DebugMode = false;
            this.Close();
        }

        private void SOT_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                switch (cb.Text.Substring(2, 1))
                {
                    case "1":
                        DebugSOT_CS1 = 1;                        
                        break;
                    case "2":
                        DebugSOT_CS2 = 1;
                        break;
                    case "3":
                        DebugSOT_CS3 = 1;
                        break;
                    case "4":
                        DebugSOT_CS4 = 1;
                        break;
                    default:
                        break;
                }
                cb.BackColor = Color.Gold;
            }
            else
            {
                switch (cb.Text.Substring(2, 1))
                {
                    case "1":
                        DebugSOT_CS1 = 0;
                        break;
                    case "2":
                        DebugSOT_CS2 = 0;
                        break;
                    case "3":
                        DebugSOT_CS3 = 0;
                        break;
                    case "4":
                        DebugSOT_CS4 = 0;
                        break;
                    default:
                        break;
                }
                cb.BackColor = Color.LightGray;
            }
        }

        private void btnSetSOT_Click(object sender, EventArgs e)
        {
            GlobalIF.DebugSOT[0] = DebugSOT_CS1;
            GlobalIF.DebugSOT[1] = DebugSOT_CS2;
            GlobalIF.DebugSOT[2] = DebugSOT_CS3;
            GlobalIF.DebugSOT[3] = DebugSOT_CS4;
        }

        private void DebugPage_Load(object sender, EventArgs e)
        {
            if (GlobalIF.DebugSOT[0]==1)
            {
                SOT1.Checked = true;
            }
            if (GlobalIF.DebugSOT[1] == 1)
            {
                SOT2.Checked = true;
            }
            if (GlobalIF.DebugSOT[2] == 1)
            {
                SOT3.Checked = true;
            }
            if (GlobalIF.DebugSOT[3] == 1)
            {
                SOT4.Checked = true;
            }
        }
    }
}
