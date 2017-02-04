namespace grbl控制上位机程序
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboCOMSelect = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.cboStop = new System.Windows.Forms.ComboBox();
            this.cboDataBit = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnExploreFlie = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtPathSave = new System.Windows.Forms.TextBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.pbarSend = new System.Windows.Forms.ProgressBar();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblRunTime = new System.Windows.Forms.Label();
            this.tmrV = new System.Windows.Forms.Timer(this.components);
            this.lblRate = new System.Windows.Forms.Label();
            this.lblTxtXc = new System.Windows.Forms.Label();
            this.lblTxtYc = new System.Windows.Forms.Label();
            this.lblNumXc = new System.Windows.Forms.Label();
            this.lblNumYc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCOMSelect
            // 
            this.cboCOMSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCOMSelect.FormattingEnabled = true;
            this.cboCOMSelect.Location = new System.Drawing.Point(73, 35);
            this.cboCOMSelect.Name = "cboCOMSelect";
            this.cboCOMSelect.Size = new System.Drawing.Size(121, 20);
            this.cboCOMSelect.TabIndex = 0;
            this.cboCOMSelect.SelectedIndexChanged += new System.EventHandler(this.cboCOMSelect_SelectedIndexChanged);
            this.cboCOMSelect.Click += new System.EventHandler(this.cboCOMSelect_Click);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(270, 97);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPort.TabIndex = 1;
            this.btnOpenPort.Text = "打开串口";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Items.AddRange(new object[] {
            "自定义",
            "1382400",
            "921600",
            "460800",
            "230400",
            "128000",
            "115200",
            "76800",
            "57600",
            "43000",
            "38400",
            "19200",
            "14400",
            "9600",
            "4800",
            "2400",
            "1200"});
            this.cboBaudRate.Location = new System.Drawing.Point(270, 35);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(121, 20);
            this.cboBaudRate.TabIndex = 5;
            this.cboBaudRate.SelectedIndexChanged += new System.EventHandler(this.cboBaudRate_SelectedIndexChanged);
            // 
            // txtMsg
            // 
            this.txtMsg.Font = new System.Drawing.Font("宋体", 9F);
            this.txtMsg.Location = new System.Drawing.Point(17, 200);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(374, 498);
            this.txtMsg.TabIndex = 7;
            // 
            // cboStop
            // 
            this.cboStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStop.FormattingEnabled = true;
            this.cboStop.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cboStop.Location = new System.Drawing.Point(73, 66);
            this.cboStop.Name = "cboStop";
            this.cboStop.Size = new System.Drawing.Size(121, 20);
            this.cboStop.TabIndex = 8;
            this.cboStop.SelectedIndexChanged += new System.EventHandler(this.cboStop_SelectedIndexChanged);
            // 
            // cboDataBit
            // 
            this.cboDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBit.FormattingEnabled = true;
            this.cboDataBit.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.cboDataBit.Location = new System.Drawing.Point(270, 66);
            this.cboDataBit.Name = "cboDataBit";
            this.cboDataBit.Size = new System.Drawing.Size(121, 20);
            this.cboDataBit.TabIndex = 9;
            // 
            // cboParity
            // 
            this.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.cboParity.Location = new System.Drawing.Point(73, 97);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(121, 20);
            this.cboParity.TabIndex = 10;
            this.cboParity.SelectedIndexChanged += new System.EventHandler(this.cboParity_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "串口选择";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "波特率";
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Location = new System.Drawing.Point(15, 74);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(41, 12);
            this.lblStop.TabIndex = 13;
            this.lblStop.Text = "停止位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "停止位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "奇偶校验";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(17, 715);
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSend.Size = new System.Drawing.Size(374, 21);
            this.txtSend.TabIndex = 16;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(316, 742);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnExploreFlie
            // 
            this.btnExploreFlie.Location = new System.Drawing.Point(322, 142);
            this.btnExploreFlie.Name = "btnExploreFlie";
            this.btnExploreFlie.Size = new System.Drawing.Size(75, 23);
            this.btnExploreFlie.TabIndex = 19;
            this.btnExploreFlie.Text = "浏览";
            this.btnExploreFlie.UseVisualStyleBackColor = true;
            this.btnExploreFlie.Click += new System.EventHandler(this.btnExploreFlie_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 171);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 20;
            this.btnOpenFile.Text = "打开";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtPathSave
            // 
            this.txtPathSave.Location = new System.Drawing.Point(12, 144);
            this.txtPathSave.Name = "txtPathSave";
            this.txtPathSave.Size = new System.Drawing.Size(304, 21);
            this.txtPathSave.TabIndex = 21;
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(416, 200);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(474, 498);
            this.picPreview.TabIndex = 22;
            this.picPreview.TabStop = false;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(15, 129);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(41, 12);
            this.lblPath.TabIndex = 23;
            this.lblPath.Text = "路径：";
            // 
            // btnSendFile
            // 
            this.btnSendFile.Enabled = false;
            this.btnSendFile.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSendFile.Location = new System.Drawing.Point(314, 169);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(83, 25);
            this.btnSendFile.TabIndex = 24;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // pbarSend
            // 
            this.pbarSend.Location = new System.Drawing.Point(416, 142);
            this.pbarSend.Name = "pbarSend";
            this.pbarSend.Size = new System.Drawing.Size(474, 23);
            this.pbarSend.TabIndex = 25;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(416, 127);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(11, 12);
            this.lblTime.TabIndex = 26;
            this.lblTime.Text = "0";
            // 
            // lblRunTime
            // 
            this.lblRunTime.AutoSize = true;
            this.lblRunTime.Location = new System.Drawing.Point(417, 171);
            this.lblRunTime.Name = "lblRunTime";
            this.lblRunTime.Size = new System.Drawing.Size(41, 12);
            this.lblRunTime.TabIndex = 27;
            this.lblRunTime.Text = "label7";
            // 
            // tmrV
            // 
            this.tmrV.Interval = 1000;
            this.tmrV.Tick += new System.EventHandler(this.tmrV_Tick);
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(873, 127);
            this.lblRate.Name = "lblRate";
            this.lblRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRate.Size = new System.Drawing.Size(17, 12);
            this.lblRate.TabIndex = 28;
            this.lblRate.Text = "0%";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTxtXc
            // 
            this.lblTxtXc.AutoSize = true;
            this.lblTxtXc.Font = new System.Drawing.Font("幼圆", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTxtXc.Location = new System.Drawing.Point(413, 35);
            this.lblTxtXc.Name = "lblTxtXc";
            this.lblTxtXc.Size = new System.Drawing.Size(182, 35);
            this.lblTxtXc.TabIndex = 29;
            this.lblTxtXc.Text = "X当前位置";
            // 
            // lblTxtYc
            // 
            this.lblTxtYc.AutoSize = true;
            this.lblTxtYc.Font = new System.Drawing.Font("幼圆", 26.25F, System.Drawing.FontStyle.Bold);
            this.lblTxtYc.Location = new System.Drawing.Point(634, 35);
            this.lblTxtYc.Name = "lblTxtYc";
            this.lblTxtYc.Size = new System.Drawing.Size(182, 35);
            this.lblTxtYc.TabIndex = 30;
            this.lblTxtYc.Text = "Y当前位置";
            // 
            // lblNumXc
            // 
            this.lblNumXc.AutoSize = true;
            this.lblNumXc.Font = new System.Drawing.Font("幼圆", 26.25F, System.Drawing.FontStyle.Bold);
            this.lblNumXc.Location = new System.Drawing.Point(413, 85);
            this.lblNumXc.Name = "lblNumXc";
            this.lblNumXc.Size = new System.Drawing.Size(91, 35);
            this.lblNumXc.TabIndex = 31;
            this.lblNumXc.Text = "0.00";
            // 
            // lblNumYc
            // 
            this.lblNumYc.AutoSize = true;
            this.lblNumYc.Font = new System.Drawing.Font("幼圆", 26.25F, System.Drawing.FontStyle.Bold);
            this.lblNumYc.Location = new System.Drawing.Point(634, 85);
            this.lblNumYc.Name = "lblNumYc";
            this.lblNumYc.Size = new System.Drawing.Size(91, 35);
            this.lblNumYc.TabIndex = 32;
            this.lblNumYc.Text = "0.00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(915, 777);
            this.Controls.Add(this.lblNumYc);
            this.Controls.Add(this.lblNumXc);
            this.Controls.Add(this.lblTxtYc);
            this.Controls.Add(this.lblTxtXc);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lblRunTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pbarSend);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.txtPathSave);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnExploreFlie);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboParity);
            this.Controls.Add(this.cboDataBit);
            this.Controls.Add(this.cboStop);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.cboBaudRate);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.cboCOMSelect);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCOMSelect;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.ComboBox cboStop;
        private System.Windows.Forms.ComboBox cboDataBit;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnExploreFlie;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtPathSave;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.ProgressBar pbarSend;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblRunTime;
        private System.Windows.Forms.Timer tmrV;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblTxtXc;
        private System.Windows.Forms.Label lblTxtYc;
        private System.Windows.Forms.Label lblNumXc;
        private System.Windows.Forms.Label lblNumYc;
    }
}

