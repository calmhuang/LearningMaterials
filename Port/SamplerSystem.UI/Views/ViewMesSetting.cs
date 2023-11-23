using SamplerSystem.UI.Models.Settings;
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
    public partial class ViewMesSetting : UserControl
    {
        public ViewMesSetting()
        {
            InitializeComponent();
        }

        public void SetData(MesSetting mesSetting)
        {
            cmbURLs.DataSource = mesSetting.Urls;
            cmbURLs.DataBindings.Add("SelectedValue", mesSetting, nameof(mesSetting.Url), true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
