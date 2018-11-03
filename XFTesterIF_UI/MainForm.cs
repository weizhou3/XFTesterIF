using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFTesterIF.TesterIFConnection;
using XFTesterIF;

namespace XFTesterIF_UI
{
    public partial class MainForm : Form
    {
        private MessageBasedSession mbSession;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGpibON_Click(object sender, EventArgs e)
        {
            //disable all text boxes
            TBoxAddress.Enabled = false;
            TBoxGpibCardAddr.Enabled = false;
            TBoxTimeOut.Enabled = false;
            TBoxCS1.Enabled = false;
            TBoxCS2.Enabled = false;
            TBoxCS3.Enabled = false;
            TBoxCS4.Enabled = false;

            using (var rmSession = new NationalInstruments.Visa.ResourceManager())
            {
                try
                {
                    mbSession = (MessageBasedSession)rmSession.Open(GlobalIF.GetGpibPort(UserSettings.Default.GpibCardAddress));
                    SetupControlState(true);
                }
                catch (InvalidCastException)
                {
                    ErrMsgBox.AppendText("Resource selected must be a message-based session");
                    ErrMsgBox.AppendText(Environment.NewLine);
                }
                catch (Exception exp)
                {
                    ErrMsgBox.AppendText(exp.Message);
                    ErrMsgBox.AppendText(Environment.NewLine);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void SetupControlState(bool isSessionOpen)
        {
            btnGpibON.Enabled = !isSessionOpen;
            btnGpibOFF.Enabled = isSessionOpen;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadAllSettings();
        }

        private void TextBoxClick(object sender, EventArgs e)
        {
            TextBox T = (TextBox)sender;
            using (NumberPad np = new NumberPad())
            {
                if (np.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    T.Text = np.value;
                }
            }
        }

        private void TBox_TextChanged(object sender, EventArgs e)
        {
            saveAllSettings();
        }
        private void saveAllSettings()
        {
            UserSettings.Default.HandlerAddress = TBoxAddress.Text;
            UserSettings.Default.GpibCardAddress = TBoxGpibCardAddr.Text;
            UserSettings.Default.CommTimeout = TBoxTimeOut.Text;
            UserSettings.Default.MTDUT_CS1 = TBoxCS1.Text;
            UserSettings.Default.MTDUT_CS2 = TBoxCS2.Text;
            UserSettings.Default.MTDUT_CS3 = TBoxCS3.Text;
            UserSettings.Default.MTDUT_CS4 = TBoxCS4.Text;
        }

        private void loadAllSettings()
        {
            TBoxAddress.Text = UserSettings.Default.HandlerAddress;
            TBoxGpibCardAddr.Text = UserSettings.Default.GpibCardAddress;
            TBoxTimeOut.Text = UserSettings.Default.CommTimeout;
            TBoxCS1.Text = UserSettings.Default.MTDUT_CS1;
            TBoxCS2.Text = UserSettings.Default.MTDUT_CS2;
            TBoxCS3.Text = UserSettings.Default.MTDUT_CS3;
            TBoxCS4.Text = UserSettings.Default.MTDUT_CS4;
            MTCB.Checked = (UserSettings.Default.TesterIFProtocol == "MTGPIB");
            DeltaCB.Checked = (UserSettings.Default.TesterIFProtocol == "RSGPIB");
        }

        private void MTCB_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CB = (CheckBox)sender;
            if (CB.Checked)
            {
                UserSettings.Default.TesterIFProtocol = "MTGPIB";
                CB.BackColor = Color.Gold;
                DeltaCB.Checked = false;
                TBoxCS1.Visible = true;
                TBoxCS2.Visible = true;
                TBoxCS3.Visible = true;
                TBoxCS4.Visible = true;
            }
            else
            {
                CB.BackColor = Color.LightGray;
            }
        }

        private void DeltaCB_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CB = (CheckBox)sender;
            if (CB.Checked)
            {
                UserSettings.Default.TesterIFProtocol = "RSGPIB";
                CB.BackColor = Color.Gold;
                MTCB.Checked = false;
                TBoxCS1.Visible = false;
                TBoxCS2.Visible = false;
                TBoxCS3.Visible = false;
                TBoxCS4.Visible = false;
            }
            else
            {
                CB.BackColor = Color.LightGray;
            }
        }
    }
}
