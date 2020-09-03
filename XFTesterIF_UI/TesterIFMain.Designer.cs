namespace XFTesterIF_UI
{
    partial class TesterIFMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TesterIFMain));
            this.PlcPort = new System.IO.Ports.SerialPort(this.components);
            this.GpibPort = new System.IO.Ports.SerialPort(this.components);
            this.btnGpibON = new System.Windows.Forms.Button();
            this.btnGpibOFF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelOFF = new System.Windows.Forms.Label();
            this.LabelON = new System.Windows.Forms.Label();
            this.MT8CB = new System.Windows.Forms.CheckBox();
            this.DeltaCB = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTiP = new System.Windows.Forms.Label();
            this.LabelBIN3 = new System.Windows.Forms.Label();
            this.LabelBIN2 = new System.Windows.Forms.Label();
            this.LabelBIN1 = new System.Windows.Forms.Label();
            this.progressBarCS3 = new System.Windows.Forms.ProgressBar();
            this.LabelBIN4 = new System.Windows.Forms.Label();
            this.progressBarCS4 = new System.Windows.Forms.ProgressBar();
            this.progressBarCS1 = new System.Windows.Forms.ProgressBar();
            this.progressBarCS2 = new System.Windows.Forms.ProgressBar();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TBoxGpibCardAddr = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.TBoxTimeOut = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.TBoxAddress = new System.Windows.Forms.TextBox();
            this.BtnMsgClr = new System.Windows.Forms.Button();
            this.ErrMsgBox = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tBoxSOT1 = new System.Windows.Forms.TextBox();
            this.tBoxSOT2 = new System.Windows.Forms.TextBox();
            this.tBoxSOT4 = new System.Windows.Forms.TextBox();
            this.tBoxSOT3 = new System.Windows.Forms.TextBox();
            this.tBoxSendSOT = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.TBoxCS1 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TBoxCS4 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.TBoxCS2 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.TBoxCS3 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MT4CB = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PlcPort
            // 
            this.PlcPort.DataBits = 7;
            this.PlcPort.Parity = System.IO.Ports.Parity.Even;
            this.PlcPort.PortName = "COM4";
            this.PlcPort.StopBits = System.IO.Ports.StopBits.Two;
            // 
            // GpibPort
            // 
            this.GpibPort.PortName = "COM7";
            // 
            // btnGpibON
            // 
            this.btnGpibON.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGpibON.Location = new System.Drawing.Point(12, 9);
            this.btnGpibON.Name = "btnGpibON";
            this.btnGpibON.Size = new System.Drawing.Size(186, 75);
            this.btnGpibON.TabIndex = 0;
            this.btnGpibON.Text = "GPIB ON";
            this.btnGpibON.UseVisualStyleBackColor = true;
            this.btnGpibON.Click += new System.EventHandler(this.btnGpibON_Click);
            // 
            // btnGpibOFF
            // 
            this.btnGpibOFF.Location = new System.Drawing.Point(238, 9);
            this.btnGpibOFF.Name = "btnGpibOFF";
            this.btnGpibOFF.Size = new System.Drawing.Size(184, 75);
            this.btnGpibOFF.TabIndex = 1;
            this.btnGpibOFF.Text = "GPIB OFF";
            this.btnGpibOFF.UseVisualStyleBackColor = true;
            this.btnGpibOFF.Click += new System.EventHandler(this.btnGpibOFF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "GPIB is";
            // 
            // LabelOFF
            // 
            this.LabelOFF.AutoSize = true;
            this.LabelOFF.BackColor = System.Drawing.Color.Tomato;
            this.LabelOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOFF.Location = new System.Drawing.Point(575, 19);
            this.LabelOFF.Name = "LabelOFF";
            this.LabelOFF.Size = new System.Drawing.Size(169, 40);
            this.LabelOFF.TabIndex = 76;
            this.LabelOFF.Text = "    OFF   ";
            // 
            // LabelON
            // 
            this.LabelON.AutoSize = true;
            this.LabelON.BackColor = System.Drawing.Color.Lime;
            this.LabelON.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelON.Location = new System.Drawing.Point(575, 19);
            this.LabelON.Name = "LabelON";
            this.LabelON.Size = new System.Drawing.Size(161, 40);
            this.LabelON.TabIndex = 77;
            this.LabelON.Text = "    ON    ";
            this.LabelON.Visible = false;
            // 
            // MT8CB
            // 
            this.MT8CB.Appearance = System.Windows.Forms.Appearance.Button;
            this.MT8CB.BackColor = System.Drawing.Color.Gold;
            this.MT8CB.Checked = true;
            this.MT8CB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MT8CB.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.MT8CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MT8CB.Location = new System.Drawing.Point(531, 575);
            this.MT8CB.Name = "MT8CB";
            this.MT8CB.Size = new System.Drawing.Size(107, 89);
            this.MT8CB.TabIndex = 81;
            this.MT8CB.Text = "XuFeng\r\n(MT8)";
            this.MT8CB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MT8CB.UseVisualStyleBackColor = false;
            this.MT8CB.CheckedChanged += new System.EventHandler(this.MTCB_CheckedChanged);
            this.MT8CB.Click += new System.EventHandler(this.MTCB_CheckedChanged);
            // 
            // DeltaCB
            // 
            this.DeltaCB.Appearance = System.Windows.Forms.Appearance.Button;
            this.DeltaCB.BackColor = System.Drawing.Color.LightGray;
            this.DeltaCB.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.DeltaCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeltaCB.Location = new System.Drawing.Point(789, 575);
            this.DeltaCB.Name = "DeltaCB";
            this.DeltaCB.Size = new System.Drawing.Size(107, 89);
            this.DeltaCB.TabIndex = 80;
            this.DeltaCB.Text = "XuFeng\r\n(RS)";
            this.DeltaCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DeltaCB.UseVisualStyleBackColor = false;
            this.DeltaCB.CheckedChanged += new System.EventHandler(this.DeltaCB_CheckedChanged);
            this.DeltaCB.Click += new System.EventHandler(this.DeltaCB_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTiP);
            this.groupBox2.Controls.Add(this.LabelBIN3);
            this.groupBox2.Controls.Add(this.LabelBIN2);
            this.groupBox2.Controls.Add(this.LabelBIN1);
            this.groupBox2.Controls.Add(this.progressBarCS3);
            this.groupBox2.Controls.Add(this.LabelBIN4);
            this.groupBox2.Controls.Add(this.progressBarCS4);
            this.groupBox2.Controls.Add(this.progressBarCS1);
            this.groupBox2.Controls.Add(this.progressBarCS2);
            this.groupBox2.Controls.Add(this.pictureBox5);
            this.groupBox2.Controls.Add(this.pictureBox6);
            this.groupBox2.Controls.Add(this.pictureBox8);
            this.groupBox2.Controls.Add(this.pictureBox7);
            this.groupBox2.Location = new System.Drawing.Point(26, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 285);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BIN result";
            // 
            // lblTiP
            // 
            this.lblTiP.AutoSize = true;
            this.lblTiP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiP.ForeColor = System.Drawing.Color.Blue;
            this.lblTiP.Location = new System.Drawing.Point(86, 33);
            this.lblTiP.Name = "lblTiP";
            this.lblTiP.Size = new System.Drawing.Size(240, 29);
            this.lblTiP.TabIndex = 130;
            this.lblTiP.Text = "Testing in progress";
            this.lblTiP.Visible = false;
            // 
            // LabelBIN3
            // 
            this.LabelBIN3.BackColor = System.Drawing.Color.Lime;
            this.LabelBIN3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBIN3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LabelBIN3.Location = new System.Drawing.Point(40, 92);
            this.LabelBIN3.Name = "LabelBIN3";
            this.LabelBIN3.Size = new System.Drawing.Size(100, 55);
            this.LabelBIN3.TabIndex = 132;
            this.LabelBIN3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelBIN3.Visible = false;
            // 
            // LabelBIN2
            // 
            this.LabelBIN2.BackColor = System.Drawing.Color.Lime;
            this.LabelBIN2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBIN2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LabelBIN2.Location = new System.Drawing.Point(204, 199);
            this.LabelBIN2.Name = "LabelBIN2";
            this.LabelBIN2.Size = new System.Drawing.Size(100, 55);
            this.LabelBIN2.TabIndex = 149;
            this.LabelBIN2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelBIN2.Visible = false;
            // 
            // LabelBIN1
            // 
            this.LabelBIN1.BackColor = System.Drawing.Color.Lime;
            this.LabelBIN1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBIN1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LabelBIN1.Location = new System.Drawing.Point(40, 199);
            this.LabelBIN1.Name = "LabelBIN1";
            this.LabelBIN1.Size = new System.Drawing.Size(100, 55);
            this.LabelBIN1.TabIndex = 148;
            this.LabelBIN1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelBIN1.Visible = false;
            // 
            // progressBarCS3
            // 
            this.progressBarCS3.Location = new System.Drawing.Point(40, 92);
            this.progressBarCS3.Name = "progressBarCS3";
            this.progressBarCS3.Size = new System.Drawing.Size(100, 55);
            this.progressBarCS3.TabIndex = 127;
            // 
            // LabelBIN4
            // 
            this.LabelBIN4.BackColor = System.Drawing.Color.Lime;
            this.LabelBIN4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBIN4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LabelBIN4.Location = new System.Drawing.Point(204, 94);
            this.LabelBIN4.Name = "LabelBIN4";
            this.LabelBIN4.Size = new System.Drawing.Size(100, 55);
            this.LabelBIN4.TabIndex = 147;
            this.LabelBIN4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelBIN4.Visible = false;
            // 
            // progressBarCS4
            // 
            this.progressBarCS4.Location = new System.Drawing.Point(204, 94);
            this.progressBarCS4.Name = "progressBarCS4";
            this.progressBarCS4.Size = new System.Drawing.Size(100, 55);
            this.progressBarCS4.TabIndex = 130;
            // 
            // progressBarCS1
            // 
            this.progressBarCS1.Location = new System.Drawing.Point(40, 199);
            this.progressBarCS1.Name = "progressBarCS1";
            this.progressBarCS1.Size = new System.Drawing.Size(100, 55);
            this.progressBarCS1.TabIndex = 151;
            // 
            // progressBarCS2
            // 
            this.progressBarCS2.Location = new System.Drawing.Point(204, 199);
            this.progressBarCS2.Name = "progressBarCS2";
            this.progressBarCS2.Size = new System.Drawing.Size(100, 55);
            this.progressBarCS2.TabIndex = 150;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox5.Location = new System.Drawing.Point(16, 178);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(144, 95);
            this.pictureBox5.TabIndex = 143;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox6.Location = new System.Drawing.Point(180, 178);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(144, 95);
            this.pictureBox6.TabIndex = 144;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox8.Location = new System.Drawing.Point(16, 73);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(144, 95);
            this.pictureBox8.TabIndex = 146;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox7.Location = new System.Drawing.Point(180, 74);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(144, 95);
            this.pictureBox7.TabIndex = 145;
            this.pictureBox7.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(529, 531);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(146, 29);
            this.label16.TabIndex = 92;
            this.label16.Text = "GPIB IF Port";
            // 
            // TBoxGpibCardAddr
            // 
            this.TBoxGpibCardAddr.Enabled = false;
            this.TBoxGpibCardAddr.Location = new System.Drawing.Point(806, 528);
            this.TBoxGpibCardAddr.Name = "TBoxGpibCardAddr";
            this.TBoxGpibCardAddr.Size = new System.Drawing.Size(56, 35);
            this.TBoxGpibCardAddr.TabIndex = 91;
            this.TBoxGpibCardAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxGpibCardAddr.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(867, 477);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 32);
            this.label28.TabIndex = 89;
            this.label28.Text = "s";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(529, 485);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(169, 29);
            this.label27.TabIndex = 88;
            this.label27.Text = "Comm timeout";
            // 
            // TBoxTimeOut
            // 
            this.TBoxTimeOut.Location = new System.Drawing.Point(806, 478);
            this.TBoxTimeOut.Name = "TBoxTimeOut";
            this.TBoxTimeOut.Size = new System.Drawing.Size(56, 35);
            this.TBoxTimeOut.TabIndex = 87;
            this.TBoxTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxTimeOut.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(529, 429);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(193, 29);
            this.label26.TabIndex = 86;
            this.label26.Text = "Handler Address";
            // 
            // TBoxAddress
            // 
            this.TBoxAddress.Enabled = false;
            this.TBoxAddress.Location = new System.Drawing.Point(806, 429);
            this.TBoxAddress.Name = "TBoxAddress";
            this.TBoxAddress.Size = new System.Drawing.Size(56, 35);
            this.TBoxAddress.TabIndex = 85;
            this.TBoxAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxAddress.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // BtnMsgClr
            // 
            this.BtnMsgClr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMsgClr.Location = new System.Drawing.Point(369, 401);
            this.BtnMsgClr.Name = "BtnMsgClr";
            this.BtnMsgClr.Size = new System.Drawing.Size(118, 42);
            this.BtnMsgClr.TabIndex = 124;
            this.BtnMsgClr.Text = "Clear";
            this.BtnMsgClr.Click += new System.EventHandler(this.BtnMsgClr_Click);
            // 
            // ErrMsgBox
            // 
            this.ErrMsgBox.Location = new System.Drawing.Point(26, 446);
            this.ErrMsgBox.Multiline = true;
            this.ErrMsgBox.Name = "ErrMsgBox";
            this.ErrMsgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ErrMsgBox.Size = new System.Drawing.Size(461, 218);
            this.ErrMsgBox.TabIndex = 123;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(35, 406);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(197, 29);
            this.label30.TabIndex = 122;
            this.label30.Text = "System Message";
            // 
            // tBoxSOT1
            // 
            this.tBoxSOT1.Location = new System.Drawing.Point(375, 195);
            this.tBoxSOT1.Name = "tBoxSOT1";
            this.tBoxSOT1.Size = new System.Drawing.Size(56, 35);
            this.tBoxSOT1.TabIndex = 125;
            this.tBoxSOT1.Text = "0";
            this.tBoxSOT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxSOT1.Visible = false;
            // 
            // tBoxSOT2
            // 
            this.tBoxSOT2.Location = new System.Drawing.Point(461, 195);
            this.tBoxSOT2.Name = "tBoxSOT2";
            this.tBoxSOT2.Size = new System.Drawing.Size(56, 35);
            this.tBoxSOT2.TabIndex = 126;
            this.tBoxSOT2.Text = "0";
            this.tBoxSOT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxSOT2.Visible = false;
            // 
            // tBoxSOT4
            // 
            this.tBoxSOT4.Location = new System.Drawing.Point(461, 138);
            this.tBoxSOT4.Name = "tBoxSOT4";
            this.tBoxSOT4.Size = new System.Drawing.Size(56, 35);
            this.tBoxSOT4.TabIndex = 127;
            this.tBoxSOT4.Text = "0";
            this.tBoxSOT4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxSOT4.Visible = false;
            // 
            // tBoxSOT3
            // 
            this.tBoxSOT3.Location = new System.Drawing.Point(375, 138);
            this.tBoxSOT3.Name = "tBoxSOT3";
            this.tBoxSOT3.Size = new System.Drawing.Size(56, 35);
            this.tBoxSOT3.TabIndex = 128;
            this.tBoxSOT3.Text = "0";
            this.tBoxSOT3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxSOT3.Visible = false;
            // 
            // tBoxSendSOT
            // 
            this.tBoxSendSOT.Location = new System.Drawing.Point(386, 251);
            this.tBoxSendSOT.Name = "tBoxSendSOT";
            this.tBoxSendSOT.Size = new System.Drawing.Size(103, 38);
            this.tBoxSendSOT.TabIndex = 129;
            this.tBoxSendSOT.Text = "SOT";
            this.tBoxSendSOT.UseVisualStyleBackColor = true;
            this.tBoxSendSOT.Visible = false;
            this.tBoxSendSOT.Click += new System.EventHandler(this.tBoxSendSOT_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox4.Location = new System.Drawing.Point(20, 151);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(144, 95);
            this.pictureBox4.TabIndex = 110;
            this.pictureBox4.TabStop = false;
            // 
            // TBoxCS1
            // 
            this.TBoxCS1.Enabled = false;
            this.TBoxCS1.Location = new System.Drawing.Point(94, 160);
            this.TBoxCS1.Name = "TBoxCS1";
            this.TBoxCS1.Size = new System.Drawing.Size(48, 32);
            this.TBoxCS1.TabIndex = 108;
            this.TBoxCS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxCS1.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.SystemColors.Info;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(23, 203);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(69, 29);
            this.label37.TabIndex = 109;
            this.label37.Text = "CS 1";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.SystemColors.Info;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(23, 161);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(66, 29);
            this.label36.TabIndex = 111;
            this.label36.Text = "DUT";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox2.Location = new System.Drawing.Point(168, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(144, 95);
            this.pictureBox2.TabIndex = 118;
            this.pictureBox2.TabStop = false;
            // 
            // TBoxCS4
            // 
            this.TBoxCS4.Enabled = false;
            this.TBoxCS4.Location = new System.Drawing.Point(245, 62);
            this.TBoxCS4.Name = "TBoxCS4";
            this.TBoxCS4.Size = new System.Drawing.Size(48, 32);
            this.TBoxCS4.TabIndex = 116;
            this.TBoxCS4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxCS4.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.SystemColors.Info;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(170, 105);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(69, 29);
            this.label31.TabIndex = 117;
            this.label31.Text = "CS 4";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.SystemColors.Info;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(171, 62);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(66, 29);
            this.label29.TabIndex = 119;
            this.label29.Text = "DUT";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox3.Location = new System.Drawing.Point(168, 150);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(144, 95);
            this.pictureBox3.TabIndex = 122;
            this.pictureBox3.TabStop = false;
            // 
            // TBoxCS2
            // 
            this.TBoxCS2.Enabled = false;
            this.TBoxCS2.Location = new System.Drawing.Point(245, 161);
            this.TBoxCS2.Name = "TBoxCS2";
            this.TBoxCS2.Size = new System.Drawing.Size(48, 32);
            this.TBoxCS2.TabIndex = 120;
            this.TBoxCS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxCS2.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.SystemColors.Info;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(171, 203);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(69, 29);
            this.label35.TabIndex = 121;
            this.label35.Text = "CS 2";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.SystemColors.Info;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(174, 161);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(66, 29);
            this.label33.TabIndex = 123;
            this.label33.Text = "DUT";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.TBoxCS2);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.TBoxCS4);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.TBoxCS3);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.TBoxCS1);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(531, 103);
            this.groupBox1.MaximumSize = new System.Drawing.Size(550, 400);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 273);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DUT Mapping";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.Info;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(23, 62);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 29);
            this.label22.TabIndex = 115;
            this.label22.Text = "DUT";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.SystemColors.Info;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(23, 105);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(69, 29);
            this.label25.TabIndex = 113;
            this.label25.Text = "CS 3";
            // 
            // TBoxCS3
            // 
            this.TBoxCS3.Enabled = false;
            this.TBoxCS3.Location = new System.Drawing.Point(94, 61);
            this.TBoxCS3.Name = "TBoxCS3";
            this.TBoxCS3.Size = new System.Drawing.Size(48, 32);
            this.TBoxCS3.TabIndex = 112;
            this.TBoxCS3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox1.Location = new System.Drawing.Point(18, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 114;
            this.pictureBox1.TabStop = false;
            // 
            // MT4CB
            // 
            this.MT4CB.Appearance = System.Windows.Forms.Appearance.Button;
            this.MT4CB.BackColor = System.Drawing.Color.LightGray;
            this.MT4CB.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.MT4CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MT4CB.Location = new System.Drawing.Point(661, 575);
            this.MT4CB.Name = "MT4CB";
            this.MT4CB.Size = new System.Drawing.Size(107, 89);
            this.MT4CB.TabIndex = 130;
            this.MT4CB.Text = "XuFeng\r\n(MT4)";
            this.MT4CB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MT4CB.UseVisualStyleBackColor = false;
            this.MT4CB.CheckedChanged += new System.EventHandler(this.MT4CB_CheckedChanged);
            // 
            // TesterIFMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(978, 744);
            this.Controls.Add(this.MT4CB);
            this.Controls.Add(this.tBoxSendSOT);
            this.Controls.Add(this.tBoxSOT3);
            this.Controls.Add(this.tBoxSOT4);
            this.Controls.Add(this.tBoxSOT2);
            this.Controls.Add(this.tBoxSOT1);
            this.Controls.Add(this.BtnMsgClr);
            this.Controls.Add(this.ErrMsgBox);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.TBoxGpibCardAddr);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.TBoxTimeOut);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.TBoxAddress);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MT8CB);
            this.Controls.Add(this.DeltaCB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LabelON);
            this.Controls.Add(this.LabelOFF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGpibOFF);
            this.Controls.Add(this.btnGpibON);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "TesterIFMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPIB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort PlcPort;
        private System.IO.Ports.SerialPort GpibPort;
        private System.Windows.Forms.Button btnGpibON;
        private System.Windows.Forms.Button btnGpibOFF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelOFF;
        private System.Windows.Forms.Label LabelON;
        private System.Windows.Forms.CheckBox MT8CB;
        private System.Windows.Forms.CheckBox DeltaCB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LabelBIN3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TBoxGpibCardAddr;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox TBoxTimeOut;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox TBoxAddress;
        private System.Windows.Forms.Button BtnMsgClr;
        private System.Windows.Forms.TextBox ErrMsgBox;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ProgressBar progressBarCS3;
        private System.Windows.Forms.Label LabelBIN2;
        private System.Windows.Forms.Label LabelBIN1;
        private System.Windows.Forms.Label LabelBIN4;
        private System.Windows.Forms.ProgressBar progressBarCS4;
        private System.Windows.Forms.ProgressBar progressBarCS1;
        private System.Windows.Forms.ProgressBar progressBarCS2;
        private System.Windows.Forms.TextBox tBoxSOT1;
        private System.Windows.Forms.TextBox tBoxSOT2;
        private System.Windows.Forms.TextBox tBoxSOT4;
        private System.Windows.Forms.TextBox tBoxSOT3;
        private System.Windows.Forms.Button tBoxSendSOT;
        private System.Windows.Forms.Label lblTiP;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox TBoxCS1;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox TBoxCS4;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox TBoxCS2;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox TBoxCS3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox MT4CB;
    }
}

