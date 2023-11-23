namespace SamplerSystem.UI.Views
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatusChange = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSerialPortInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslIsOnline = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCompanyName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnControlSystem = new System.Windows.Forms.Button();
            this.btnMesInfo = new System.Windows.Forms.Button();
            this.btnTraySet = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblWOStatus = new System.Windows.Forms.Label();
            this.lblMNType = new System.Windows.Forms.Label();
            this.lblMNName = new System.Windows.Forms.Label();
            this.lblMN = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSampleStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFixtureInfo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStatusMsg = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTestStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvSampleInfo = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvStatusInfo = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbPortCommandInfo = new System.Windows.Forms.TextBox();
            this.chbIsOffline = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleInfo)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusInfo)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(895, 589);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatusChange,
            this.tsslSerialPortInfo,
            this.toolStripStatusLabel1,
            this.tsslUserName,
            this.tsslIsOnline,
            this.tsslCompanyName});
            this.statusStrip1.Location = new System.Drawing.Point(5, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(885, 30);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatusChange
            // 
            this.tsslStatusChange.DoubleClickEnabled = true;
            this.tsslStatusChange.ForeColor = System.Drawing.Color.Blue;
            this.tsslStatusChange.Name = "tsslStatusChange";
            this.tsslStatusChange.Size = new System.Drawing.Size(56, 25);
            this.tsslStatusChange.Text = "打开串口";
            this.tsslStatusChange.DoubleClick += new System.EventHandler(this.tsslStatusChange_DoubleClickAsync);
            // 
            // tsslSerialPortInfo
            // 
            this.tsslSerialPortInfo.Name = "tsslSerialPortInfo";
            this.tsslSerialPortInfo.Size = new System.Drawing.Size(68, 25);
            this.tsslSerialPortInfo.Text = "串口未打开";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 25);
            this.toolStripStatusLabel1.Text = "用户:";
            // 
            // tsslUserName
            // 
            this.tsslUserName.ForeColor = System.Drawing.Color.Blue;
            this.tsslUserName.Name = "tsslUserName";
            this.tsslUserName.Size = new System.Drawing.Size(31, 25);
            this.tsslUserName.Text = "[***]";
            this.tsslUserName.DoubleClick += new System.EventHandler(this.tsslUserName_DoubleClick);
            // 
            // tsslIsOnline
            // 
            this.tsslIsOnline.Name = "tsslIsOnline";
            this.tsslIsOnline.Size = new System.Drawing.Size(56, 25);
            this.tsslIsOnline.Text = "在线状态";
            // 
            // tsslCompanyName
            // 
            this.tsslCompanyName.Name = "tsslCompanyName";
            this.tsslCompanyName.Size = new System.Drawing.Size(32, 25);
            this.tsslCompanyName.Text = "厂商";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnSetting, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnControlSystem, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnMesInfo, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTraySet, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 477);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(629, 74);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Location = new System.Drawing.Point(3, 3);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(74, 68);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.Text = "设置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(141, 3);
            this.btnTest.Name = "btnTest";
            this.tableLayoutPanel6.SetRowSpan(this.btnTest, 2);
            this.btnTest.Size = new System.Drawing.Size(94, 68);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "开始标定";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnControlSystem
            // 
            this.btnControlSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControlSystem.Location = new System.Drawing.Point(163, 3);
            this.btnControlSystem.Name = "btnControlSystem";
            this.btnControlSystem.Size = new System.Drawing.Size(74, 68);
            this.btnControlSystem.TabIndex = 1;
            this.btnControlSystem.Text = "测试模式";
            this.btnControlSystem.UseVisualStyleBackColor = true;
            this.btnControlSystem.Click += new System.EventHandler(this.btnControlSystem_Click);
            // 
            // btnMesInfo
            // 
            this.btnMesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMesInfo.Location = new System.Drawing.Point(323, 3);
            this.btnMesInfo.Name = "btnMesInfo";
            this.btnMesInfo.Size = new System.Drawing.Size(74, 68);
            this.btnMesInfo.TabIndex = 2;
            this.btnMesInfo.Text = "工单信息";
            this.btnMesInfo.UseVisualStyleBackColor = true;
            this.btnMesInfo.Click += new System.EventHandler(this.btnMesInfo_Click);
            // 
            // btnTraySet
            // 
            this.btnTraySet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTraySet.Location = new System.Drawing.Point(403, 3);
            this.btnTraySet.Name = "btnTraySet";
            this.btnTraySet.Size = new System.Drawing.Size(74, 68);
            this.btnTraySet.TabIndex = 3;
            this.btnTraySet.Text = "托盘设置";
            this.btnTraySet.UseVisualStyleBackColor = true;
            this.btnTraySet.Click += new System.EventHandler(this.btnTraySet_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(643, 8);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(244, 543);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 174);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工单信息";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.lblWOStatus, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.lblMNType, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.lblMNName, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.lblMN, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblWO, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 6;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(232, 154);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // lblWOStatus
            // 
            this.lblWOStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWOStatus.AutoSize = true;
            this.lblWOStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblWOStatus.Location = new System.Drawing.Point(83, 129);
            this.lblWOStatus.Name = "lblWOStatus";
            this.lblWOStatus.Size = new System.Drawing.Size(146, 12);
            this.lblWOStatus.TabIndex = 12;
            this.lblWOStatus.Text = "******";
            // 
            // lblMNType
            // 
            this.lblMNType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMNType.AutoSize = true;
            this.lblMNType.ForeColor = System.Drawing.Color.Blue;
            this.lblMNType.Location = new System.Drawing.Point(83, 99);
            this.lblMNType.Name = "lblMNType";
            this.lblMNType.Size = new System.Drawing.Size(146, 12);
            this.lblMNType.TabIndex = 11;
            this.lblMNType.Text = "******";
            // 
            // lblMNName
            // 
            this.lblMNName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMNName.AutoSize = true;
            this.lblMNName.ForeColor = System.Drawing.Color.Blue;
            this.lblMNName.Location = new System.Drawing.Point(83, 69);
            this.lblMNName.Name = "lblMNName";
            this.lblMNName.Size = new System.Drawing.Size(146, 12);
            this.lblMNName.TabIndex = 10;
            this.lblMNName.Text = "******";
            // 
            // lblMN
            // 
            this.lblMN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMN.AutoSize = true;
            this.lblMN.ForeColor = System.Drawing.Color.Blue;
            this.lblMN.Location = new System.Drawing.Point(83, 39);
            this.lblMN.Name = "lblMN";
            this.lblMN.Size = new System.Drawing.Size(146, 12);
            this.lblMN.TabIndex = 9;
            this.lblMN.Text = "******";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "工单状态:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "物料类型:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "物料名称:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "料号:";
            // 
            // lblWO
            // 
            this.lblWO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWO.AutoSize = true;
            this.lblWO.ForeColor = System.Drawing.Color.Blue;
            this.lblWO.Location = new System.Drawing.Point(83, 9);
            this.lblWO.Name = "lblWO";
            this.lblWO.Size = new System.Drawing.Size(146, 12);
            this.lblWO.TabIndex = 1;
            this.lblWO.Text = "******";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工单号:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 277);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "状态信息";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.lblStartTime, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblSampleStatus, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.lblFixtureInfo, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.lblStatusMsg, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.lblTestStatus, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(232, 257);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.ForeColor = System.Drawing.Color.Blue;
            this.lblStartTime.Location = new System.Drawing.Point(83, 9);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(146, 12);
            this.lblStartTime.TabIndex = 13;
            this.lblStartTime.Text = "2023/11/10 13:30:00";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "开始时间:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "标定阶段:";
            // 
            // lblSampleStatus
            // 
            this.lblSampleStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSampleStatus.AutoSize = true;
            this.lblSampleStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSampleStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblSampleStatus.Location = new System.Drawing.Point(83, 37);
            this.lblSampleStatus.Name = "lblSampleStatus";
            this.lblSampleStatus.Size = new System.Drawing.Size(146, 16);
            this.lblSampleStatus.TabIndex = 17;
            this.lblSampleStatus.Text = "等待预热";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "主机状态:";
            // 
            // lblFixtureInfo
            // 
            this.lblFixtureInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFixtureInfo.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.lblFixtureInfo, 2);
            this.lblFixtureInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFixtureInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblFixtureInfo.Location = new System.Drawing.Point(3, 129);
            this.lblFixtureInfo.Name = "lblFixtureInfo";
            this.lblFixtureInfo.Size = new System.Drawing.Size(226, 16);
            this.lblFixtureInfo.TabIndex = 15;
            this.lblFixtureInfo.Text = "浓度: 温度: 湿度:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "详情描述:";
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusMsg.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.lblStatusMsg, 2);
            this.lblStatusMsg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatusMsg.ForeColor = System.Drawing.Color.Blue;
            this.lblStatusMsg.Location = new System.Drawing.Point(3, 194);
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(226, 16);
            this.lblStatusMsg.TabIndex = 19;
            this.lblStatusMsg.Text = "无";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "测试阶段:";
            // 
            // lblTestStatus
            // 
            this.lblTestStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTestStatus.AutoSize = true;
            this.lblTestStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTestStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblTestStatus.Location = new System.Drawing.Point(83, 67);
            this.lblTestStatus.Name = "lblTestStatus";
            this.lblTestStatus.Size = new System.Drawing.Size(146, 16);
            this.lblTestStatus.TabIndex = 21;
            this.lblTestStatus.Text = "初始化参数";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel6.Controls.Add(this.chbIsOffline, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.btnTest, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(238, 74);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(629, 463);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvSampleInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(621, 437);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "标定信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvSampleInfo
            // 
            this.dgvSampleInfo.AllowUserToAddRows = false;
            this.dgvSampleInfo.AllowUserToDeleteRows = false;
            this.dgvSampleInfo.AllowUserToResizeColumns = false;
            this.dgvSampleInfo.AllowUserToResizeRows = false;
            this.dgvSampleInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvSampleInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSampleInfo.ColumnHeadersVisible = false;
            this.dgvSampleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSampleInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSampleInfo.Location = new System.Drawing.Point(3, 3);
            this.dgvSampleInfo.Name = "dgvSampleInfo";
            this.dgvSampleInfo.RowHeadersVisible = false;
            this.dgvSampleInfo.RowTemplate.Height = 23;
            this.dgvSampleInfo.Size = new System.Drawing.Size(615, 431);
            this.dgvSampleInfo.TabIndex = 0;
            this.dgvSampleInfo.VirtualMode = true;
            this.dgvSampleInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSampleInfo_CellDoubleClick);
            this.dgvSampleInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSampleInfo_CellFormatting);
            this.dgvSampleInfo.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvSampleInfo_CellValueNeeded);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvStatusInfo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(621, 437);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "主机状态信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvStatusInfo
            // 
            this.dgvStatusInfo.AllowUserToAddRows = false;
            this.dgvStatusInfo.AllowUserToDeleteRows = false;
            this.dgvStatusInfo.AllowUserToResizeColumns = false;
            this.dgvStatusInfo.AllowUserToResizeRows = false;
            this.dgvStatusInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatusInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatusInfo.ColumnHeadersVisible = false;
            this.dgvStatusInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatusInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvStatusInfo.Location = new System.Drawing.Point(3, 3);
            this.dgvStatusInfo.Name = "dgvStatusInfo";
            this.dgvStatusInfo.RowHeadersVisible = false;
            this.dgvStatusInfo.RowTemplate.Height = 23;
            this.dgvStatusInfo.Size = new System.Drawing.Size(615, 431);
            this.dgvStatusInfo.TabIndex = 0;
            this.dgvStatusInfo.VirtualMode = true;
            this.dgvStatusInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStatusInfo_CellFormatting);
            this.dgvStatusInfo.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvStatusInfo_CellValueNeeded);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbPortCommandInfo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(621, 437);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "串口指令信息";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbPortCommandInfo
            // 
            this.tbPortCommandInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPortCommandInfo.Location = new System.Drawing.Point(3, 3);
            this.tbPortCommandInfo.Multiline = true;
            this.tbPortCommandInfo.Name = "tbPortCommandInfo";
            this.tbPortCommandInfo.ReadOnly = true;
            this.tbPortCommandInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPortCommandInfo.Size = new System.Drawing.Size(615, 431);
            this.tbPortCommandInfo.TabIndex = 0;
            this.tbPortCommandInfo.TabStop = false;
            // 
            // chbIsOffline
            // 
            this.chbIsOffline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chbIsOffline.AutoSize = true;
            this.chbIsOffline.Location = new System.Drawing.Point(3, 51);
            this.chbIsOffline.Name = "chbIsOffline";
            this.chbIsOffline.Size = new System.Drawing.Size(132, 16);
            this.chbIsOffline.TabIndex = 0;
            this.chbIsOffline.Text = "单机模式";
            this.chbIsOffline.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 589);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "海曼标定系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSampleInfo)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusInfo)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnControlSystem;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvSampleInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvStatusInfo;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatusChange;
        private System.Windows.Forms.ToolStripStatusLabel tsslSerialPortInfo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbPortCommandInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWOStatus;
        private System.Windows.Forms.Label lblMNType;
        private System.Windows.Forms.Label lblMNName;
        private System.Windows.Forms.Label lblMN;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel tsslCompanyName;
        private System.Windows.Forms.Button btnMesInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslUserName;
        private System.Windows.Forms.ToolStripStatusLabel tsslIsOnline;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFixtureInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSampleStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblStatusMsg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTestStatus;
        private System.Windows.Forms.Button btnTraySet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckBox chbIsOffline;
    }
}