namespace XFTesterIF_UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PlcPort = new System.IO.Ports.SerialPort(this.components);
            this.GpibPort = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnGpibON = new System.Windows.Forms.Button();
            this.btnGpibOFF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelOFF = new System.Windows.Forms.Label();
            this.LabelON = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.TBoxCS2 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TBoxCS4 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.TBoxCS3 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.TBoxCS1 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MTCB = new System.Windows.Forms.CheckBox();
            this.DeltaCB = new System.Windows.Forms.CheckBox();
            this.NoTermCB = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LabelColorBIN4 = new System.Windows.Forms.Label();
            this.LabelColorBIN3 = new System.Windows.Forms.Label();
            this.LabelColorBIN2 = new System.Windows.Forms.Label();
            this.LabelColorBIN1 = new System.Windows.Forms.Label();
            this.LabelSOT4 = new System.Windows.Forms.Label();
            this.LabelSOT3 = new System.Windows.Forms.Label();
            this.LabelSOT2 = new System.Windows.Forms.Label();
            this.LabelSOT1 = new System.Windows.Forms.Label();
            this.LabelBIN1 = new System.Windows.Forms.Label();
            this.LabelBIN2 = new System.Windows.Forms.Label();
            this.LabelBIN3 = new System.Windows.Forms.Label();
            this.LabelBIN4 = new System.Windows.Forms.Label();
            this.TBoxSOT4 = new System.Windows.Forms.TextBox();
            this.TBoxSOT3 = new System.Windows.Forms.TextBox();
            this.TBoxSOT2 = new System.Windows.Forms.TextBox();
            this.TBoxSOT1 = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TBoxGpibCardAddr = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.TBoxTimeOut = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.TBoxAddress = new System.Windows.Forms.TextBox();
            this.BtnMsgClr = new System.Windows.Forms.Button();
            this.ErrMsgBox = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // PlcPort
            // 
            this.PlcPort.BaudRate = 115200;
            this.PlcPort.DataBits = 7;
            this.PlcPort.Parity = System.IO.Ports.Parity.Even;
            this.PlcPort.PortName = "COM4";
            this.PlcPort.StopBits = System.IO.Ports.StopBits.Two;
            // 
            // GpibPort
            // 
            this.GpibPort.PortName = "COM3";
            // 
            // btnGpibON
            // 
            this.btnGpibON.Location = new System.Drawing.Point(12, 9);
            this.btnGpibON.Name = "btnGpibON";
            this.btnGpibON.Size = new System.Drawing.Size(158, 75);
            this.btnGpibON.TabIndex = 0;
            this.btnGpibON.Text = "GPIB ON";
            this.btnGpibON.UseVisualStyleBackColor = true;
            this.btnGpibON.Click += new System.EventHandler(this.btnGpibON_Click);
            // 
            // btnGpibOFF
            // 
            this.btnGpibOFF.Location = new System.Drawing.Point(176, 9);
            this.btnGpibOFF.Name = "btnGpibOFF";
            this.btnGpibOFF.Size = new System.Drawing.Size(158, 75);
            this.btnGpibOFF.TabIndex = 1;
            this.btnGpibOFF.Text = "GPIB OFF";
            this.btnGpibOFF.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(564, 32);
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
            this.LabelOFF.Location = new System.Drawing.Point(690, 32);
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
            this.LabelON.Location = new System.Drawing.Point(690, 32);
            this.LabelON.Name = "LabelON";
            this.LabelON.Size = new System.Drawing.Size(161, 40);
            this.LabelON.TabIndex = 77;
            this.LabelON.Text = "    ON    ";
            this.LabelON.Visible = false;
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
            this.groupBox1.Location = new System.Drawing.Point(640, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 300);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DUT Mapping (MT Octal Mode)";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.SystemColors.Info;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(222, 170);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(96, 58);
            this.label33.TabIndex = 123;
            this.label33.Text = "Tester \r\n  DUT";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.SystemColors.Info;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(214, 247);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(168, 29);
            this.label35.TabIndex = 121;
            this.label35.Text = "Handler CS 2";
            // 
            // TBoxCS2
            // 
            this.TBoxCS2.Enabled = false;
            this.TBoxCS2.Location = new System.Drawing.Point(325, 193);
            this.TBoxCS2.Name = "TBoxCS2";
            this.TBoxCS2.Size = new System.Drawing.Size(48, 32);
            this.TBoxCS2.TabIndex = 120;
            this.TBoxCS2.Text = "5";
            this.TBoxCS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxCS2.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox3.Location = new System.Drawing.Point(211, 164);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(184, 121);
            this.pictureBox3.TabIndex = 122;
            this.pictureBox3.TabStop = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.SystemColors.Info;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(222, 41);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 58);
            this.label29.TabIndex = 119;
            this.label29.Text = "Tester \r\n  DUT";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.SystemColors.Info;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(214, 118);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(168, 29);
            this.label31.TabIndex = 117;
            this.label31.Text = "Handler CS 4";
            // 
            // TBoxCS4
            // 
            this.TBoxCS4.Enabled = false;
            this.TBoxCS4.Location = new System.Drawing.Point(325, 64);
            this.TBoxCS4.Name = "TBoxCS4";
            this.TBoxCS4.Size = new System.Drawing.Size(48, 32);
            this.TBoxCS4.TabIndex = 116;
            this.TBoxCS4.Text = "1";
            this.TBoxCS4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxCS4.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox2.Location = new System.Drawing.Point(211, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(184, 121);
            this.pictureBox2.TabIndex = 118;
            this.pictureBox2.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.Info;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(24, 41);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(96, 58);
            this.label22.TabIndex = 115;
            this.label22.Text = "Tester \r\n  DUT";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.SystemColors.Info;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(16, 118);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(168, 29);
            this.label25.TabIndex = 113;
            this.label25.Text = "Handler CS 3";
            // 
            // TBoxCS3
            // 
            this.TBoxCS3.Enabled = false;
            this.TBoxCS3.Location = new System.Drawing.Point(127, 64);
            this.TBoxCS3.Name = "TBoxCS3";
            this.TBoxCS3.Size = new System.Drawing.Size(48, 32);
            this.TBoxCS3.TabIndex = 112;
            this.TBoxCS3.Text = "2";
            this.TBoxCS3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxCS3.Click += new System.EventHandler(this.TextBoxClick);
            this.TBoxCS3.TextChanged += new System.EventHandler(this.TBox_TextChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.SystemColors.Info;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(24, 170);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(96, 58);
            this.label36.TabIndex = 111;
            this.label36.Text = "Tester \r\n  DUT";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.SystemColors.Info;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(16, 247);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(168, 29);
            this.label37.TabIndex = 109;
            this.label37.Text = "Handler CS 1";
            // 
            // TBoxCS1
            // 
            this.TBoxCS1.Enabled = false;
            this.TBoxCS1.Location = new System.Drawing.Point(127, 193);
            this.TBoxCS1.Name = "TBoxCS1";
            this.TBoxCS1.Size = new System.Drawing.Size(48, 32);
            this.TBoxCS1.TabIndex = 108;
            this.TBoxCS1.Text = "6";
            this.TBoxCS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxCS1.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox4.Location = new System.Drawing.Point(12, 164);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(184, 121);
            this.pictureBox4.TabIndex = 110;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox1.Location = new System.Drawing.Point(12, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 121);
            this.pictureBox1.TabIndex = 114;
            this.pictureBox1.TabStop = false;
            // 
            // MTCB
            // 
            this.MTCB.Appearance = System.Windows.Forms.Appearance.Button;
            this.MTCB.BackColor = System.Drawing.Color.Gold;
            this.MTCB.Checked = true;
            this.MTCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MTCB.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.MTCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MTCB.Location = new System.Drawing.Point(662, 664);
            this.MTCB.Name = "MTCB";
            this.MTCB.Size = new System.Drawing.Size(141, 75);
            this.MTCB.TabIndex = 81;
            this.MTCB.Text = "XuFeng\r\n(MT)";
            this.MTCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MTCB.UseVisualStyleBackColor = false;
            this.MTCB.CheckedChanged += new System.EventHandler(this.MTCB_CheckedChanged);
            this.MTCB.Click += new System.EventHandler(this.MTCB_CheckedChanged);
            // 
            // DeltaCB
            // 
            this.DeltaCB.Appearance = System.Windows.Forms.Appearance.Button;
            this.DeltaCB.BackColor = System.Drawing.Color.LightGray;
            this.DeltaCB.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.DeltaCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeltaCB.Location = new System.Drawing.Point(808, 663);
            this.DeltaCB.Name = "DeltaCB";
            this.DeltaCB.Size = new System.Drawing.Size(129, 78);
            this.DeltaCB.TabIndex = 80;
            this.DeltaCB.Text = "XuFeng\r\n(RS)";
            this.DeltaCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DeltaCB.UseVisualStyleBackColor = false;
            this.DeltaCB.CheckedChanged += new System.EventHandler(this.DeltaCB_CheckedChanged);
            this.DeltaCB.Click += new System.EventHandler(this.DeltaCB_CheckedChanged);
            // 
            // NoTermCB
            // 
            this.NoTermCB.Appearance = System.Windows.Forms.Appearance.Button;
            this.NoTermCB.BackColor = System.Drawing.Color.Gold;
            this.NoTermCB.Checked = true;
            this.NoTermCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NoTermCB.Enabled = false;
            this.NoTermCB.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.NoTermCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoTermCB.Location = new System.Drawing.Point(961, 663);
            this.NoTermCB.Name = "NoTermCB";
            this.NoTermCB.Size = new System.Drawing.Size(144, 78);
            this.NoTermCB.TabIndex = 79;
            this.NoTermCB.Text = "No Term";
            this.NoTermCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NoTermCB.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(657, 622);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 29);
            this.label2.TabIndex = 82;
            this.label2.Text = "Protocol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(963, 622);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 29);
            this.label3.TabIndex = 83;
            this.label3.Text = "Termination";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LabelColorBIN4);
            this.groupBox2.Controls.Add(this.LabelColorBIN3);
            this.groupBox2.Controls.Add(this.LabelColorBIN2);
            this.groupBox2.Controls.Add(this.LabelColorBIN1);
            this.groupBox2.Controls.Add(this.LabelSOT4);
            this.groupBox2.Controls.Add(this.LabelSOT3);
            this.groupBox2.Controls.Add(this.LabelSOT2);
            this.groupBox2.Controls.Add(this.LabelSOT1);
            this.groupBox2.Controls.Add(this.LabelBIN1);
            this.groupBox2.Controls.Add(this.LabelBIN2);
            this.groupBox2.Controls.Add(this.LabelBIN3);
            this.groupBox2.Controls.Add(this.LabelBIN4);
            this.groupBox2.Controls.Add(this.TBoxSOT4);
            this.groupBox2.Controls.Add(this.TBoxSOT3);
            this.groupBox2.Controls.Add(this.TBoxSOT2);
            this.groupBox2.Controls.Add(this.TBoxSOT1);
            this.groupBox2.Controls.Add(this.pictureBox5);
            this.groupBox2.Controls.Add(this.pictureBox6);
            this.groupBox2.Controls.Add(this.pictureBox8);
            this.groupBox2.Controls.Add(this.pictureBox7);
            this.groupBox2.Location = new System.Drawing.Point(26, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 300);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Last BIN";
            // 
            // LabelColorBIN4
            // 
            this.LabelColorBIN4.AutoSize = true;
            this.LabelColorBIN4.BackColor = System.Drawing.Color.Lime;
            this.LabelColorBIN4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelColorBIN4.Location = new System.Drawing.Point(208, 130);
            this.LabelColorBIN4.Name = "LabelColorBIN4";
            this.LabelColorBIN4.Size = new System.Drawing.Size(55, 29);
            this.LabelColorBIN4.TabIndex = 142;
            this.LabelColorBIN4.Text = "      ";
            this.LabelColorBIN4.Visible = false;
            // 
            // LabelColorBIN3
            // 
            this.LabelColorBIN3.AutoSize = true;
            this.LabelColorBIN3.BackColor = System.Drawing.Color.Lime;
            this.LabelColorBIN3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelColorBIN3.Location = new System.Drawing.Point(43, 128);
            this.LabelColorBIN3.Name = "LabelColorBIN3";
            this.LabelColorBIN3.Size = new System.Drawing.Size(55, 29);
            this.LabelColorBIN3.TabIndex = 141;
            this.LabelColorBIN3.Text = "      ";
            this.LabelColorBIN3.Visible = false;
            // 
            // LabelColorBIN2
            // 
            this.LabelColorBIN2.AutoSize = true;
            this.LabelColorBIN2.BackColor = System.Drawing.Color.Lime;
            this.LabelColorBIN2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelColorBIN2.Location = new System.Drawing.Point(208, 230);
            this.LabelColorBIN2.Name = "LabelColorBIN2";
            this.LabelColorBIN2.Size = new System.Drawing.Size(55, 29);
            this.LabelColorBIN2.TabIndex = 140;
            this.LabelColorBIN2.Text = "      ";
            this.LabelColorBIN2.Visible = false;
            // 
            // LabelColorBIN1
            // 
            this.LabelColorBIN1.AutoSize = true;
            this.LabelColorBIN1.BackColor = System.Drawing.Color.Lime;
            this.LabelColorBIN1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelColorBIN1.Location = new System.Drawing.Point(42, 230);
            this.LabelColorBIN1.Name = "LabelColorBIN1";
            this.LabelColorBIN1.Size = new System.Drawing.Size(55, 29);
            this.LabelColorBIN1.TabIndex = 139;
            this.LabelColorBIN1.Text = "      ";
            this.LabelColorBIN1.Visible = false;
            // 
            // LabelSOT4
            // 
            this.LabelSOT4.AutoSize = true;
            this.LabelSOT4.BackColor = System.Drawing.Color.Lime;
            this.LabelSOT4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSOT4.Location = new System.Drawing.Point(210, 86);
            this.LabelSOT4.Name = "LabelSOT4";
            this.LabelSOT4.Size = new System.Drawing.Size(52, 22);
            this.LabelSOT4.TabIndex = 138;
            this.LabelSOT4.Text = "       ";
            this.LabelSOT4.Visible = false;
            // 
            // LabelSOT3
            // 
            this.LabelSOT3.AutoSize = true;
            this.LabelSOT3.BackColor = System.Drawing.Color.Lime;
            this.LabelSOT3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSOT3.Location = new System.Drawing.Point(42, 86);
            this.LabelSOT3.Name = "LabelSOT3";
            this.LabelSOT3.Size = new System.Drawing.Size(52, 22);
            this.LabelSOT3.TabIndex = 137;
            this.LabelSOT3.Text = "       ";
            this.LabelSOT3.Visible = false;
            // 
            // LabelSOT2
            // 
            this.LabelSOT2.AutoSize = true;
            this.LabelSOT2.BackColor = System.Drawing.Color.Lime;
            this.LabelSOT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSOT2.Location = new System.Drawing.Point(210, 191);
            this.LabelSOT2.Name = "LabelSOT2";
            this.LabelSOT2.Size = new System.Drawing.Size(52, 22);
            this.LabelSOT2.TabIndex = 136;
            this.LabelSOT2.Text = "       ";
            this.LabelSOT2.Visible = false;
            // 
            // LabelSOT1
            // 
            this.LabelSOT1.AutoSize = true;
            this.LabelSOT1.BackColor = System.Drawing.Color.Lime;
            this.LabelSOT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSOT1.Location = new System.Drawing.Point(44, 191);
            this.LabelSOT1.Name = "LabelSOT1";
            this.LabelSOT1.Size = new System.Drawing.Size(52, 22);
            this.LabelSOT1.TabIndex = 135;
            this.LabelSOT1.Text = "       ";
            this.LabelSOT1.Visible = false;
            // 
            // LabelBIN1
            // 
            this.LabelBIN1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelBIN1.Location = new System.Drawing.Point(40, 230);
            this.LabelBIN1.Name = "LabelBIN1";
            this.LabelBIN1.Size = new System.Drawing.Size(80, 31);
            this.LabelBIN1.TabIndex = 134;
            this.LabelBIN1.Text = "0000";
            this.LabelBIN1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelBIN2
            // 
            this.LabelBIN2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelBIN2.Location = new System.Drawing.Point(206, 230);
            this.LabelBIN2.Name = "LabelBIN2";
            this.LabelBIN2.Size = new System.Drawing.Size(80, 31);
            this.LabelBIN2.TabIndex = 133;
            this.LabelBIN2.Text = "0000";
            this.LabelBIN2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelBIN3
            // 
            this.LabelBIN3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelBIN3.Location = new System.Drawing.Point(41, 128);
            this.LabelBIN3.Name = "LabelBIN3";
            this.LabelBIN3.Size = new System.Drawing.Size(80, 30);
            this.LabelBIN3.TabIndex = 132;
            this.LabelBIN3.Text = "0000";
            this.LabelBIN3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelBIN4
            // 
            this.LabelBIN4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelBIN4.Location = new System.Drawing.Point(206, 130);
            this.LabelBIN4.Name = "LabelBIN4";
            this.LabelBIN4.Size = new System.Drawing.Size(80, 31);
            this.LabelBIN4.TabIndex = 131;
            this.LabelBIN4.Text = "0000";
            this.LabelBIN4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TBoxSOT4
            // 
            this.TBoxSOT4.Enabled = false;
            this.TBoxSOT4.Location = new System.Drawing.Point(207, 81);
            this.TBoxSOT4.Name = "TBoxSOT4";
            this.TBoxSOT4.Size = new System.Drawing.Size(80, 35);
            this.TBoxSOT4.TabIndex = 130;
            this.TBoxSOT4.Text = "0000";
            this.TBoxSOT4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBoxSOT3
            // 
            this.TBoxSOT3.Enabled = false;
            this.TBoxSOT3.Location = new System.Drawing.Point(39, 81);
            this.TBoxSOT3.Name = "TBoxSOT3";
            this.TBoxSOT3.Size = new System.Drawing.Size(80, 35);
            this.TBoxSOT3.TabIndex = 129;
            this.TBoxSOT3.Text = "0000";
            this.TBoxSOT3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBoxSOT2
            // 
            this.TBoxSOT2.Enabled = false;
            this.TBoxSOT2.Location = new System.Drawing.Point(207, 186);
            this.TBoxSOT2.Name = "TBoxSOT2";
            this.TBoxSOT2.Size = new System.Drawing.Size(80, 35);
            this.TBoxSOT2.TabIndex = 128;
            this.TBoxSOT2.Text = "0000";
            this.TBoxSOT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBoxSOT1
            // 
            this.TBoxSOT1.Enabled = false;
            this.TBoxSOT1.Location = new System.Drawing.Point(42, 186);
            this.TBoxSOT1.Name = "TBoxSOT1";
            this.TBoxSOT1.Size = new System.Drawing.Size(80, 35);
            this.TBoxSOT1.TabIndex = 127;
            this.TBoxSOT1.Text = "0000";
            this.TBoxSOT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox5.Location = new System.Drawing.Point(16, 178);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(141, 95);
            this.pictureBox5.TabIndex = 143;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox6.Location = new System.Drawing.Point(180, 178);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(141, 95);
            this.pictureBox6.TabIndex = 144;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox8.Location = new System.Drawing.Point(16, 73);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(141, 95);
            this.pictureBox8.TabIndex = 146;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox7.Location = new System.Drawing.Point(180, 74);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(141, 95);
            this.pictureBox7.TabIndex = 145;
            this.pictureBox7.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(699, 503);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(146, 29);
            this.label16.TabIndex = 92;
            this.label16.Text = "GPIB IF Port";
            // 
            // TBoxGpibCardAddr
            // 
            this.TBoxGpibCardAddr.Enabled = false;
            this.TBoxGpibCardAddr.Location = new System.Drawing.Point(893, 498);
            this.TBoxGpibCardAddr.Name = "TBoxGpibCardAddr";
            this.TBoxGpibCardAddr.Size = new System.Drawing.Size(56, 35);
            this.TBoxGpibCardAddr.TabIndex = 91;
            this.TBoxGpibCardAddr.Text = "3";
            this.TBoxGpibCardAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxGpibCardAddr.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(736, 461);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 26);
            this.label23.TabIndex = 90;
            this.label23.Text = "(Default 1)";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(954, 549);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 32);
            this.label28.TabIndex = 89;
            this.label28.Text = "s";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(676, 555);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(169, 29);
            this.label27.TabIndex = 88;
            this.label27.Text = "Comm timeout";
            // 
            // TBoxTimeOut
            // 
            this.TBoxTimeOut.Location = new System.Drawing.Point(893, 550);
            this.TBoxTimeOut.Name = "TBoxTimeOut";
            this.TBoxTimeOut.Size = new System.Drawing.Size(56, 35);
            this.TBoxTimeOut.TabIndex = 87;
            this.TBoxTimeOut.Text = "10";
            this.TBoxTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxTimeOut.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(652, 433);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(193, 29);
            this.label26.TabIndex = 86;
            this.label26.Text = "Handler Address";
            // 
            // TBoxAddress
            // 
            this.TBoxAddress.Enabled = false;
            this.TBoxAddress.Location = new System.Drawing.Point(893, 433);
            this.TBoxAddress.Name = "TBoxAddress";
            this.TBoxAddress.Size = new System.Drawing.Size(56, 35);
            this.TBoxAddress.TabIndex = 85;
            this.TBoxAddress.Text = "1";
            this.TBoxAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBoxAddress.Click += new System.EventHandler(this.TextBoxClick);
            // 
            // BtnMsgClr
            // 
            this.BtnMsgClr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMsgClr.Location = new System.Drawing.Point(344, 769);
            this.BtnMsgClr.Name = "BtnMsgClr";
            this.BtnMsgClr.Size = new System.Drawing.Size(118, 42);
            this.BtnMsgClr.TabIndex = 124;
            this.BtnMsgClr.Text = "Clear";
            // 
            // ErrMsgBox
            // 
            this.ErrMsgBox.Location = new System.Drawing.Point(38, 470);
            this.ErrMsgBox.Multiline = true;
            this.ErrMsgBox.Name = "ErrMsgBox";
            this.ErrMsgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ErrMsgBox.Size = new System.Drawing.Size(424, 271);
            this.ErrMsgBox.TabIndex = 123;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(37, 433);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(197, 29);
            this.label30.TabIndex = 122;
            this.label30.Text = "System Message";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 844);
            this.Controls.Add(this.BtnMsgClr);
            this.Controls.Add(this.ErrMsgBox);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.TBoxGpibCardAddr);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.TBoxTimeOut);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.TBoxAddress);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MTCB);
            this.Controls.Add(this.DeltaCB);
            this.Controls.Add(this.NoTermCB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LabelON);
            this.Controls.Add(this.LabelOFF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGpibOFF);
            this.Controls.Add(this.btnGpibON);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(1200, 900);
            this.MinimumSize = new System.Drawing.Size(1200, 900);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort PlcPort;
        private System.IO.Ports.SerialPort GpibPort;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnGpibON;
        private System.Windows.Forms.Button btnGpibOFF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelOFF;
        private System.Windows.Forms.Label LabelON;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox TBoxCS2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox TBoxCS4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox TBoxCS3;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox TBoxCS1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox MTCB;
        private System.Windows.Forms.CheckBox DeltaCB;
        private System.Windows.Forms.CheckBox NoTermCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LabelColorBIN4;
        private System.Windows.Forms.Label LabelColorBIN3;
        private System.Windows.Forms.Label LabelColorBIN2;
        private System.Windows.Forms.Label LabelColorBIN1;
        private System.Windows.Forms.Label LabelSOT4;
        private System.Windows.Forms.Label LabelSOT3;
        private System.Windows.Forms.Label LabelSOT2;
        private System.Windows.Forms.Label LabelSOT1;
        private System.Windows.Forms.Label LabelBIN1;
        private System.Windows.Forms.Label LabelBIN2;
        private System.Windows.Forms.Label LabelBIN3;
        private System.Windows.Forms.Label LabelBIN4;
        private System.Windows.Forms.TextBox TBoxSOT4;
        private System.Windows.Forms.TextBox TBoxSOT3;
        private System.Windows.Forms.TextBox TBoxSOT2;
        private System.Windows.Forms.TextBox TBoxSOT1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TBoxGpibCardAddr;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox TBoxTimeOut;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox TBoxAddress;
        private System.Windows.Forms.Button BtnMsgClr;
        private System.Windows.Forms.TextBox ErrMsgBox;
        private System.Windows.Forms.Label label30;
    }
}

