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
using XFTesterIF.Models;
using System.Threading;
using XFTesterIF.PLCConnection;
using System.IO;
//using ResourceManager = NationalInstruments.Visa.ResourceManager;

namespace XFTesterIF_UI
{
    public partial class TesterIFMain : Form
    {

        CancellationTokenSource cts;
        
        public TesterIFMain()
        {
            InitializeComponent();
            SetupControlState(false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //loadAllSettings();//Load from user setting
            initializeForm();
        }

       

        private void btnGpibON_Click(object sender, EventArgs e)
        {
            disableSettingInput();
            saveAllSettings();
            LabelOFF.Visible = false;
            LabelON.Visible = true;
            btnGpibOFF.Enabled = true;
            btnGpibON.Enabled = false;
            initializeIFconnector();

            //bool succ = startPlcPort(out string expmsg);

            //if (startPlcPort(out string expmsg))// TODO -- uncomment for production
            if(true)
            {
                int.TryParse(UserSettings.Default.CommTimeout, out int timeout);
                cts = new CancellationTokenSource();
                Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
                progress.ProgressChanged += ReportProgress;
                
               // try
               // {
                TestWorker worker = new TestWorker(UserSettings.Default.GpibCardAddress, 
                    UserSettings.Default.CS_MTDUT, UserSettings.Default.HandlerAddress);
                worker.RunTest(timeout * 1000, cts.Token, progress);
               // }
                //catch (NotImplementedException)
                //{
                //    ErrMsgBox.Text += "Can not initiate GPIB, please check connection" + Environment.NewLine;
                //    btnGpibOFF.PerformClick();
                //}
                
            }
            else
            {
                LabelOFF.Visible = true;
                LabelON.Visible = false;
                btnGpibOFF.Enabled = false;
                btnGpibON.Enabled = true;
                enableSettingInput();
                //ErrMsgBox.Text += expmsg + "Please check PLC connection and try again.." + Environment.NewLine;
            }
            


            //PortAwakenTimer.Start();
        }

        private void ReportProgress(object sender, ProgressReportModel e)
        {
            if (e.CriticalErr)
            {
                e.CriticalErr = false;
                btnGpibOFF.PerformClick();
            }
            else if (e.DebugMsg)
            {
                e.DebugMsgs.Add(DateTime.Now.ToString("yyyy-MMdd-HH:mm:ss"));
                File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\DebugOutput", e.DebugMsgs);
                e.DebugMsg = false;
            }
            else
            {
                progressBarCS1.Value = e.CS[0] * e.PercentageCompleted;
                progressBarCS2.Value = e.CS[1] * e.PercentageCompleted;
                progressBarCS3.Value = e.CS[2] * e.PercentageCompleted;
                progressBarCS4.Value = e.CS[3] * e.PercentageCompleted;

                if (e.PercentageCompleted < 100)
                {
                    LabelBIN1.Visible = false;
                    LabelBIN2.Visible = false;
                    LabelBIN3.Visible = false;
                    LabelBIN4.Visible = false;
                    if (e.PercentageCompleted > 0 && !cts.IsCancellationRequested)
                    {
                        lblTiP.Visible = true;
                    }
                }
                else
                {
                    lblTiP.Visible = false;
                    for (int i = 0; i < 4; i++)
                    {
                        var labels = Controls.Find("LabelBIN" + (i + 1).ToString(), true);
                        var label = (Label)labels[0];

                        if (e.CS[i] > 0)
                        {
                            label.Text = "BIN " + (e.CS[i] * e.BIN[i]).ToString();
                            label.Visible = true;
                        }
                    }

                }
                if (e.ErrMsg.Length > 1)
                {
                    ErrMsgBox.Text += e.ErrMsg + Environment.NewLine;
                }

            }
            
        }

        private void btnGpibOFF_Click(object sender, EventArgs e)
        {
            //SetupControlState(false);
            try
            {
                cts.Cancel();
            }
            catch (Exception)
            {
                
            }
            
            LabelON.Visible = false;
            LabelOFF.Visible = true;
            btnGpibON.Enabled = true;
            btnGpibOFF.Enabled = false;
            progressBarCS1.Value = 0;
            progressBarCS1.Value = 0;
            progressBarCS1.Value = 0;
            progressBarCS1.Value = 0;
            lblTiP.Visible = false;
            if (PlcPort.IsOpen)
                PlcPort.Close();
            enableSettingInput();
        }



        private void SetupControlState(bool isSessionOpen)
        {
            btnGpibON.Enabled = !isSessionOpen;
            btnGpibOFF.Enabled = isSessionOpen;
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
                    //updateMtDUT_CS();
                }
            }
        }


        private void PrintResult(GpibCommDataModel result)
        {
            //ErrMsgBox.AppendText($"received string: {result.RxStr}");
            ErrMsgBox.Text += $"received string: {result.RxStr}{Environment.NewLine}";
        }

        private void initializeForm()
        {
            loadAllSettings();
        }

        //private void wireupForms()
        //{
        //    //TODO--implement refresh display
            
        //}

        private void initializeIFconnector()
        {
            //Initialize Tester IF setting
            switch (UserSettings.Default.TesterIFType)
            {
                case "NIGPIB":
                    if (UserSettings.Default.TesterIFProtocol == "MTGPIB8")
                        GlobalIF.InitializeIFConnections(TesterIFType.NIGPIB, TesterIFProtocol.MTGPIB8);
                    if (UserSettings.Default.TesterIFProtocol == "MTGPIB4")
                        GlobalIF.InitializeIFConnections(TesterIFType.NIGPIB, TesterIFProtocol.MTGPIB4);
                    if (UserSettings.Default.TesterIFProtocol == "RSGPIB")
                        GlobalIF.InitializeIFConnections(TesterIFType.NIGPIB, TesterIFProtocol.RSGPIB);
                    break;

                case "RS232":
                    GlobalIF.InitializeIFConnections(TesterIFType.RS232, TesterIFProtocol.RSRS232);
                    break;

                case "TTL":
                    break;

                default:
                    break;
            }
        }

        private void saveAllSettings()
        {
            UserSettings.Default.HandlerAddress = TBoxAddress.Text;
            UserSettings.Default.GpibCardAddress = TBoxGpibCardAddr.Text;
            UserSettings.Default.CommTimeout = TBoxTimeOut.Text;
            //UserSettings.Default.MTDUT_CS1 = TBoxCS1.Text;
            //UserSettings.Default.MTDUT_CS2 = TBoxCS2.Text;
            //UserSettings.Default.MTDUT_CS3 = TBoxCS3.Text;
            //UserSettings.Default.MTDUT_CS4 = TBoxCS4.Text;
            UserSettings.Default.CS_MTDUT = TBoxCS1.Text + TBoxCS2.Text + TBoxCS3.Text + TBoxCS4.Text;
            if (MT8CB.Checked)
                UserSettings.Default.TesterIFProtocol = "MTGPIB8";
            if (DeltaCB.Checked)
                UserSettings.Default.TesterIFProtocol = "RSGPIB";

        }

        private void loadAllSettings()
        {
            TBoxAddress.Text = UserSettings.Default.HandlerAddress;
            TBoxGpibCardAddr.Text = UserSettings.Default.GpibCardAddress;
            TBoxTimeOut.Text = UserSettings.Default.CommTimeout;
            TBoxCS1.Text = UserSettings.Default.CS_MTDUT.Substring(0, 1);
            TBoxCS2.Text = UserSettings.Default.CS_MTDUT.Substring(1, 1);
            TBoxCS3.Text = UserSettings.Default.CS_MTDUT.Substring(2, 1);
            TBoxCS4.Text = UserSettings.Default.CS_MTDUT.Substring(3, 1);
            MT8CB.Checked = (UserSettings.Default.TesterIFProtocol == "MTGPIB8");
            DeltaCB.Checked = (UserSettings.Default.TesterIFProtocol == "RSGPIB");
            //updateMtDUT_CS();
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
            MT8CB.Enabled = false;
        }

        private void enableSettingInput()
        {
            //TBoxAddress.Enabled = true;
            //TBoxGpibCardAddr.Enabled = true;
            TBoxTimeOut.Enabled = true;
            TBoxCS1.Enabled = true;
            TBoxCS2.Enabled = true;
            TBoxCS3.Enabled = true;
            TBoxCS4.Enabled = true;
            DeltaCB.Enabled = true;
            MT8CB.Enabled = true;
        }

        private void MTCB_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CB = (CheckBox)sender;
            if (CB.Checked)
            {
                UserSettings.Default.TesterIFProtocol = "MTGPIB8";
                CB.BackColor = Color.Gold;
                DeltaCB.Checked = false;
                MT4CB.Checked = false;
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

        private void MT4CB_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox CB = (CheckBox)sender;
            if (CB.Checked)
            {
                UserSettings.Default.TesterIFProtocol = "MTGPIB4";
                CB.BackColor = Color.Gold;
                DeltaCB.Checked = false;
                MT8CB.Checked = false;
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
                MT8CB.Checked = false;
                MT4CB.Checked = false;
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



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveAllSettings();
        }

        private bool startPlcPort(out string expMsg)
        {           
            try
            {
                if(!PlcPort.IsOpen)
                    PlcPort.Open();
                GlobalIF.plcTestingConnection.SetPort(PlcPort);
                GlobalIF.TesterIF.SetDUTMapping(UserSettings.Default.CS_MTDUT);
                expMsg = "all good";
                return true;
            }
            catch (Exception exp)
            {
                expMsg = exp.Message;
                return false;
            }
                            

            
            //if (!GpibPort.IsOpen)
            //    GpibPort.Open();
            //GlobalIF.TesterIF.SetPort(GpibPort);
            //GlobalIF.TesterIF.SetResourceName("ASRL" + UserSettings.Default.GpibCardAddress + "::INSTR");
           
        }

        //private void stopAllPorts()
        //{
        //    PlcPort.Close();
        //    GpibPort.Close();
        //}

        /// <summary>
        /// This is test code, simulate SOT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxSendSOT_Click(object sender, EventArgs e)
        {
            if (!PlcPort.IsOpen)
            {
                PlcPort.Open();
            }
            OmronFINsProcessor.GenericWrtPLC(PlcMemArea.WR, "379", "383", "0001"+ tBoxSOT1.Text.PadLeft(4, '0')
                + tBoxSOT2.Text.PadLeft(4, '0') + tBoxSOT3.Text.PadLeft(4, '0') 
                + tBoxSOT4.Text.PadLeft(4, '0'), PlcPort, out string expMsg);
        }

        private void BtnMsgClr_Click(object sender, EventArgs e)
        {
            ErrMsgBox.Clear();
        }
    }
}
