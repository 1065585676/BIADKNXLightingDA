namespace BIADKNXLightingDA {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing) {

                //if (rtdb != null) rtdb.Close();

                foreach (var device in rtdbs)
                {
                    device.Value.ValueReceived -= Rtdb_ValueReceived;
                    device.Value.Close();
                }
                rtdbs.Clear();
                less7bitsFlag.Clear();

                if (aci != null) aci.Close();

                if (_ptrConfirmedGroupData != null) {
                    _ptrConfirmedGroupData.GroupDataIndicationRead -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationReadEventHandler(OnGroupDataIndicationRead);
                    _ptrConfirmedGroupData.GroupDataConfirmationRead -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationReadEventHandler(OnGroupDataConfirmationRead);
                    _ptrConfirmedGroupData.GroupDataIndicationWrite -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationWriteEventHandler(OnGroupDataIndicationWrite);
                    _ptrConfirmedGroupData.GroupDataConfirmationWrite -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationWriteEventHandler(OnGroupDataConfirmationWrite);
                    _ptrConfirmedGroupData.GroupDataIndicationResponse -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationResponseEventHandler(OnGroupDataIndicationResponse);
                    _ptrConfirmedGroupData.GroupDataConfirmationResponse -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationResponseEventHandler(OnGroupDataConfirmationResponse);
                    _ptrConfirmedGroupData.Status -= new EIBA.Interop.Falcon.IClientGroupDataEvent_StatusEventHandler(OnStatus);
                }
                if (_ptrGroupData != null) {
                    _ptrGroupData.GroupDataIndicationRead -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationReadEventHandler(OnGroupDataIndicationRead);
                    _ptrGroupData.GroupDataConfirmationRead -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationReadEventHandler(OnGroupDataConfirmationRead);
                    _ptrGroupData.GroupDataIndicationWrite -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationWriteEventHandler(OnGroupDataIndicationWrite);
                    _ptrGroupData.GroupDataConfirmationWrite -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationWriteEventHandler(OnGroupDataConfirmationWrite);
                    _ptrGroupData.GroupDataIndicationResponse -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationResponseEventHandler(OnGroupDataIndicationResponse);
                    _ptrGroupData.GroupDataConfirmationResponse -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationResponseEventHandler(OnGroupDataConfirmationResponse);
                    _ptrGroupData.Status -= new EIBA.Interop.Falcon.IClientGroupDataEvent_StatusEventHandler(OnStatus);
                }
                // close connection
                _ptrConfirmedGroupData = null;
                _ptrGroupData = null;
                _ptrGroupDataTransfer = null;

                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.connectAgilorDBACI = new System.Windows.Forms.Button();
            this.connectAgilorDB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.agilorConnectDeviceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.agilorConnectPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.agilorConnectIP = new System.Windows.Forms.TextBox();
            this.loggingBox = new System.Windows.Forms.TextBox();
            this.clearLoggingBox = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.knxGroupDataRead = new System.Windows.Forms.Button();
            this.knxGroupDataWrite = new System.Windows.Forms.Button();
            this.selectKNXInterface = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabel_writeConfig = new System.Windows.Forms.LinkLabel();
            this.agilorACIWriteTarget = new System.Windows.Forms.Button();
            this.agilorWTargetValyeType = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.agilorWriteTarget = new System.Windows.Forms.Button();
            this.agilorReadTarget = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.agilorWTargetValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.agilorRWTargetName = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.kNXWriteConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourcenameGroupAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectAgilorDB = new System.Windows.Forms.Button();
            this.disconnectAgilorDBALL = new System.Windows.Forms.Button();
            this.checkBox_less7bitflag = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_less7bitflag);
            this.groupBox1.Controls.Add(this.disconnectAgilorDBALL);
            this.groupBox1.Controls.Add(this.disconnectAgilorDB);
            this.groupBox1.Controls.Add(this.connectAgilorDBACI);
            this.groupBox1.Controls.Add(this.connectAgilorDB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.agilorConnectDeviceName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.agilorConnectPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.agilorConnectIP);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agilor";
            // 
            // connectAgilorDBACI
            // 
            this.connectAgilorDBACI.Location = new System.Drawing.Point(270, 53);
            this.connectAgilorDBACI.Name = "connectAgilorDBACI";
            this.connectAgilorDBACI.Size = new System.Drawing.Size(99, 23);
            this.connectAgilorDBACI.TabIndex = 7;
            this.connectAgilorDBACI.Text = "ACI-Connect";
            this.connectAgilorDBACI.UseVisualStyleBackColor = true;
            this.connectAgilorDBACI.Click += new System.EventHandler(this.connectAgilorDBACI_Click);
            // 
            // connectAgilorDB
            // 
            this.connectAgilorDB.Location = new System.Drawing.Point(62, 113);
            this.connectAgilorDB.Name = "connectAgilorDB";
            this.connectAgilorDB.Size = new System.Drawing.Size(98, 23);
            this.connectAgilorDB.TabIndex = 6;
            this.connectAgilorDB.Text = "Connect";
            this.connectAgilorDB.UseVisualStyleBackColor = true;
            this.connectAgilorDB.Click += new System.EventHandler(this.connectAgilorDB_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "DEVICE:";
            // 
            // agilorConnectDeviceName
            // 
            this.agilorConnectDeviceName.Location = new System.Drawing.Point(62, 55);
            this.agilorConnectDeviceName.Name = "agilorConnectDeviceName";
            this.agilorConnectDeviceName.Size = new System.Drawing.Size(199, 20);
            this.agilorConnectDeviceName.TabIndex = 4;
            this.agilorConnectDeviceName.Text = "KNX_LOCAL_TEST";
            this.agilorConnectDeviceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PORT:";
            // 
            // agilorConnectPort
            // 
            this.agilorConnectPort.Enabled = false;
            this.agilorConnectPort.Location = new System.Drawing.Point(327, 19);
            this.agilorConnectPort.Name = "agilorConnectPort";
            this.agilorConnectPort.Size = new System.Drawing.Size(76, 20);
            this.agilorConnectPort.TabIndex = 2;
            this.agilorConnectPort.Text = "700";
            this.agilorConnectPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // agilorConnectIP
            // 
            this.agilorConnectIP.Location = new System.Drawing.Point(62, 19);
            this.agilorConnectIP.Name = "agilorConnectIP";
            this.agilorConnectIP.Size = new System.Drawing.Size(199, 20);
            this.agilorConnectIP.TabIndex = 0;
            this.agilorConnectIP.Text = "127.0.0.1";
            this.agilorConnectIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loggingBox
            // 
            this.loggingBox.Location = new System.Drawing.Point(12, 458);
            this.loggingBox.MaxLength = 0;
            this.loggingBox.Multiline = true;
            this.loggingBox.Name = "loggingBox";
            this.loggingBox.ReadOnly = true;
            this.loggingBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.loggingBox.Size = new System.Drawing.Size(454, 256);
            this.loggingBox.TabIndex = 1;
            this.loggingBox.TextChanged += new System.EventHandler(this.loggingBox_TextChanged);
            // 
            // clearLoggingBox
            // 
            this.clearLoggingBox.Location = new System.Drawing.Point(12, 429);
            this.clearLoggingBox.Name = "clearLoggingBox";
            this.clearLoggingBox.Size = new System.Drawing.Size(75, 23);
            this.clearLoggingBox.TabIndex = 7;
            this.clearLoggingBox.Text = "Clear";
            this.clearLoggingBox.UseVisualStyleBackColor = true;
            this.clearLoggingBox.Click += new System.EventHandler(this.clearLoggingBox_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 190);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "KNX Inerface";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 165);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.knxGroupDataRead);
            this.tabPage1.Controls.Add(this.knxGroupDataWrite);
            this.tabPage1.Controls.Add(this.selectKNXInterface);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(430, 139);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "KNX";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // knxGroupDataRead
            // 
            this.knxGroupDataRead.Location = new System.Drawing.Point(102, 79);
            this.knxGroupDataRead.Name = "knxGroupDataRead";
            this.knxGroupDataRead.Size = new System.Drawing.Size(97, 23);
            this.knxGroupDataRead.TabIndex = 13;
            this.knxGroupDataRead.Text = "Read With Dlg";
            this.knxGroupDataRead.UseVisualStyleBackColor = true;
            this.knxGroupDataRead.Click += new System.EventHandler(this.knxGroupDataRead_Click);
            // 
            // knxGroupDataWrite
            // 
            this.knxGroupDataWrite.Location = new System.Drawing.Point(215, 79);
            this.knxGroupDataWrite.Name = "knxGroupDataWrite";
            this.knxGroupDataWrite.Size = new System.Drawing.Size(97, 23);
            this.knxGroupDataWrite.TabIndex = 12;
            this.knxGroupDataWrite.Text = "Write With Dlg";
            this.knxGroupDataWrite.UseVisualStyleBackColor = true;
            this.knxGroupDataWrite.Click += new System.EventHandler(this.knxGroupDataWrite_Click);
            // 
            // selectKNXInterface
            // 
            this.selectKNXInterface.Location = new System.Drawing.Point(102, 28);
            this.selectKNXInterface.Name = "selectKNXInterface";
            this.selectKNXInterface.Size = new System.Drawing.Size(210, 23);
            this.selectKNXInterface.TabIndex = 1;
            this.selectKNXInterface.Text = "Connect Interface";
            this.selectKNXInterface.UseVisualStyleBackColor = true;
            this.selectKNXInterface.Click += new System.EventHandler(this.selectKNXInterface_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.linkLabel_writeConfig);
            this.tabPage2.Controls.Add(this.agilorACIWriteTarget);
            this.tabPage2.Controls.Add(this.agilorWTargetValyeType);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.agilorWriteTarget);
            this.tabPage2.Controls.Add(this.agilorReadTarget);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.agilorWTargetValue);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.agilorRWTargetName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(430, 139);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Agilor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel_writeConfig
            // 
            this.linkLabel_writeConfig.AutoSize = true;
            this.linkLabel_writeConfig.Location = new System.Drawing.Point(243, 52);
            this.linkLabel_writeConfig.Name = "linkLabel_writeConfig";
            this.linkLabel_writeConfig.Size = new System.Drawing.Size(65, 13);
            this.linkLabel_writeConfig.TabIndex = 22;
            this.linkLabel_writeConfig.TabStop = true;
            this.linkLabel_writeConfig.Text = "Write Config";
            this.linkLabel_writeConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_writeConfig_LinkClicked);
            // 
            // agilorACIWriteTarget
            // 
            this.agilorACIWriteTarget.Location = new System.Drawing.Point(336, 47);
            this.agilorACIWriteTarget.Name = "agilorACIWriteTarget";
            this.agilorACIWriteTarget.Size = new System.Drawing.Size(75, 23);
            this.agilorACIWriteTarget.TabIndex = 21;
            this.agilorACIWriteTarget.Text = "ACI Write";
            this.agilorACIWriteTarget.UseVisualStyleBackColor = true;
            this.agilorACIWriteTarget.Click += new System.EventHandler(this.agilorACIWriteTarget_Click);
            // 
            // agilorWTargetValyeType
            // 
            this.agilorWTargetValyeType.FormattingEnabled = true;
            this.agilorWTargetValyeType.Items.AddRange(new object[] {
            "LONG",
            "STRING",
            "FLOAT",
            "BOOL"});
            this.agilorWTargetValyeType.Location = new System.Drawing.Point(98, 83);
            this.agilorWTargetValyeType.Name = "agilorWTargetValyeType";
            this.agilorWTargetValyeType.Size = new System.Drawing.Size(210, 43);
            this.agilorWTargetValyeType.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Value Type:";
            // 
            // agilorWriteTarget
            // 
            this.agilorWriteTarget.Location = new System.Drawing.Point(336, 103);
            this.agilorWriteTarget.Name = "agilorWriteTarget";
            this.agilorWriteTarget.Size = new System.Drawing.Size(75, 23);
            this.agilorWriteTarget.TabIndex = 17;
            this.agilorWriteTarget.Text = "RTDB Write";
            this.agilorWriteTarget.UseVisualStyleBackColor = true;
            this.agilorWriteTarget.Click += new System.EventHandler(this.agilorWriteTarget_Click);
            // 
            // agilorReadTarget
            // 
            this.agilorReadTarget.Location = new System.Drawing.Point(336, 12);
            this.agilorReadTarget.Name = "agilorReadTarget";
            this.agilorReadTarget.Size = new System.Drawing.Size(75, 23);
            this.agilorReadTarget.TabIndex = 14;
            this.agilorReadTarget.Text = "ACI Read";
            this.agilorReadTarget.UseVisualStyleBackColor = true;
            this.agilorReadTarget.Click += new System.EventHandler(this.agilorReadTarget_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Value:";
            // 
            // agilorWTargetValue
            // 
            this.agilorWTargetValue.Location = new System.Drawing.Point(98, 49);
            this.agilorWTargetValue.Name = "agilorWTargetValue";
            this.agilorWTargetValue.Size = new System.Drawing.Size(129, 20);
            this.agilorWTargetValue.TabIndex = 15;
            this.agilorWTargetValue.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Target Name:";
            // 
            // agilorRWTargetName
            // 
            this.agilorRWTargetName.Location = new System.Drawing.Point(98, 14);
            this.agilorRWTargetName.Name = "agilorRWTargetName";
            this.agilorRWTargetName.Size = new System.Drawing.Size(210, 20);
            this.agilorRWTargetName.TabIndex = 12;
            this.agilorRWTargetName.Text = "B_ON_OFF";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(479, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(68, 22);
            this.toolStripDropDownButton1.Text = "Agilor";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kNXWriteConfigurationToolStripMenuItem,
            this.sourcenameGroupAddressToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(74, 22);
            this.toolStripDropDownButton2.Text = "System";
            // 
            // kNXWriteConfigurationToolStripMenuItem
            // 
            this.kNXWriteConfigurationToolStripMenuItem.Name = "kNXWriteConfigurationToolStripMenuItem";
            this.kNXWriteConfigurationToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.kNXWriteConfigurationToolStripMenuItem.Text = "KNX Write Configuration";
            this.kNXWriteConfigurationToolStripMenuItem.Click += new System.EventHandler(this.kNXWriteConfigurationToolStripMenuItem_Click);
            // 
            // sourcenameGroupAddressToolStripMenuItem
            // 
            this.sourcenameGroupAddressToolStripMenuItem.Name = "sourcenameGroupAddressToolStripMenuItem";
            this.sourcenameGroupAddressToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.sourcenameGroupAddressToolStripMenuItem.Text = "SourcenameToGroupAddress";
            this.sourcenameGroupAddressToolStripMenuItem.Click += new System.EventHandler(this.sourcenameGroupAddressToolStripMenuItem_Click);
            // 
            // disconnectAgilorDB
            // 
            this.disconnectAgilorDB.Location = new System.Drawing.Point(166, 113);
            this.disconnectAgilorDB.Name = "disconnectAgilorDB";
            this.disconnectAgilorDB.Size = new System.Drawing.Size(98, 23);
            this.disconnectAgilorDB.TabIndex = 8;
            this.disconnectAgilorDB.Text = "Disconnect";
            this.disconnectAgilorDB.UseVisualStyleBackColor = true;
            this.disconnectAgilorDB.Click += new System.EventHandler(this.disconnectAgilorDB_Click);
            // 
            // disconnectAgilorDBALL
            // 
            this.disconnectAgilorDBALL.Location = new System.Drawing.Point(270, 113);
            this.disconnectAgilorDBALL.Name = "disconnectAgilorDBALL";
            this.disconnectAgilorDBALL.Size = new System.Drawing.Size(99, 23);
            this.disconnectAgilorDBALL.TabIndex = 9;
            this.disconnectAgilorDBALL.Text = "Disconnect ALL";
            this.disconnectAgilorDBALL.UseVisualStyleBackColor = true;
            this.disconnectAgilorDBALL.Click += new System.EventHandler(this.disconnectAgilorDBALL_Click);
            // 
            // checkBox_less7bitflag
            // 
            this.checkBox_less7bitflag.AutoSize = true;
            this.checkBox_less7bitflag.Location = new System.Drawing.Point(62, 87);
            this.checkBox_less7bitflag.Name = "checkBox_less7bitflag";
            this.checkBox_less7bitflag.Size = new System.Drawing.Size(104, 17);
            this.checkBox_less7bitflag.TabIndex = 10;
            this.checkBox_less7bitflag.Text = "Less Than 7 bits";
            this.checkBox_less7bitflag.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 726);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.clearLoggingBox);
            this.Controls.Add(this.loggingBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KNX Interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox agilorConnectPort;
        private System.Windows.Forms.Button connectAgilorDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox agilorConnectDeviceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox agilorConnectIP;
        private System.Windows.Forms.TextBox loggingBox;
        private System.Windows.Forms.Button clearLoggingBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button selectKNXInterface;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button agilorWriteTarget;
        private System.Windows.Forms.Button agilorReadTarget;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox agilorWTargetValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox agilorRWTargetName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox agilorWTargetValyeType;
        private System.Windows.Forms.Button agilorACIWriteTarget;
        private System.Windows.Forms.Button knxGroupDataWrite;
        private System.Windows.Forms.Button knxGroupDataRead;
        private System.Windows.Forms.LinkLabel linkLabel_writeConfig;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem kNXWriteConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourcenameGroupAddressToolStripMenuItem;
        private System.Windows.Forms.Button connectAgilorDBACI;
        private System.Windows.Forms.Button disconnectAgilorDB;
        private System.Windows.Forms.Button disconnectAgilorDBALL;
        private System.Windows.Forms.CheckBox checkBox_less7bitflag;
    }
}

