using SamplerSystem.UI.Models.Settings;
using SamplerSystem.UI.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplerSystem.UI.Views
{
    public partial class FormSettings : Form
    {
        private readonly SysSettings _settings;

        //private SysSettings _origin;
        public SysSettings Settings { get; }

        private Dictionary<string, List<UserControl>> _categories = new Dictionary<string, List<UserControl>>();

        public FormSettings(SysSettings settings)
        {
            InitializeComponent();

            _settings = settings;

            Settings = Objects.DeepClone(settings);
            //_settings = //(SysSettings) settings.Clone();

            lbCategories.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

            _categories.Add("标定基础设置", new List<UserControl> { viewBasicSetting1 });
            _categories.Add("串口设置", new List<UserControl> { viewPortSetting1 });
            _categories.Add("传感器标定参数设置", new List<UserControl> { viewControlBoardSetting1 });
            _categories.Add("MES设置", new List<UserControl> { viewMesSetting1 });
            _categories.Add("文件路径设置", new List<UserControl> { viewFilePath1 });
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UserControl uc)
                {
                    uc.Visible = false;
                }
            }

            foreach (var uc in _categories[lbCategories.SelectedItem.ToString()])
                uc.Visible = true;
        }

        private void DrawItemEventHandler(object sender, DrawItemEventArgs e)
        {
            if (sender == null) return;
            var lb = (ListBox)sender;

            e.DrawBackground();
            e.DrawFocusRectangle();
            var fmt = new StringFormat
            {
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, fmt);
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (var ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UserControl uc)
                {
                    uc.Size = new Size(flowLayoutPanel1.Width - 15, uc.Height);
                }
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            lbCategories.DataSource = _categories.Keys.ToList();
            flowLayoutPanel1_Resize(null, null);

            viewPortSetting1.SetData(Settings.PortSettings);
            viewControlBoardSetting1.SetData(Settings.SensorBoardSettings);
            viewMesSetting1.SetData(Settings.MesSettings);
            viewBasicSetting1.SetData(Settings.BasicSettings);
            viewFilePath1.SetData(Settings.FileSettings);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
