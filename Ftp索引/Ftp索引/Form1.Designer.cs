namespace Ftp索引
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Run_button = new System.Windows.Forms.Button();
            this.通知 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.HostInput = new System.Windows.Forms.TextBox();
            this.爬虫任务 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.L文件数量 = new System.Windows.Forms.Label();
            this.L目录 = new System.Windows.Forms.Label();
            this.周期更新 = new System.Windows.Forms.Timer(this.components);
            this.目录全名 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.UserInput = new System.Windows.Forms.TextBox();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.EncodingSettings = new System.Windows.Forms.ComboBox();
            this.PortSelection = new System.Windows.Forms.NumericUpDown();
            this.CodeLink = new System.Windows.Forms.LinkLabel();
            this.BilibiliLink = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PortSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // Run_button
            // 
            this.Run_button.Location = new System.Drawing.Point(14, 87);
            this.Run_button.Name = "Run_button";
            this.Run_button.Size = new System.Drawing.Size(98, 30);
            this.Run_button.TabIndex = 0;
            this.Run_button.Text = "RUN";
            this.Run_button.UseVisualStyleBackColor = true;
            this.Run_button.Click += new System.EventHandler(this.Run_Button_Click);
            // 
            // 通知
            // 
            this.通知.Icon = ((System.Drawing.Icon)(resources.GetObject("通知.Icon")));
            this.通知.Text = "Running";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "目标服务器地址：";
            // 
            // HostInput
            // 
            this.HostInput.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.HostInput.Location = new System.Drawing.Point(119, 6);
            this.HostInput.MaxLength = 0;
            this.HostInput.Name = "HostInput";
            this.HostInput.Size = new System.Drawing.Size(105, 21);
            this.HostInput.TabIndex = 2;
            this.HostInput.WordWrap = false;
            // 
            // 爬虫任务
            // 
            this.爬虫任务.DoWork += new System.ComponentModel.DoWorkEventHandler(this.爬虫任务_DoWork);
            this.爬虫任务.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.爬虫任务_RunWorkerCompleted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "文件数量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "目录：";
            // 
            // L文件数量
            // 
            this.L文件数量.AutoSize = true;
            this.L文件数量.Location = new System.Drawing.Point(189, 96);
            this.L文件数量.Name = "L文件数量";
            this.L文件数量.Size = new System.Drawing.Size(11, 12);
            this.L文件数量.TabIndex = 7;
            this.L文件数量.Text = "0";
            // 
            // L目录
            // 
            this.L目录.Location = new System.Drawing.Point(50, 120);
            this.L目录.Name = "L目录";
            this.L目录.Size = new System.Drawing.Size(481, 31);
            this.L目录.TabIndex = 8;
            this.L目录.Text = "/";
            this.目录全名.SetToolTip(this.L目录, "/");
            // 
            // 周期更新
            // 
            this.周期更新.Tick += new System.EventHandler(this.周期更新_Tick);
            // 
            // 目录全名
            // 
            this.目录全名.ToolTipTitle = "目录：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "账号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "密码：";
            // 
            // UserInput
            // 
            this.UserInput.Location = new System.Drawing.Point(52, 31);
            this.UserInput.Name = "UserInput";
            this.UserInput.Size = new System.Drawing.Size(184, 21);
            this.UserInput.TabIndex = 11;
            this.UserInput.Text = "anonymous";
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(52, 60);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.PasswordChar = '*';
            this.PasswordInput.Size = new System.Drawing.Size(184, 21);
            this.PasswordInput.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "编码设定：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "端口：";
            // 
            // EncodingSettings
            // 
            this.EncodingSettings.FormattingEnabled = true;
            this.EncodingSettings.Items.AddRange(new object[] {
            "<自动检测>",
            "GB18030",
            "GBK",
            "UTF-8",
            "UTF-16",
            "Unicode",
            "ANSI",
            "ISO8859-1"});
            this.EncodingSettings.Location = new System.Drawing.Point(389, 5);
            this.EncodingSettings.Name = "EncodingSettings";
            this.EncodingSettings.Size = new System.Drawing.Size(112, 20);
            this.EncodingSettings.TabIndex = 16;
            this.EncodingSettings.Text = "<自动检测>";
            // 
            // PortSelection
            // 
            this.PortSelection.AutoSize = true;
            this.PortSelection.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PortSelection.Location = new System.Drawing.Point(263, 6);
            this.PortSelection.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PortSelection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortSelection.Name = "PortSelection";
            this.PortSelection.Size = new System.Drawing.Size(51, 21);
            this.PortSelection.TabIndex = 17;
            this.PortSelection.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // CodeLink
            // 
            this.CodeLink.AutoSize = true;
            this.CodeLink.Location = new System.Drawing.Point(448, 60);
            this.CodeLink.Name = "CodeLink";
            this.CodeLink.Size = new System.Drawing.Size(41, 12);
            this.CodeLink.TabIndex = 18;
            this.CodeLink.TabStop = true;
            this.CodeLink.Text = "源代码";
            this.CodeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CodeLink_LinkClicked);
            // 
            // BilibiliLink
            // 
            this.BilibiliLink.AutoSize = true;
            this.BilibiliLink.Location = new System.Drawing.Point(448, 34);
            this.BilibiliLink.Name = "BilibiliLink";
            this.BilibiliLink.Size = new System.Drawing.Size(83, 12);
            this.BilibiliLink.TabIndex = 20;
            this.BilibiliLink.TabStop = true;
            this.BilibiliLink.Text = "Bilibili/捐赠";
            this.BilibiliLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BilibiliLink_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(392, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "本软件使用MIT许可协议";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Info;
            this.label8.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(242, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 40);
            this.label8.TabIndex = 19;
            this.label8.Text = "FTP索引 为免费软件\r\n由 侏罗纪 制作 ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(557, 175);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BilibiliLink);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CodeLink);
            this.Controls.Add(this.PortSelection);
            this.Controls.Add(this.EncodingSettings);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.UserInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.L目录);
            this.Controls.Add(this.L文件数量);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HostInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Run_button);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "FTP索引制作";
            ((System.ComponentModel.ISupportInitialize)(this.PortSelection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Run_button;
        private System.Windows.Forms.NotifyIcon 通知;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HostInput;
        private System.ComponentModel.BackgroundWorker 爬虫任务;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label L文件数量;
        private System.Windows.Forms.Label L目录;
        private System.Windows.Forms.Timer 周期更新;
        private System.Windows.Forms.ToolTip 目录全名;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UserInput;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox EncodingSettings;
        private System.Windows.Forms.NumericUpDown PortSelection;
        private System.Windows.Forms.LinkLabel CodeLink;
        private System.Windows.Forms.LinkLabel BilibiliLink;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}

