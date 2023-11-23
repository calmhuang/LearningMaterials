namespace SamplerControlSystem
{
    partial class FormControlSystem
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudInjectionTime = new System.Windows.Forms.NumericUpDown();
            this.nudSample2 = new System.Windows.Forms.NumericUpDown();
            this.nudSample3 = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvStatus = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenCirculationFan = new System.Windows.Forms.Button();
            this.btnCloseExhaustFan = new System.Windows.Forms.Button();
            this.btnOpenExhaustFan = new System.Windows.Forms.Button();
            this.btnCloseExhaustValve = new System.Windows.Forms.Button();
            this.btnOpenExhaustValve = new System.Windows.Forms.Button();
            this.btnVerifSample3 = new System.Windows.Forms.Button();
            this.btnVerifSample2 = new System.Windows.Forms.Button();
            this.btnCloseInletValve = new System.Windows.Forms.Button();
            this.btnOpenInletValve = new System.Windows.Forms.Button();
            this.btnCloseCirculationFan = new System.Windows.Forms.Button();
            this.btnCylinderUpper = new System.Windows.Forms.Button();
            this.btnCylinderDown = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInjectionTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSample2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSample3)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudInjectionTime, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudSample2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudSample3, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(288, 124);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "注汽时间(s):";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "2校准浓度(ppm):";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "3校准浓度(ppm):";
            // 
            // nudInjectionTime
            // 
            this.nudInjectionTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudInjectionTime.DecimalPlaces = 3;
            this.nudInjectionTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudInjectionTime.Location = new System.Drawing.Point(123, 14);
            this.nudInjectionTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudInjectionTime.Name = "nudInjectionTime";
            this.nudInjectionTime.Size = new System.Drawing.Size(152, 21);
            this.nudInjectionTime.TabIndex = 3;
            // 
            // nudSample2
            // 
            this.nudSample2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSample2.DecimalPlaces = 1;
            this.nudSample2.Location = new System.Drawing.Point(123, 44);
            this.nudSample2.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSample2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.nudSample2.Name = "nudSample2";
            this.nudSample2.Size = new System.Drawing.Size(152, 21);
            this.nudSample2.TabIndex = 4;
            // 
            // nudSample3
            // 
            this.nudSample3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSample3.DecimalPlaces = 1;
            this.nudSample3.Location = new System.Drawing.Point(123, 74);
            this.nudSample3.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSample3.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.nudSample3.Name = "nudSample3";
            this.nudSample3.Size = new System.Drawing.Size(152, 21);
            this.nudSample3.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(782, 485);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvStatus);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(13, 13);
            this.groupBox3.Name = "groupBox3";
            this.tableLayoutPanel2.SetRowSpan(this.groupBox3, 3);
            this.groupBox3.Size = new System.Drawing.Size(456, 459);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "状态区域";
            // 
            // dgvStatus
            // 
            this.dgvStatus.AllowUserToAddRows = false;
            this.dgvStatus.AllowUserToDeleteRows = false;
            this.dgvStatus.AllowUserToResizeColumns = false;
            this.dgvStatus.AllowUserToResizeRows = false;
            this.dgvStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatus.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatus.ColumnHeadersVisible = false;
            this.dgvStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatus.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvStatus.Location = new System.Drawing.Point(3, 17);
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.RowHeadersVisible = false;
            this.dgvStatus.RowTemplate.Height = 23;
            this.dgvStatus.Size = new System.Drawing.Size(450, 439);
            this.dgvStatus.TabIndex = 0;
            this.dgvStatus.VirtualMode = true;
            this.dgvStatus.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStatus_CellFormatting);
            this.dgvStatus.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvStatus_CellValueNeeded);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(475, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 269);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "指令区域";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnOpenCirculationFan, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.btnCloseExhaustFan, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnOpenExhaustFan, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnCloseExhaustValve, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnOpenExhaustValve, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnVerifSample3, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnVerifSample2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnCloseInletValve, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnOpenInletValve, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCloseCirculationFan, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.btnCylinderUpper, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.btnCylinderDown, 1, 5);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel3.RowCount = 10;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(288, 249);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnOpenCirculationFan
            // 
            this.btnOpenCirculationFan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenCirculationFan.Location = new System.Drawing.Point(13, 133);
            this.btnOpenCirculationFan.Name = "btnOpenCirculationFan";
            this.btnOpenCirculationFan.Size = new System.Drawing.Size(124, 24);
            this.btnOpenCirculationFan.TabIndex = 8;
            this.btnOpenCirculationFan.Text = "打开循环风扇";
            this.btnOpenCirculationFan.UseVisualStyleBackColor = true;
            this.btnOpenCirculationFan.Click += new System.EventHandler(this.btnOpenCirculationFan_Click);
            // 
            // btnCloseExhaustFan
            // 
            this.btnCloseExhaustFan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseExhaustFan.Location = new System.Drawing.Point(143, 103);
            this.btnCloseExhaustFan.Name = "btnCloseExhaustFan";
            this.btnCloseExhaustFan.Size = new System.Drawing.Size(132, 24);
            this.btnCloseExhaustFan.TabIndex = 7;
            this.btnCloseExhaustFan.Text = "关闭排气扇";
            this.btnCloseExhaustFan.UseVisualStyleBackColor = true;
            this.btnCloseExhaustFan.Click += new System.EventHandler(this.btnCloseExhaustFan_Click);
            // 
            // btnOpenExhaustFan
            // 
            this.btnOpenExhaustFan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenExhaustFan.Location = new System.Drawing.Point(13, 103);
            this.btnOpenExhaustFan.Name = "btnOpenExhaustFan";
            this.btnOpenExhaustFan.Size = new System.Drawing.Size(124, 24);
            this.btnOpenExhaustFan.TabIndex = 6;
            this.btnOpenExhaustFan.Text = "打开排气扇";
            this.btnOpenExhaustFan.UseVisualStyleBackColor = true;
            this.btnOpenExhaustFan.Click += new System.EventHandler(this.btnOpenExhaustFan_Click);
            // 
            // btnCloseExhaustValve
            // 
            this.btnCloseExhaustValve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseExhaustValve.Location = new System.Drawing.Point(143, 73);
            this.btnCloseExhaustValve.Name = "btnCloseExhaustValve";
            this.btnCloseExhaustValve.Size = new System.Drawing.Size(132, 24);
            this.btnCloseExhaustValve.TabIndex = 5;
            this.btnCloseExhaustValve.Text = "关闭排气阀";
            this.btnCloseExhaustValve.UseVisualStyleBackColor = true;
            this.btnCloseExhaustValve.Click += new System.EventHandler(this.btnCloseExhaustValve_Click);
            // 
            // btnOpenExhaustValve
            // 
            this.btnOpenExhaustValve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenExhaustValve.Location = new System.Drawing.Point(13, 73);
            this.btnOpenExhaustValve.Name = "btnOpenExhaustValve";
            this.btnOpenExhaustValve.Size = new System.Drawing.Size(124, 24);
            this.btnOpenExhaustValve.TabIndex = 4;
            this.btnOpenExhaustValve.Text = "打开排气阀";
            this.btnOpenExhaustValve.UseVisualStyleBackColor = true;
            this.btnOpenExhaustValve.Click += new System.EventHandler(this.btnOpenExhaustValve_Click);
            // 
            // btnVerifSample3
            // 
            this.btnVerifSample3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerifSample3.Location = new System.Drawing.Point(143, 43);
            this.btnVerifSample3.Name = "btnVerifSample3";
            this.btnVerifSample3.Size = new System.Drawing.Size(132, 24);
            this.btnVerifSample3.TabIndex = 3;
            this.btnVerifSample3.Text = "标定3校准";
            this.btnVerifSample3.UseVisualStyleBackColor = true;
            this.btnVerifSample3.Click += new System.EventHandler(this.btnVerifSample3_Click);
            // 
            // btnVerifSample2
            // 
            this.btnVerifSample2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerifSample2.Location = new System.Drawing.Point(13, 43);
            this.btnVerifSample2.Name = "btnVerifSample2";
            this.btnVerifSample2.Size = new System.Drawing.Size(124, 24);
            this.btnVerifSample2.TabIndex = 2;
            this.btnVerifSample2.Text = "标定2校准";
            this.btnVerifSample2.UseVisualStyleBackColor = true;
            this.btnVerifSample2.Click += new System.EventHandler(this.btnVerifSample2_Click);
            // 
            // btnCloseInletValve
            // 
            this.btnCloseInletValve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseInletValve.Location = new System.Drawing.Point(143, 13);
            this.btnCloseInletValve.Name = "btnCloseInletValve";
            this.btnCloseInletValve.Size = new System.Drawing.Size(132, 24);
            this.btnCloseInletValve.TabIndex = 1;
            this.btnCloseInletValve.Text = "关闭进气阀";
            this.btnCloseInletValve.UseVisualStyleBackColor = true;
            this.btnCloseInletValve.Click += new System.EventHandler(this.btnCloseInletValve_Click);
            // 
            // btnOpenInletValve
            // 
            this.btnOpenInletValve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenInletValve.Location = new System.Drawing.Point(13, 13);
            this.btnOpenInletValve.Name = "btnOpenInletValve";
            this.btnOpenInletValve.Size = new System.Drawing.Size(124, 24);
            this.btnOpenInletValve.TabIndex = 0;
            this.btnOpenInletValve.Text = "打开进气阀";
            this.btnOpenInletValve.UseVisualStyleBackColor = true;
            this.btnOpenInletValve.Click += new System.EventHandler(this.btnOpenInletValve_Click);
            // 
            // btnCloseCirculationFan
            // 
            this.btnCloseCirculationFan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseCirculationFan.Location = new System.Drawing.Point(143, 133);
            this.btnCloseCirculationFan.Name = "btnCloseCirculationFan";
            this.btnCloseCirculationFan.Size = new System.Drawing.Size(132, 24);
            this.btnCloseCirculationFan.TabIndex = 9;
            this.btnCloseCirculationFan.Text = "关闭循环风扇";
            this.btnCloseCirculationFan.UseVisualStyleBackColor = true;
            this.btnCloseCirculationFan.Click += new System.EventHandler(this.btnCloseCirculationFan_Click);
            // 
            // btnCylinderUpper
            // 
            this.btnCylinderUpper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCylinderUpper.Location = new System.Drawing.Point(13, 163);
            this.btnCylinderUpper.Name = "btnCylinderUpper";
            this.btnCylinderUpper.Size = new System.Drawing.Size(124, 24);
            this.btnCylinderUpper.TabIndex = 10;
            this.btnCylinderUpper.Text = "气缸上升";
            this.btnCylinderUpper.UseVisualStyleBackColor = true;
            this.btnCylinderUpper.Click += new System.EventHandler(this.btnCylinderUpper_Click);
            // 
            // btnCylinderDown
            // 
            this.btnCylinderDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCylinderDown.Location = new System.Drawing.Point(143, 163);
            this.btnCylinderDown.Name = "btnCylinderDown";
            this.btnCylinderDown.Size = new System.Drawing.Size(132, 24);
            this.btnCylinderDown.TabIndex = 11;
            this.btnCylinderDown.Text = "气缸下降";
            this.btnCylinderDown.UseVisualStyleBackColor = true;
            this.btnCylinderDown.Click += new System.EventHandler(this.btnCylinderDown_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(475, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置区域";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.Controls.Add(this.btnExit, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(475, 438);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(294, 34);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(217, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 28);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormControlSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 485);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "FormControlSystem";
            this.Text = "测试模式";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormControlSystem_FormClosing);
            this.Load += new System.EventHandler(this.FormControlSystem_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInjectionTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSample2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSample3)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudInjectionTime;
        private System.Windows.Forms.NumericUpDown nudSample2;
        private System.Windows.Forms.NumericUpDown nudSample3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnOpenInletValve;
        private System.Windows.Forms.Button btnOpenCirculationFan;
        private System.Windows.Forms.Button btnCloseExhaustFan;
        private System.Windows.Forms.Button btnOpenExhaustFan;
        private System.Windows.Forms.Button btnCloseExhaustValve;
        private System.Windows.Forms.Button btnOpenExhaustValve;
        private System.Windows.Forms.Button btnVerifSample3;
        private System.Windows.Forms.Button btnVerifSample2;
        private System.Windows.Forms.Button btnCloseInletValve;
        private System.Windows.Forms.Button btnCloseCirculationFan;
        private System.Windows.Forms.Button btnCylinderUpper;
        private System.Windows.Forms.Button btnCylinderDown;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnExit;
    }
}