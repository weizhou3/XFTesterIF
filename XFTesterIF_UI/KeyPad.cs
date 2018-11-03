using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XFTesterIF_UI
{
    public partial class KeyPad : Form
    {
        public string value { get; set; }

        public KeyPad()
        {
            InitializeComponent();
        }

        private void NumberPad_Load(object sender, EventArgs e)
        {

        }

        private void BtnUp(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.LightBlue;

            if (b.Text == "Clear") { NpDisplay.Clear(); }
            else { NpDisplay.Text = NpDisplay.Text + b.Text; }
        }

        private void BtnDown(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.Orange;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnterUp(object sender, MouseEventArgs e)
        {
            value = NpDisplay.Text;
            //MainForm.HandlerAddress = NpDisplay.Text;
           // this.Close();
        }

        private void KeyPad_KeyPress(object sender, KeyPressEventArgs e)
        {
           // Button b = (Button)sender;
            
            NpDisplay.Text += e.KeyChar.ToString();
        }
    }
}
