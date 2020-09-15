namespace XFTesterIF_UI
{
    partial class DebugPage
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
            this.MainForm = new System.Windows.Forms.Button();
            this.tBoxSendSOT = new System.Windows.Forms.Button();
            this.tBoxSOT3 = new System.Windows.Forms.TextBox();
            this.tBoxSOT4 = new System.Windows.Forms.TextBox();
            this.tBoxSOT2 = new System.Windows.Forms.TextBox();
            this.tBoxSOT1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SOT2 = new System.Windows.Forms.CheckBox();
            this.SOT1 = new System.Windows.Forms.CheckBox();
            this.SOT3 = new System.Windows.Forms.CheckBox();
            this.SOT4 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetSOT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.MainForm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MainForm.Location = new System.Drawing.Point(595, 390);
            this.MainForm.Name = "MainForm";
            this.MainForm.Size = new System.Drawing.Size(176, 48);
            this.MainForm.TabIndex = 133;
            this.MainForm.Text = "QUIT debugging";
            this.MainForm.UseVisualStyleBackColor = true;
            this.MainForm.Click += new System.EventHandler(this.MainForm_Click);
            // 
            // tBoxSendSOT
            // 
            this.tBoxSendSOT.Location = new System.Drawing.Point(595, 73);
            this.tBoxSendSOT.Name = "tBoxSendSOT";
            this.tBoxSendSOT.Size = new System.Drawing.Size(103, 38);
            this.tBoxSendSOT.TabIndex = 138;
            this.tBoxSendSOT.Text = "SOT";
            this.tBoxSendSOT.UseVisualStyleBackColor = true;
            this.tBoxSendSOT.Visible = false;
            // 
            // tBoxSOT3
            // 
            this.tBoxSOT3.Location = new System.Drawing.Point(405, 233);
            this.tBoxSOT3.Name = "tBoxSOT3";
            this.tBoxSOT3.Size = new System.Drawing.Size(56, 26);
            this.tBoxSOT3.TabIndex = 137;
            this.tBoxSOT3.Text = "0";
            this.tBoxSOT3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxSOT3.Visible = false;
            // 
            // tBoxSOT4
            // 
            this.tBoxSOT4.Location = new System.Drawing.Point(491, 233);
            this.tBoxSOT4.Name = "tBoxSOT4";
            this.tBoxSOT4.Size = new System.Drawing.Size(56, 26);
            this.tBoxSOT4.TabIndex = 136;
            this.tBoxSOT4.Text = "0";
            this.tBoxSOT4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxSOT4.Visible = false;
            // 
            // tBoxSOT2
            // 
            this.tBoxSOT2.Location = new System.Drawing.Point(491, 290);
            this.tBoxSOT2.Name = "tBoxSOT2";
            this.tBoxSOT2.Size = new System.Drawing.Size(56, 26);
            this.tBoxSOT2.TabIndex = 135;
            this.tBoxSOT2.Text = "0";
            this.tBoxSOT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxSOT2.Visible = false;
            // 
            // tBoxSOT1
            // 
            this.tBoxSOT1.Location = new System.Drawing.Point(405, 290);
            this.tBoxSOT1.Name = "tBoxSOT1";
            this.tBoxSOT1.Size = new System.Drawing.Size(56, 26);
            this.tBoxSOT1.TabIndex = 134;
            this.tBoxSOT1.Text = "0";
            this.tBoxSOT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxSOT1.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(708, 149);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 30);
            this.checkBox1.TabIndex = 139;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SOT2
            // 
            this.SOT2.Appearance = System.Windows.Forms.Appearance.Button;
            this.SOT2.BackColor = System.Drawing.Color.LightGray;
            this.SOT2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.SOT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SOT2.Location = new System.Drawing.Point(169, 176);
            this.SOT2.Name = "SOT2";
            this.SOT2.Size = new System.Drawing.Size(97, 50);
            this.SOT2.TabIndex = 141;
            this.SOT2.Text = "CS2";
            this.SOT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SOT2.UseVisualStyleBackColor = false;
            this.SOT2.CheckedChanged += new System.EventHandler(this.SOT_CheckedChanged);
            // 
            // SOT1
            // 
            this.SOT1.Appearance = System.Windows.Forms.Appearance.Button;
            this.SOT1.BackColor = System.Drawing.Color.LightGray;
            this.SOT1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.SOT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SOT1.Location = new System.Drawing.Point(43, 176);
            this.SOT1.Name = "SOT1";
            this.SOT1.Size = new System.Drawing.Size(97, 50);
            this.SOT1.TabIndex = 142;
            this.SOT1.Text = "CS1";
            this.SOT1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SOT1.UseVisualStyleBackColor = false;
            this.SOT1.CheckedChanged += new System.EventHandler(this.SOT_CheckedChanged);
            // 
            // SOT3
            // 
            this.SOT3.Appearance = System.Windows.Forms.Appearance.Button;
            this.SOT3.BackColor = System.Drawing.Color.LightGray;
            this.SOT3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.SOT3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SOT3.Location = new System.Drawing.Point(43, 108);
            this.SOT3.Name = "SOT3";
            this.SOT3.Size = new System.Drawing.Size(97, 50);
            this.SOT3.TabIndex = 144;
            this.SOT3.Text = "CS3";
            this.SOT3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SOT3.UseVisualStyleBackColor = false;
            this.SOT3.CheckedChanged += new System.EventHandler(this.SOT_CheckedChanged);
            // 
            // SOT4
            // 
            this.SOT4.Appearance = System.Windows.Forms.Appearance.Button;
            this.SOT4.BackColor = System.Drawing.Color.LightGray;
            this.SOT4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gold;
            this.SOT4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SOT4.Location = new System.Drawing.Point(169, 108);
            this.SOT4.Name = "SOT4";
            this.SOT4.Size = new System.Drawing.Size(97, 50);
            this.SOT4.TabIndex = 143;
            this.SOT4.Text = "CS4";
            this.SOT4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SOT4.UseVisualStyleBackColor = false;
            this.SOT4.CheckedChanged += new System.EventHandler(this.SOT_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 29);
            this.label1.TabIndex = 145;
            this.label1.Text = "Enable sites in debugging mode";
            // 
            // btnSetSOT
            // 
            this.btnSetSOT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSetSOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetSOT.Location = new System.Drawing.Point(44, 250);
            this.btnSetSOT.Name = "btnSetSOT";
            this.btnSetSOT.Size = new System.Drawing.Size(176, 48);
            this.btnSetSOT.TabIndex = 146;
            this.btnSetSOT.Text = "Set SOTs";
            this.btnSetSOT.UseVisualStyleBackColor = true;
            this.btnSetSOT.Click += new System.EventHandler(this.btnSetSOT_Click);
            // 
            // DebugPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSetSOT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SOT3);
            this.Controls.Add(this.SOT4);
            this.Controls.Add(this.SOT1);
            this.Controls.Add(this.SOT2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tBoxSendSOT);
            this.Controls.Add(this.tBoxSOT3);
            this.Controls.Add(this.tBoxSOT4);
            this.Controls.Add(this.tBoxSOT2);
            this.Controls.Add(this.tBoxSOT1);
            this.Controls.Add(this.MainForm);
            this.Name = "DebugPage";
            this.Text = "DebugPage";
            this.Load += new System.EventHandler(this.DebugPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MainForm;
        private System.Windows.Forms.Button tBoxSendSOT;
        private System.Windows.Forms.TextBox tBoxSOT3;
        private System.Windows.Forms.TextBox tBoxSOT4;
        private System.Windows.Forms.TextBox tBoxSOT2;
        private System.Windows.Forms.TextBox tBoxSOT1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox SOT2;
        private System.Windows.Forms.CheckBox SOT1;
        private System.Windows.Forms.CheckBox SOT3;
        private System.Windows.Forms.CheckBox SOT4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetSOT;
    }
}