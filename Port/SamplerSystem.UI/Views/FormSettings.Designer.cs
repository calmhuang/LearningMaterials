namespace SamplerSystem.UI.Views
{
    partial class FormSettings
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbCategories = new System.Windows.Forms.ListBox();
            this.viewPortSetting1 = new SamplerSystem.UI.Views.ViewPortSetting();
            this.viewControlBoardSetting1 = new SamplerSystem.UI.Views.ViewControlBoardSetting();
            this.viewMesSetting1 = new SamplerSystem.UI.Views.ViewMesSetting();
            this.viewBasicSetting1 = new SamplerSystem.UI.Views.viewBasicSetting();
            this.viewFilePath1 = new SamplerSystem.UI.Views.ViewFilePath();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbCategories, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(903, 565);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(821, 528);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.viewPortSetting1);
            this.flowLayoutPanel1.Controls.Add(this.viewControlBoardSetting1);
            this.flowLayoutPanel1.Controls.Add(this.viewMesSetting1);
            this.flowLayoutPanel1.Controls.Add(this.viewBasicSetting1);
            this.flowLayoutPanel1.Controls.Add(this.viewFilePath1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(193, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(697, 509);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(740, 528);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lbCategories
            // 
            this.lbCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCategories.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbCategories.FormattingEnabled = true;
            this.lbCategories.ItemHeight = 40;
            this.lbCategories.Location = new System.Drawing.Point(13, 13);
            this.lbCategories.Name = "lbCategories";
            this.tableLayoutPanel1.SetRowSpan(this.lbCategories, 2);
            this.lbCategories.Size = new System.Drawing.Size(174, 539);
            this.lbCategories.TabIndex = 4;
            this.lbCategories.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawItemEventHandler);
            // 
            // viewPortSetting1
            // 
            this.viewPortSetting1.Location = new System.Drawing.Point(3, 3);
            this.viewPortSetting1.Name = "viewPortSetting1";
            this.viewPortSetting1.Size = new System.Drawing.Size(667, 214);
            this.viewPortSetting1.TabIndex = 0;
            // 
            // viewControlBoardSetting1
            // 
            this.viewControlBoardSetting1.Location = new System.Drawing.Point(3, 223);
            this.viewControlBoardSetting1.Name = "viewControlBoardSetting1";
            this.viewControlBoardSetting1.Size = new System.Drawing.Size(667, 506);
            this.viewControlBoardSetting1.TabIndex = 1;
            // 
            // viewMesSetting1
            // 
            this.viewMesSetting1.Location = new System.Drawing.Point(3, 735);
            this.viewMesSetting1.Name = "viewMesSetting1";
            this.viewMesSetting1.Size = new System.Drawing.Size(667, 203);
            this.viewMesSetting1.TabIndex = 2;
            // 
            // viewBasicSetting1
            // 
            this.viewBasicSetting1.Location = new System.Drawing.Point(3, 944);
            this.viewBasicSetting1.Name = "viewBasicSetting1";
            this.viewBasicSetting1.Size = new System.Drawing.Size(667, 486);
            this.viewBasicSetting1.TabIndex = 3;
            // 
            // viewFilePath1
            // 
            this.viewFilePath1.Location = new System.Drawing.Point(3, 1436);
            this.viewFilePath1.Name = "viewFilePath1";
            this.viewFilePath1.Size = new System.Drawing.Size(667, 374);
            this.viewFilePath1.TabIndex = 4;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 565);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnOK;
        private ViewPortSetting viewPortSetting1;
        private System.Windows.Forms.ListBox lbCategories;
        private ViewControlBoardSetting viewControlBoardSetting1;
        private ViewMesSetting viewMesSetting1;
        private viewBasicSetting viewBasicSetting1;
        private ViewFilePath viewFilePath1;
    }
}