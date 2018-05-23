namespace WindowsFormsApp1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.operationState_checkBox1 = new System.Windows.Forms.CheckBox();
            this.oneButton_checkBox1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.portName_textBox2 = new System.Windows.Forms.TextBox();
            this.freshPort = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openSwitch = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.autoConnect_checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.reciveShow = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.connect = new System.Windows.Forms.Button();
            this.returnMacList = new System.Windows.Forms.Button();
            this.searchHold = new System.Windows.Forms.CheckBox();
            this.search = new System.Windows.Forms.Button();
            this.listViewFreshStyle = new System.Windows.Forms.CheckBox();
            this.operationResult_textBox2 = new System.Windows.Forms.TextBox();
            this.clearOperationResult = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.clearSendRecoed = new System.Windows.Forms.Button();
            this.HexSend_checkBox1 = new System.Windows.Forms.CheckBox();
            this.pauseRecive_checkBox1 = new System.Windows.Forms.CheckBox();
            this.clearAfterSend_checkBox1 = new System.Windows.Forms.CheckBox();
            this.HexReciveShow_checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sent_textBox2 = new System.Windows.Forms.TextBox();
            this.clearRecive = new System.Windows.Forms.Button();
            this.send = new System.Windows.Forms.Button();
            this.send_textBox2 = new System.Windows.Forms.TextBox();
            this.recive_textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RSSI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ifConnect = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.connectPeri = new System.Windows.Forms.Button();
            this.periCount_textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.disconnectPeri = new System.Windows.Forms.Button();
            this.freshConnectPeri = new System.Windows.Forms.Button();
            this.periResult_textBox2 = new System.Windows.Forms.TextBox();
            this.clearSendRecoedBLE = new System.Windows.Forms.Button();
            this.clearAfterSendBLE_checkBox1 = new System.Windows.Forms.CheckBox();
            this.sendBLE = new System.Windows.Forms.Button();
            this.sendBLE_textBox2 = new System.Windows.Forms.TextBox();
            this.HexSendBLE_checkBox1 = new System.Windows.Forms.CheckBox();
            this.readBLE_textBox2 = new System.Windows.Forms.TextBox();
            this.clearReadBleText = new System.Windows.Forms.Button();
            this.readBLE = new System.Windows.Forms.Button();
            this.openN = new System.Windows.Forms.Button();
            this.returnN = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.testMode_checkBox1 = new System.Windows.Forms.CheckBox();
            this.testModeZone = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.test2 = new System.Windows.Forms.Button();
            this.VShow = new System.Windows.Forms.TextBox();
            this.VMin_textBox6 = new System.Windows.Forms.TextBox();
            this.VMax_textBox5 = new System.Windows.Forms.TextBox();
            this.testResult = new System.Windows.Forms.TextBox();
            this.IShow = new System.Windows.Forms.TextBox();
            this.test1 = new System.Windows.Forms.Button();
            this.IMax_textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.netStatus_textBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.IDRecordResult_textBox7 = new System.Windows.Forms.TextBox();
            this.IDRecord = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.CTPOCStatus_textBox7 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.paraSet_groupBox8 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.loginResult_textBox4 = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.loginType_comboBox6 = new System.Windows.Forms.ComboBox();
            this.loginPassword_textBox5 = new System.Windows.Forms.TextBox();
            this.loginAccount_textBox4 = new System.Windows.Forms.TextBox();
            this.paraSet_checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.testModeZone.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.paraSet_groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.operationState_checkBox1);
            this.groupBox1.Controls.Add(this.oneButton_checkBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.portName_textBox2);
            this.groupBox1.Controls.Add(this.freshPort);
            this.groupBox1.Controls.Add(this.comboBox5);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择串口";
            // 
            // operationState_checkBox1
            // 
            this.operationState_checkBox1.AutoSize = true;
            this.operationState_checkBox1.Location = new System.Drawing.Point(153, 110);
            this.operationState_checkBox1.Name = "operationState_checkBox1";
            this.operationState_checkBox1.Size = new System.Drawing.Size(72, 16);
            this.operationState_checkBox1.TabIndex = 39;
            this.operationState_checkBox1.Text = "调试状态";
            this.operationState_checkBox1.UseVisualStyleBackColor = true;
            this.operationState_checkBox1.CheckedChanged += new System.EventHandler(this.operationState_checkBox1_CheckedChanged);
            // 
            // oneButton_checkBox1
            // 
            this.oneButton_checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.oneButton_checkBox1.AutoSize = true;
            this.oneButton_checkBox1.Location = new System.Drawing.Point(153, 64);
            this.oneButton_checkBox1.Name = "oneButton_checkBox1";
            this.oneButton_checkBox1.Size = new System.Drawing.Size(63, 22);
            this.oneButton_checkBox1.TabIndex = 38;
            this.oneButton_checkBox1.Text = "一键连接";
            this.oneButton_checkBox1.UseVisualStyleBackColor = true;
            this.oneButton_checkBox1.CheckedChanged += new System.EventHandler(this.oneButton_checkBox1_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "名称";
            // 
            // portName_textBox2
            // 
            this.portName_textBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.portName_textBox2.Location = new System.Drawing.Point(47, 151);
            this.portName_textBox2.Name = "portName_textBox2";
            this.portName_textBox2.ReadOnly = true;
            this.portName_textBox2.Size = new System.Drawing.Size(100, 21);
            this.portName_textBox2.TabIndex = 34;
            // 
            // freshPort
            // 
            this.freshPort.Location = new System.Drawing.Point(153, 20);
            this.freshPort.Name = "freshPort";
            this.freshPort.Size = new System.Drawing.Size(63, 23);
            this.freshPort.TabIndex = 30;
            this.freshPort.Text = "刷新";
            this.freshPort.UseVisualStyleBackColor = true;
            this.freshPort.Click += new System.EventHandler(this.freshPort_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(47, 125);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(100, 20);
            this.comboBox5.TabIndex = 9;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "数长";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(47, 100);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(100, 20);
            this.comboBox4.TabIndex = 7;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "停止";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(47, 74);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(100, 20);
            this.comboBox3.TabIndex = 5;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "校验";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(47, 48);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 20);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(47, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口";
            // 
            // openSwitch
            // 
            this.openSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.openSwitch.AutoSize = true;
            this.openSwitch.Location = new System.Drawing.Point(92, 362);
            this.openSwitch.Name = "openSwitch";
            this.openSwitch.Size = new System.Drawing.Size(63, 22);
            this.openSwitch.TabIndex = 33;
            this.openSwitch.Text = "串口开关";
            this.openSwitch.UseVisualStyleBackColor = true;
            this.openSwitch.CheckedChanged += new System.EventHandler(this.openSPort_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 37;
            this.label9.Text = "结果";
            // 
            // autoConnect_checkBox1
            // 
            this.autoConnect_checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.autoConnect_checkBox1.BackColor = System.Drawing.Color.Gold;
            this.autoConnect_checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.autoConnect_checkBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.autoConnect_checkBox1.Location = new System.Drawing.Point(22, 93);
            this.autoConnect_checkBox1.Name = "autoConnect_checkBox1";
            this.autoConnect_checkBox1.Size = new System.Drawing.Size(125, 46);
            this.autoConnect_checkBox1.TabIndex = 36;
            this.autoConnect_checkBox1.Text = "1.连接串口";
            this.autoConnect_checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.autoConnect_checkBox1.UseVisualStyleBackColor = false;
            this.autoConnect_checkBox1.CheckedChanged += new System.EventHandler(this.autoConnect_checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(23, 194);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(125, 91);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox3.Location = new System.Drawing.Point(144, 106);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(108, 83);
            this.textBox3.TabIndex = 65;
            // 
            // reciveShow
            // 
            this.reciveShow.BackColor = System.Drawing.SystemColors.ControlLight;
            this.reciveShow.Location = new System.Drawing.Point(144, 17);
            this.reciveShow.Multiline = true;
            this.reciveShow.Name = "reciveShow";
            this.reciveShow.ReadOnly = true;
            this.reciveShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.reciveShow.Size = new System.Drawing.Size(108, 83);
            this.reciveShow.TabIndex = 64;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.connect);
            this.groupBox2.Controls.Add(this.returnMacList);
            this.groupBox2.Controls.Add(this.searchHold);
            this.groupBox2.Location = new System.Drawing.Point(240, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 109);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "蓝牙选择";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(36, 73);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(85, 23);
            this.connect.TabIndex = 67;
            this.connect.Text = "连接最后元素";
            this.connect.UseVisualStyleBackColor = true;
            // 
            // returnMacList
            // 
            this.returnMacList.Location = new System.Drawing.Point(6, 44);
            this.returnMacList.Name = "returnMacList";
            this.returnMacList.Size = new System.Drawing.Size(75, 23);
            this.returnMacList.TabIndex = 66;
            this.returnMacList.Text = "返回Mac列表";
            this.returnMacList.UseVisualStyleBackColor = true;
            this.returnMacList.Click += new System.EventHandler(this.returnMacList_Click);
            // 
            // searchHold
            // 
            this.searchHold.AutoSize = true;
            this.searchHold.Location = new System.Drawing.Point(36, 22);
            this.searchHold.Name = "searchHold";
            this.searchHold.Size = new System.Drawing.Size(84, 16);
            this.searchHold.TabIndex = 64;
            this.searchHold.Text = "不间断搜索";
            this.searchHold.UseVisualStyleBackColor = true;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.LightYellow;
            this.search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search.Font = new System.Drawing.Font("宋体", 12F);
            this.search.Location = new System.Drawing.Point(161, 93);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(125, 46);
            this.search.TabIndex = 68;
            this.search.Text = "2.刷新蓝牙";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // listViewFreshStyle
            // 
            this.listViewFreshStyle.AutoSize = true;
            this.listViewFreshStyle.Location = new System.Drawing.Point(317, 347);
            this.listViewFreshStyle.Name = "listViewFreshStyle";
            this.listViewFreshStyle.Size = new System.Drawing.Size(84, 16);
            this.listViewFreshStyle.TabIndex = 69;
            this.listViewFreshStyle.Text = "刷新式显示";
            this.listViewFreshStyle.UseVisualStyleBackColor = true;
            // 
            // operationResult_textBox2
            // 
            this.operationResult_textBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.operationResult_textBox2.Location = new System.Drawing.Point(255, 49);
            this.operationResult_textBox2.Multiline = true;
            this.operationResult_textBox2.Name = "operationResult_textBox2";
            this.operationResult_textBox2.ReadOnly = true;
            this.operationResult_textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.operationResult_textBox2.Size = new System.Drawing.Size(105, 58);
            this.operationResult_textBox2.TabIndex = 38;
            // 
            // clearOperationResult
            // 
            this.clearOperationResult.Location = new System.Drawing.Point(314, 20);
            this.clearOperationResult.Name = "clearOperationResult";
            this.clearOperationResult.Size = new System.Drawing.Size(46, 23);
            this.clearOperationResult.TabIndex = 39;
            this.clearOperationResult.Text = "清空操作记录";
            this.clearOperationResult.UseVisualStyleBackColor = true;
            this.clearOperationResult.Click += new System.EventHandler(this.clearOperationResult_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.clearSendRecoed);
            this.groupBox3.Controls.Add(this.HexSend_checkBox1);
            this.groupBox3.Controls.Add(this.pauseRecive_checkBox1);
            this.groupBox3.Controls.Add(this.clearAfterSend_checkBox1);
            this.groupBox3.Controls.Add(this.HexReciveShow_checkBox1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.sent_textBox2);
            this.groupBox3.Controls.Add(this.clearRecive);
            this.groupBox3.Controls.Add(this.send);
            this.groupBox3.Controls.Add(this.send_textBox2);
            this.groupBox3.Location = new System.Drawing.Point(378, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 214);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "串口收发";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(163, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 24);
            this.label14.TabIndex = 64;
            this.label14.Text = "(窗口见\r\n2.搜索外设)";
            // 
            // clearSendRecoed
            // 
            this.clearSendRecoed.Location = new System.Drawing.Point(89, 195);
            this.clearSendRecoed.Name = "clearSendRecoed";
            this.clearSendRecoed.Size = new System.Drawing.Size(87, 23);
            this.clearSendRecoed.TabIndex = 63;
            this.clearSendRecoed.Text = "清空发送记录";
            this.clearSendRecoed.UseVisualStyleBackColor = true;
            this.clearSendRecoed.Click += new System.EventHandler(this.clearSendRecord_Click);
            // 
            // HexSend_checkBox1
            // 
            this.HexSend_checkBox1.AutoSize = true;
            this.HexSend_checkBox1.Location = new System.Drawing.Point(91, 20);
            this.HexSend_checkBox1.Name = "HexSend_checkBox1";
            this.HexSend_checkBox1.Size = new System.Drawing.Size(66, 16);
            this.HexSend_checkBox1.TabIndex = 62;
            this.HexSend_checkBox1.Text = "HEX发送";
            this.HexSend_checkBox1.UseVisualStyleBackColor = true;
            this.HexSend_checkBox1.CheckedChanged += new System.EventHandler(this.HexSend_checkBox1_CheckedChanged);
            // 
            // pauseRecive_checkBox1
            // 
            this.pauseRecive_checkBox1.AutoSize = true;
            this.pauseRecive_checkBox1.Location = new System.Drawing.Point(165, 121);
            this.pauseRecive_checkBox1.Name = "pauseRecive_checkBox1";
            this.pauseRecive_checkBox1.Size = new System.Drawing.Size(72, 16);
            this.pauseRecive_checkBox1.TabIndex = 61;
            this.pauseRecive_checkBox1.Text = "暂停显示";
            this.pauseRecive_checkBox1.UseVisualStyleBackColor = true;
            // 
            // clearAfterSend_checkBox1
            // 
            this.clearAfterSend_checkBox1.AutoSize = true;
            this.clearAfterSend_checkBox1.Location = new System.Drawing.Point(6, 200);
            this.clearAfterSend_checkBox1.Name = "clearAfterSend_checkBox1";
            this.clearAfterSend_checkBox1.Size = new System.Drawing.Size(84, 16);
            this.clearAfterSend_checkBox1.TabIndex = 60;
            this.clearAfterSend_checkBox1.Text = "发送后清空";
            this.clearAfterSend_checkBox1.UseVisualStyleBackColor = true;
            // 
            // HexReciveShow_checkBox1
            // 
            this.HexReciveShow_checkBox1.AutoSize = true;
            this.HexReciveShow_checkBox1.Location = new System.Drawing.Point(165, 51);
            this.HexReciveShow_checkBox1.Name = "HexReciveShow_checkBox1";
            this.HexReciveShow_checkBox1.Size = new System.Drawing.Size(66, 16);
            this.HexReciveShow_checkBox1.TabIndex = 59;
            this.HexReciveShow_checkBox1.Text = "HEX显示";
            this.HexReciveShow_checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 58;
            this.label7.Text = "串口接收";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 57;
            this.label6.Text = "串口发送";
            // 
            // sent_textBox2
            // 
            this.sent_textBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sent_textBox2.Location = new System.Drawing.Point(8, 42);
            this.sent_textBox2.Multiline = true;
            this.sent_textBox2.Name = "sent_textBox2";
            this.sent_textBox2.ReadOnly = true;
            this.sent_textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sent_textBox2.Size = new System.Drawing.Size(140, 91);
            this.sent_textBox2.TabIndex = 56;
            // 
            // clearRecive
            // 
            this.clearRecive.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.clearRecive.Location = new System.Drawing.Point(165, 149);
            this.clearRecive.Name = "clearRecive";
            this.clearRecive.Size = new System.Drawing.Size(63, 23);
            this.clearRecive.TabIndex = 55;
            this.clearRecive.Text = "清空";
            this.clearRecive.UseVisualStyleBackColor = true;
            this.clearRecive.Click += new System.EventHandler(this.clearRecive_Click);
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(119, 139);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(29, 46);
            this.send.TabIndex = 53;
            this.send.Text = "发送";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // send_textBox2
            // 
            this.send_textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.send_textBox2.Location = new System.Drawing.Point(8, 139);
            this.send_textBox2.Multiline = true;
            this.send_textBox2.Name = "send_textBox2";
            this.send_textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.send_textBox2.Size = new System.Drawing.Size(113, 46);
            this.send_textBox2.TabIndex = 52;
            this.send_textBox2.TextChanged += new System.EventHandler(this.send_textBox2_TextChanged);
            this.send_textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.send_textBox2_KeyPress);
            this.send_textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.send_textBox2_KeyUp);
            // 
            // recive_textBox3
            // 
            this.recive_textBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.recive_textBox3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.recive_textBox3.Location = new System.Drawing.Point(162, 194);
            this.recive_textBox3.Multiline = true;
            this.recive_textBox3.Name = "recive_textBox3";
            this.recive_textBox3.ReadOnly = true;
            this.recive_textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.recive_textBox3.Size = new System.Drawing.Size(125, 91);
            this.recive_textBox3.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(244, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 38;
            this.label10.Text = "错误列表";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.number,
            this.name,
            this.MAC,
            this.UUID,
            this.RSSI,
            this.ifConnect});
            this.listView1.Font = new System.Drawing.Font("宋体", 9F);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(310, 59);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(485, 278);
            this.listView1.TabIndex = 53;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // number
            // 
            this.number.Text = "序号";
            this.number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.number.Width = 47;
            // 
            // name
            // 
            this.name.Text = "名称";
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.name.Width = 160;
            // 
            // MAC
            // 
            this.MAC.Text = "MAC";
            this.MAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MAC.Width = 131;
            // 
            // UUID
            // 
            this.UUID.Text = "UUID";
            this.UUID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UUID.Width = 47;
            // 
            // RSSI
            // 
            this.RSSI.Text = "RSSI";
            this.RSSI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RSSI.Width = 38;
            // 
            // ifConnect
            // 
            this.ifConnect.Text = "连接标记";
            this.ifConnect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // connectPeri
            // 
            this.connectPeri.BackColor = System.Drawing.Color.YellowGreen;
            this.connectPeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectPeri.Location = new System.Drawing.Point(720, 344);
            this.connectPeri.Name = "connectPeri";
            this.connectPeri.Size = new System.Drawing.Size(75, 23);
            this.connectPeri.TabIndex = 70;
            this.connectPeri.Text = "连接外设";
            this.connectPeri.UseVisualStyleBackColor = false;
            this.connectPeri.Click += new System.EventHandler(this.connectPeri_Click);
            // 
            // periCount_textBox2
            // 
            this.periCount_textBox2.Location = new System.Drawing.Point(490, 347);
            this.periCount_textBox2.Name = "periCount_textBox2";
            this.periCount_textBox2.ReadOnly = true;
            this.periCount_textBox2.Size = new System.Drawing.Size(100, 21);
            this.periCount_textBox2.TabIndex = 71;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(407, 349);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 72;
            this.label11.Text = "活跃元素个数";
            // 
            // disconnectPeri
            // 
            this.disconnectPeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectPeri.Location = new System.Drawing.Point(624, 345);
            this.disconnectPeri.Name = "disconnectPeri";
            this.disconnectPeri.Size = new System.Drawing.Size(75, 23);
            this.disconnectPeri.TabIndex = 73;
            this.disconnectPeri.Text = "断开外设";
            this.disconnectPeri.UseVisualStyleBackColor = true;
            this.disconnectPeri.Click += new System.EventHandler(this.disconnectPeri_Click);
            // 
            // freshConnectPeri
            // 
            this.freshConnectPeri.Location = new System.Drawing.Point(6, 20);
            this.freshConnectPeri.Name = "freshConnectPeri";
            this.freshConnectPeri.Size = new System.Drawing.Size(75, 23);
            this.freshConnectPeri.TabIndex = 74;
            this.freshConnectPeri.Text = "刷新连接";
            this.freshConnectPeri.UseVisualStyleBackColor = true;
            this.freshConnectPeri.Click += new System.EventHandler(this.freshConnectPeri_Click);
            // 
            // periResult_textBox2
            // 
            this.periResult_textBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.periResult_textBox2.Location = new System.Drawing.Point(257, 106);
            this.periResult_textBox2.Multiline = true;
            this.periResult_textBox2.Name = "periResult_textBox2";
            this.periResult_textBox2.ReadOnly = true;
            this.periResult_textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.periResult_textBox2.Size = new System.Drawing.Size(104, 82);
            this.periResult_textBox2.TabIndex = 75;
            // 
            // clearSendRecoedBLE
            // 
            this.clearSendRecoedBLE.Location = new System.Drawing.Point(79, 185);
            this.clearSendRecoedBLE.Name = "clearSendRecoedBLE";
            this.clearSendRecoedBLE.Size = new System.Drawing.Size(38, 23);
            this.clearSendRecoedBLE.TabIndex = 79;
            this.clearSendRecoedBLE.Text = "清空发送记录";
            this.clearSendRecoedBLE.UseVisualStyleBackColor = true;
            // 
            // clearAfterSendBLE_checkBox1
            // 
            this.clearAfterSendBLE_checkBox1.AutoSize = true;
            this.clearAfterSendBLE_checkBox1.Location = new System.Drawing.Point(9, 167);
            this.clearAfterSendBLE_checkBox1.Name = "clearAfterSendBLE_checkBox1";
            this.clearAfterSendBLE_checkBox1.Size = new System.Drawing.Size(84, 16);
            this.clearAfterSendBLE_checkBox1.TabIndex = 78;
            this.clearAfterSendBLE_checkBox1.Text = "发送后清空";
            this.clearAfterSendBLE_checkBox1.UseVisualStyleBackColor = true;
            // 
            // sendBLE
            // 
            this.sendBLE.Location = new System.Drawing.Point(114, 113);
            this.sendBLE.Name = "sendBLE";
            this.sendBLE.Size = new System.Drawing.Size(29, 46);
            this.sendBLE.TabIndex = 77;
            this.sendBLE.Text = "发送";
            this.sendBLE.UseVisualStyleBackColor = true;
            this.sendBLE.Click += new System.EventHandler(this.sendBLE_Click);
            // 
            // sendBLE_textBox2
            // 
            this.sendBLE_textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.sendBLE_textBox2.Location = new System.Drawing.Point(9, 115);
            this.sendBLE_textBox2.Multiline = true;
            this.sendBLE_textBox2.Name = "sendBLE_textBox2";
            this.sendBLE_textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sendBLE_textBox2.Size = new System.Drawing.Size(99, 46);
            this.sendBLE_textBox2.TabIndex = 76;
            this.sendBLE_textBox2.TextChanged += new System.EventHandler(this.sendBLE_textBox2_TextChanged);
            this.sendBLE_textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.sendBLE_textBox2_KeyUp);
            // 
            // HexSendBLE_checkBox1
            // 
            this.HexSendBLE_checkBox1.AutoSize = true;
            this.HexSendBLE_checkBox1.Location = new System.Drawing.Point(9, 189);
            this.HexSendBLE_checkBox1.Name = "HexSendBLE_checkBox1";
            this.HexSendBLE_checkBox1.Size = new System.Drawing.Size(66, 16);
            this.HexSendBLE_checkBox1.TabIndex = 80;
            this.HexSendBLE_checkBox1.Text = "HEX发送";
            this.HexSendBLE_checkBox1.UseVisualStyleBackColor = true;
            this.HexSendBLE_checkBox1.CheckedChanged += new System.EventHandler(this.HexSendBLE_checkBox1_CheckedChanged);
            // 
            // readBLE_textBox2
            // 
            this.readBLE_textBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.readBLE_textBox2.Location = new System.Drawing.Point(258, 17);
            this.readBLE_textBox2.Multiline = true;
            this.readBLE_textBox2.Name = "readBLE_textBox2";
            this.readBLE_textBox2.ReadOnly = true;
            this.readBLE_textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.readBLE_textBox2.Size = new System.Drawing.Size(103, 83);
            this.readBLE_textBox2.TabIndex = 81;
            // 
            // clearReadBleText
            // 
            this.clearReadBleText.Location = new System.Drawing.Point(187, 186);
            this.clearReadBleText.Name = "clearReadBleText";
            this.clearReadBleText.Size = new System.Drawing.Size(75, 23);
            this.clearReadBleText.TabIndex = 82;
            this.clearReadBleText.Text = "清空";
            this.clearReadBleText.UseVisualStyleBackColor = true;
            this.clearReadBleText.Click += new System.EventHandler(this.clearReadBleText_Click);
            // 
            // readBLE
            // 
            this.readBLE.Location = new System.Drawing.Point(9, 49);
            this.readBLE.Name = "readBLE";
            this.readBLE.Size = new System.Drawing.Size(29, 46);
            this.readBLE.TabIndex = 83;
            this.readBLE.Text = "读取";
            this.readBLE.UseVisualStyleBackColor = true;
            this.readBLE.Click += new System.EventHandler(this.read_Click);
            // 
            // openN
            // 
            this.openN.Location = new System.Drawing.Point(44, 48);
            this.openN.Name = "openN";
            this.openN.Size = new System.Drawing.Size(29, 46);
            this.openN.TabIndex = 84;
            this.openN.Text = "打开notify";
            this.openN.UseVisualStyleBackColor = true;
            this.openN.Click += new System.EventHandler(this.openN_Click);
            // 
            // returnN
            // 
            this.returnN.Location = new System.Drawing.Point(79, 47);
            this.returnN.Name = "returnN";
            this.returnN.Size = new System.Drawing.Size(29, 46);
            this.returnN.TabIndex = 85;
            this.returnN.Text = "恢复Notify";
            this.returnN.UseVisualStyleBackColor = true;
            this.returnN.Click += new System.EventHandler(this.returnN_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(165, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 64;
            this.label12.Text = "蓝牙接收分拣";
            // 
            // testMode_checkBox1
            // 
            this.testMode_checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.testMode_checkBox1.AutoSize = true;
            this.testMode_checkBox1.Location = new System.Drawing.Point(6, 31);
            this.testMode_checkBox1.Name = "testMode_checkBox1";
            this.testMode_checkBox1.Size = new System.Drawing.Size(63, 22);
            this.testMode_checkBox1.TabIndex = 40;
            this.testMode_checkBox1.Text = "测试模式";
            this.testMode_checkBox1.UseVisualStyleBackColor = true;
            this.testMode_checkBox1.CheckedChanged += new System.EventHandler(this.testMode_checkBox1_CheckedChanged);
            // 
            // testModeZone
            // 
            this.testModeZone.BackColor = System.Drawing.SystemColors.ControlLight;
            this.testModeZone.Controls.Add(this.label16);
            this.testModeZone.Controls.Add(this.label21);
            this.testModeZone.Controls.Add(this.label18);
            this.testModeZone.Controls.Add(this.label20);
            this.testModeZone.Controls.Add(this.label17);
            this.testModeZone.Controls.Add(this.label19);
            this.testModeZone.Controls.Add(this.test2);
            this.testModeZone.Controls.Add(this.VShow);
            this.testModeZone.Controls.Add(this.VMin_textBox6);
            this.testModeZone.Controls.Add(this.VMax_textBox5);
            this.testModeZone.Controls.Add(this.testResult);
            this.testModeZone.Controls.Add(this.IShow);
            this.testModeZone.Controls.Add(this.test1);
            this.testModeZone.Controls.Add(this.IMax_textBox4);
            this.testModeZone.Controls.Add(this.groupBox4);
            this.testModeZone.Controls.Add(this.groupBox1);
            this.testModeZone.Controls.Add(this.groupBox2);
            this.testModeZone.Controls.Add(this.operationResult_textBox2);
            this.testModeZone.Controls.Add(this.clearOperationResult);
            this.testModeZone.Controls.Add(this.groupBox3);
            this.testModeZone.Controls.Add(this.label10);
            this.testModeZone.Location = new System.Drawing.Point(-4, 455);
            this.testModeZone.Name = "testModeZone";
            this.testModeZone.Size = new System.Drawing.Size(1174, 236);
            this.testModeZone.TabIndex = 86;
            this.testModeZone.TabStop = false;
            this.testModeZone.Text = "调试区";
            this.testModeZone.VisibleChanged += new System.EventHandler(this.testModeZone_VisibleChanged);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 12F);
            this.label16.Location = new System.Drawing.Point(995, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 21);
            this.label16.TabIndex = 101;
            this.label16.Text = "电流";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1081, 124);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 12);
            this.label21.TabIndex = 93;
            this.label21.Text = "电压 最大值";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(995, 188);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 32);
            this.label18.TabIndex = 100;
            this.label18.Text = "过高红色 \r\n过低蓝色\r\n";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(1081, 174);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 12);
            this.label20.TabIndex = 92;
            this.label20.Text = "电压 最小值";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("宋体", 12F);
            this.label17.Location = new System.Drawing.Point(1039, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 21);
            this.label17.TabIndex = 99;
            this.label17.Text = "电压";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1081, 41);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 12);
            this.label19.TabIndex = 91;
            this.label19.Text = "电流 最大值";
            // 
            // test2
            // 
            this.test2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.test2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test2.Font = new System.Drawing.Font("宋体", 12F);
            this.test2.ForeColor = System.Drawing.Color.Brown;
            this.test2.Location = new System.Drawing.Point(1042, 89);
            this.test2.Name = "test2";
            this.test2.Size = new System.Drawing.Size(33, 46);
            this.test2.TabIndex = 92;
            this.test2.Text = "4.无遮挡测试";
            this.test2.UseVisualStyleBackColor = false;
            this.test2.Click += new System.EventHandler(this.test2_Click);
            // 
            // VShow
            // 
            this.VShow.BackColor = System.Drawing.Color.AliceBlue;
            this.VShow.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.VShow.Location = new System.Drawing.Point(1042, 45);
            this.VShow.Multiline = true;
            this.VShow.Name = "VShow";
            this.VShow.ReadOnly = true;
            this.VShow.Size = new System.Drawing.Size(38, 36);
            this.VShow.TabIndex = 98;
            this.VShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VMin_textBox6
            // 
            this.VMin_textBox6.Location = new System.Drawing.Point(1083, 188);
            this.VMin_textBox6.Name = "VMin_textBox6";
            this.VMin_textBox6.Size = new System.Drawing.Size(80, 21);
            this.VMin_textBox6.TabIndex = 90;
            this.VMin_textBox6.Enter += new System.EventHandler(this.VMin_textBox6_Enter);
            // 
            // VMax_textBox5
            // 
            this.VMax_textBox5.Location = new System.Drawing.Point(1083, 141);
            this.VMax_textBox5.Name = "VMax_textBox5";
            this.VMax_textBox5.Size = new System.Drawing.Size(80, 21);
            this.VMax_textBox5.TabIndex = 89;
            this.VMax_textBox5.Leave += new System.EventHandler(this.VMax_textBox5_Leave);
            // 
            // testResult
            // 
            this.testResult.BackColor = System.Drawing.Color.AliceBlue;
            this.testResult.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testResult.Location = new System.Drawing.Point(1012, 141);
            this.testResult.Multiline = true;
            this.testResult.Name = "testResult";
            this.testResult.ReadOnly = true;
            this.testResult.Size = new System.Drawing.Size(63, 44);
            this.testResult.TabIndex = 89;
            this.testResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IShow
            // 
            this.IShow.BackColor = System.Drawing.Color.AliceBlue;
            this.IShow.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.IShow.Location = new System.Drawing.Point(998, 42);
            this.IShow.Multiline = true;
            this.IShow.Name = "IShow";
            this.IShow.ReadOnly = true;
            this.IShow.Size = new System.Drawing.Size(38, 39);
            this.IShow.TabIndex = 97;
            this.IShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // test1
            // 
            this.test1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.test1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test1.Font = new System.Drawing.Font("宋体", 12F);
            this.test1.ForeColor = System.Drawing.Color.Yellow;
            this.test1.Location = new System.Drawing.Point(1012, 89);
            this.test1.Name = "test1";
            this.test1.Size = new System.Drawing.Size(33, 46);
            this.test1.TabIndex = 87;
            this.test1.Text = "4.有遮挡测试";
            this.test1.UseVisualStyleBackColor = false;
            this.test1.Click += new System.EventHandler(this.test1_Click);
            // 
            // IMax_textBox4
            // 
            this.IMax_textBox4.Location = new System.Drawing.Point(1083, 60);
            this.IMax_textBox4.Name = "IMax_textBox4";
            this.IMax_textBox4.Size = new System.Drawing.Size(80, 21);
            this.IMax_textBox4.TabIndex = 88;
            this.IMax_textBox4.Leave += new System.EventHandler(this.IMax_textBox4_Leave);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.freshConnectPeri);
            this.groupBox4.Controls.Add(this.reciveShow);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.sendBLE);
            this.groupBox4.Controls.Add(this.sendBLE_textBox2);
            this.groupBox4.Controls.Add(this.clearAfterSendBLE_checkBox1);
            this.groupBox4.Controls.Add(this.clearSendRecoedBLE);
            this.groupBox4.Controls.Add(this.HexSendBLE_checkBox1);
            this.groupBox4.Controls.Add(this.returnN);
            this.groupBox4.Controls.Add(this.clearReadBleText);
            this.groupBox4.Controls.Add(this.readBLE);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.openN);
            this.groupBox4.Controls.Add(this.readBLE_textBox2);
            this.groupBox4.Controls.Add(this.periResult_textBox2);
            this.groupBox4.Location = new System.Drawing.Point(628, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(364, 214);
            this.groupBox4.TabIndex = 87;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "蓝牙收发";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.LightGreen;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("宋体", 15F);
            this.label13.ForeColor = System.Drawing.Color.DarkGreen;
            this.label13.Location = new System.Drawing.Point(319, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(216, 26);
            this.label13.TabIndex = 91;
            this.label13.Text = "3.选择设备";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(161, 316);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(125, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 93;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(22, 316);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(125, 23);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar2.TabIndex = 94;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(160, 171);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 95;
            this.label15.Text = "接收信息";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox2.Location = new System.Drawing.Point(533, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(262, 26);
            this.textBox2.TabIndex = 96;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.netStatus_textBox4);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Location = new System.Drawing.Point(824, 23);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(324, 116);
            this.groupBox5.TabIndex = 97;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "登陆信息";
            // 
            // netStatus_textBox4
            // 
            this.netStatus_textBox4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.netStatus_textBox4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.netStatus_textBox4.Location = new System.Drawing.Point(6, 16);
            this.netStatus_textBox4.Multiline = true;
            this.netStatus_textBox4.Name = "netStatus_textBox4";
            this.netStatus_textBox4.ReadOnly = true;
            this.netStatus_textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.netStatus_textBox4.Size = new System.Drawing.Size(227, 91);
            this.netStatus_textBox4.TabIndex = 72;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.YellowGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(243, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 71;
            this.button1.Text = "刷新网络";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.IDRecordResult_textBox7);
            this.groupBox6.Controls.Add(this.IDRecord);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.textBox6);
            this.groupBox6.Controls.Add(this.textBox4);
            this.groupBox6.Location = new System.Drawing.Point(824, 145);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(324, 116);
            this.groupBox6.TabIndex = 98;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "设置ID";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(204, 17);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 12);
            this.label29.TabIndex = 51;
            this.label29.Text = "设置结果";
            // 
            // IDRecordResult_textBox7
            // 
            this.IDRecordResult_textBox7.Location = new System.Drawing.Point(206, 32);
            this.IDRecordResult_textBox7.Multiline = true;
            this.IDRecordResult_textBox7.Name = "IDRecordResult_textBox7";
            this.IDRecordResult_textBox7.ReadOnly = true;
            this.IDRecordResult_textBox7.Size = new System.Drawing.Size(112, 78);
            this.IDRecordResult_textBox7.TabIndex = 50;
            // 
            // IDRecord
            // 
            this.IDRecord.BackColor = System.Drawing.Color.Yellow;
            this.IDRecord.Location = new System.Drawing.Point(125, 87);
            this.IDRecord.Name = "IDRecord";
            this.IDRecord.Size = new System.Drawing.Size(75, 23);
            this.IDRecord.TabIndex = 4;
            this.IDRecord.Text = "录入ID";
            this.IDRecord.UseVisualStyleBackColor = false;
            this.IDRecord.Click += new System.EventHandler(this.IDRecord_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(119, 26);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 12);
            this.label28.TabIndex = 3;
            this.label28.Text = "ID后四位";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 26);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 12);
            this.label27.TabIndex = 2;
            this.label27.Text = "ID前六位";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox6.Location = new System.Drawing.Point(6, 46);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(109, 32);
            this.textBox6.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox4.Location = new System.Drawing.Point(121, 46);
            this.textBox4.MaxLength = 4;
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(79, 32);
            this.textBox4.TabIndex = 0;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.CTPOCStatus_textBox7);
            this.groupBox7.Controls.Add(this.button3);
            this.groupBox7.Controls.Add(this.button2);
            this.groupBox7.Location = new System.Drawing.Point(824, 267);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(324, 101);
            this.groupBox7.TabIndex = 98;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "开关地锁";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(106, 17);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 53;
            this.label30.Text = "登陆结果";
            // 
            // CTPOCStatus_textBox7
            // 
            this.CTPOCStatus_textBox7.Location = new System.Drawing.Point(108, 37);
            this.CTPOCStatus_textBox7.Multiline = true;
            this.CTPOCStatus_textBox7.Name = "CTPOCStatus_textBox7";
            this.CTPOCStatus_textBox7.ReadOnly = true;
            this.CTPOCStatus_textBox7.Size = new System.Drawing.Size(210, 59);
            this.CTPOCStatus_textBox7.TabIndex = 52;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Violet;
            this.button3.Location = new System.Drawing.Point(15, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "关锁";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Chartreuse;
            this.button2.Location = new System.Drawing.Point(15, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "开锁";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // paraSet_groupBox8
            // 
            this.paraSet_groupBox8.Controls.Add(this.label26);
            this.paraSet_groupBox8.Controls.Add(this.textBox5);
            this.paraSet_groupBox8.Controls.Add(this.label25);
            this.paraSet_groupBox8.Controls.Add(this.loginResult_textBox4);
            this.paraSet_groupBox8.Controls.Add(this.login);
            this.paraSet_groupBox8.Controls.Add(this.label24);
            this.paraSet_groupBox8.Controls.Add(this.label23);
            this.paraSet_groupBox8.Controls.Add(this.label22);
            this.paraSet_groupBox8.Controls.Add(this.loginType_comboBox6);
            this.paraSet_groupBox8.Controls.Add(this.loginPassword_textBox5);
            this.paraSet_groupBox8.Controls.Add(this.loginAccount_textBox4);
            this.paraSet_groupBox8.Controls.Add(this.testMode_checkBox1);
            this.paraSet_groupBox8.Location = new System.Drawing.Point(2, 388);
            this.paraSet_groupBox8.Name = "paraSet_groupBox8";
            this.paraSet_groupBox8.Size = new System.Drawing.Size(1180, 61);
            this.paraSet_groupBox8.TabIndex = 99;
            this.paraSet_groupBox8.TabStop = false;
            this.paraSet_groupBox8.Text = "参数设置";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(795, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 50;
            this.label26.Text = "ID前六位";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(797, 32);
            this.textBox5.MaxLength = 6;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 1;
            this.textBox5.Text = "180510";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.textBox5.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(529, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 49;
            this.label25.Text = "登陆结果";
            // 
            // loginResult_textBox4
            // 
            this.loginResult_textBox4.Location = new System.Drawing.Point(528, 33);
            this.loginResult_textBox4.Name = "loginResult_textBox4";
            this.loginResult_textBox4.Size = new System.Drawing.Size(100, 21);
            this.loginResult_textBox4.TabIndex = 48;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(427, 31);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 47;
            this.login.Text = "登陆";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(313, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 46;
            this.label24.Text = "登陆类型";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(198, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 12);
            this.label23.TabIndex = 45;
            this.label23.Text = "登陆密码";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(88, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 44;
            this.label22.Text = "登陆账户";
            // 
            // loginType_comboBox6
            // 
            this.loginType_comboBox6.FormattingEnabled = true;
            this.loginType_comboBox6.Location = new System.Drawing.Point(315, 34);
            this.loginType_comboBox6.Name = "loginType_comboBox6";
            this.loginType_comboBox6.Size = new System.Drawing.Size(99, 20);
            this.loginType_comboBox6.TabIndex = 43;
            // 
            // loginPassword_textBox5
            // 
            this.loginPassword_textBox5.Location = new System.Drawing.Point(200, 33);
            this.loginPassword_textBox5.Name = "loginPassword_textBox5";
            this.loginPassword_textBox5.PasswordChar = '*';
            this.loginPassword_textBox5.Size = new System.Drawing.Size(100, 21);
            this.loginPassword_textBox5.TabIndex = 42;
            this.loginPassword_textBox5.Text = "123456";
            // 
            // loginAccount_textBox4
            // 
            this.loginAccount_textBox4.Location = new System.Drawing.Point(90, 33);
            this.loginAccount_textBox4.Name = "loginAccount_textBox4";
            this.loginAccount_textBox4.Size = new System.Drawing.Size(100, 21);
            this.loginAccount_textBox4.TabIndex = 41;
            this.loginAccount_textBox4.Text = "13912345678";
            // 
            // paraSet_checkBox1
            // 
            this.paraSet_checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.paraSet_checkBox1.AutoSize = true;
            this.paraSet_checkBox1.Location = new System.Drawing.Point(12, 360);
            this.paraSet_checkBox1.Name = "paraSet_checkBox1";
            this.paraSet_checkBox1.Size = new System.Drawing.Size(63, 22);
            this.paraSet_checkBox1.TabIndex = 41;
            this.paraSet_checkBox1.Text = "参数设置";
            this.paraSet_checkBox1.UseVisualStyleBackColor = true;
            this.paraSet_checkBox1.CheckedChanged += new System.EventHandler(this.paraSet_checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1170, 685);
            this.Controls.Add(this.paraSet_checkBox1);
            this.Controls.Add(this.paraSet_groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.openSwitch);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.recive_textBox3);
            this.Controls.Add(this.autoConnect_checkBox1);
            this.Controls.Add(this.testModeZone);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.disconnectPeri);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.periCount_textBox2);
            this.Controls.Add(this.connectPeri);
            this.Controls.Add(this.listViewFreshStyle);
            this.Controls.Add(this.listView1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地锁测试终端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.testModeZone.ResumeLayout(false);
            this.testModeZone.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.paraSet_groupBox8.ResumeLayout(false);
            this.paraSet_groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button freshPort;
        private System.Windows.Forms.CheckBox openSwitch;
        private System.Windows.Forms.TextBox portName_textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox autoConnect_checkBox1;
        private System.Windows.Forms.TextBox operationResult_textBox2;
        private System.Windows.Forms.Button clearOperationResult;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button clearSendRecoed;
        private System.Windows.Forms.CheckBox HexSend_checkBox1;
        private System.Windows.Forms.CheckBox pauseRecive_checkBox1;
        private System.Windows.Forms.CheckBox clearAfterSend_checkBox1;
        private System.Windows.Forms.CheckBox HexReciveShow_checkBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sent_textBox2;
        private System.Windows.Forms.Button clearRecive;
        private System.Windows.Forms.TextBox recive_textBox3;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox send_textBox2;
        private System.Windows.Forms.TextBox reciveShow;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader MAC;
        private System.Windows.Forms.ColumnHeader RSSI;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button returnMacList;
        private System.Windows.Forms.CheckBox searchHold;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.CheckBox listViewFreshStyle;
        private System.Windows.Forms.CheckBox oneButton_checkBox1;
        private System.Windows.Forms.CheckBox operationState_checkBox1;
        private System.Windows.Forms.Button connectPeri;
        private System.Windows.Forms.TextBox periCount_textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button disconnectPeri;
        private System.Windows.Forms.Button freshConnectPeri;
        private System.Windows.Forms.TextBox periResult_textBox2;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader ifConnect;
        private System.Windows.Forms.Button clearSendRecoedBLE;
        private System.Windows.Forms.CheckBox clearAfterSendBLE_checkBox1;
        private System.Windows.Forms.Button sendBLE;
        private System.Windows.Forms.TextBox sendBLE_textBox2;
        private System.Windows.Forms.CheckBox HexSendBLE_checkBox1;
        private System.Windows.Forms.TextBox readBLE_textBox2;
        private System.Windows.Forms.Button clearReadBleText;
        private System.Windows.Forms.Button readBLE;
        private System.Windows.Forms.Button openN;
        private System.Windows.Forms.Button returnN;
        private System.Windows.Forms.ColumnHeader UUID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox testMode_checkBox1;
        private System.Windows.Forms.GroupBox testModeZone;
        private System.Windows.Forms.Button test1;
        private System.Windows.Forms.TextBox testResult;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button test2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox IShow;
        private System.Windows.Forms.TextBox VShow;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox VMin_textBox6;
        private System.Windows.Forms.TextBox VMax_textBox5;
        private System.Windows.Forms.TextBox IMax_textBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox netStatus_textBox4;
        private System.Windows.Forms.GroupBox paraSet_groupBox8;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox loginType_comboBox6;
        private System.Windows.Forms.TextBox loginPassword_textBox5;
        private System.Windows.Forms.TextBox loginAccount_textBox4;
        private System.Windows.Forms.CheckBox paraSet_checkBox1;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox loginResult_textBox4;
        private System.Windows.Forms.Button IDRecord;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox IDRecordResult_textBox7;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox CTPOCStatus_textBox7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}

