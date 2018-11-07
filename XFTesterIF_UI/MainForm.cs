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
            SetupControlState(false);
        }

        private void btnGpibON_Click(object sender, EventArgs e)
        {
            disableSettingInput();

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
            
            //TODO - add RunTestComm BGW
            if (!bgwRunTest.IsBusy)
            {
                bgwRunTest.RunWorkerAsync();
            }

            
            //TODO - open PLC port, turn on timer to SyncPLC(). inside timer call BGW when needed


        }

        private void btnGpibOFF_Click(object sender, EventArgs e)
        {
            SetupControlState(false);
            mbSession.Dispose();
            if (bgwRunTest.IsBusy)
            {
                bgwRunTest.CancelAsync();
                lblRdProgress.Text = "Stopped";
            }
            enableSettingInput();
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
                    saveAllSettings();
                    updateMtDUT_CS();
                }
            }
        }

        //private void TBox_TextChanged(object sender, EventArgs e)
        //{
        //    saveAllSettings();
        //    updateMtDUT_CS();
        //}

        private void saveAllSettings()
        {
            UserSettings.Default.HandlerAddress = TBoxAddress.Text;
            UserSettings.Default.GpibCardAddress = TBoxGpibCardAddr.Text;
            UserSettings.Default.CommTimeout = TBoxTimeOut.Text;
            UserSettings.Default.MTDUT_CS1 = TBoxCS1.Text;
            UserSettings.Default.MTDUT_CS2 = TBoxCS2.Text;
            UserSettings.Default.MTDUT_CS3 = TBoxCS3.Text;
            UserSettings.Default.MTDUT_CS4 = TBoxCS4.Text;
            if (MTCB.Checked)
                UserSettings.Default.TesterIFProtocol = "MTGPIB";
            if (DeltaCB.Checked)
                UserSettings.Default.TesterIFProtocol = "RSGPIB";

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
            updateMtDUT_CS();
        }

        private void disableSettingInput()
        {
            TBoxAddress.Enabled = false;
            TBoxGpibCardAddr.Enabled = false;
            TBoxTimeOut.Enabled = false;
            TBoxCS1.Enabled = false;
            TBoxCS2.Enabled = false;
            TBoxCS3.Enabled = false;
            TBoxCS4.Enabled = false;
            DeltaCB.Enabled = false;
            MTCB.Enabled = false;
        }

        private void enableSettingInput()
        {
            TBoxAddress.Enabled = true;
            TBoxGpibCardAddr.Enabled = true;
            TBoxTimeOut.Enabled = true;
            TBoxCS1.Enabled = true;
            TBoxCS2.Enabled = true;
            TBoxCS3.Enabled = true;
            TBoxCS4.Enabled = true;
            DeltaCB.Enabled = true;
            MTCB.Enabled = true;
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

        private void updateMtDUT_CS()
        {

            
            MTGpibProcessor.DUT_CS[0] = int.Parse(UserSettings.Default.MTDUT_CS1);
            MTGpibProcessor.DUT_CS[1] = int.Parse(UserSettings.Default.MTDUT_CS2);
            MTGpibProcessor.DUT_CS[2] = int.Parse(UserSettings.Default.MTDUT_CS3);
            MTGpibProcessor.DUT_CS[3] = int.Parse(UserSettings.Default.MTDUT_CS4);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveAllSettings();
        }

        private void bgwRunTest_DoWork(object sender, DoWorkEventArgs e)
        {
            #region test code

            try
            {
                int i = 0;
                int total = 10;
                int index = 1;
                List<string> RtnStr = new List<string>();
                do
                {
                    if (!bgwRunTest.CancellationPending)
                    {

                        //double percentage = i / total * 100;
                        double percentage = index++ * 100 / total;
                        bgwRunTest.ReportProgress((int)percentage, string.Format("Reading data {0}", i));
                        string StrRd = GlobalIF.IFConnection.ReadFromTester(mbSession);
                        //string StrRd = GlobalIF.IFConnection.RunTestSequence(mbSession);

                        RtnStr.Add(StrRd);
                        e.Result = RtnStr;

                        //Thread.Sleep(500);
                        i = i + 1;
                    }
                    else if (bgwRunTest.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                } while (i < total);

            }
            catch (Exception exp)
            {
                bgwRunTest.CancelAsync();
                MessageBox.Show(exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion


        }

        private void bgwRunTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblRdProgress.Text = $"Reading {e.ProgressPercentage}";
            progressRd.Value = e.ProgressPercentage;
            progressRd.Update();
            
        }

        private void bgwRunTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Cancelled)
                {
                    ErrMsgBox.AppendText("Operation timed out or cancelled by user");
                }
                else
                {
                    List<string>result=(List<string>)e.Result;
                    ErrMsgBox.AppendText("Operation completed");
                    ErrMsgBox.AppendText($"Recevied string: {result.FirstOrDefault()}");
                }
            }
            else
            {
                ErrMsgBox.AppendText("Operation failed");
            }
        }


    }
}
