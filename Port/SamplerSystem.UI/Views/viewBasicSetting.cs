using SamplerSystem.UI.Models.Settings;
using System.Windows.Forms;

namespace SamplerSystem.UI.Views
{
    public partial class viewBasicSetting : UserControl
    {
        public viewBasicSetting()
        {
            InitializeComponent();
        }

        public void SetData(BasicSetting basicSetting)
        {
            nudSensorBradNum.DataBindings.Add("Value", basicSetting, nameof(basicSetting.SensorBradNum), true, DataSourceUpdateMode.OnPropertyChanged);
            nudSensorNum.DataBindings.Add("Value", basicSetting, nameof(basicSetting.SensorNum), true, DataSourceUpdateMode.OnPropertyChanged);
            nudTrayCol.DataBindings.Add("Value", basicSetting, nameof(basicSetting.TrayCol), true, DataSourceUpdateMode.OnPropertyChanged);
            nudTrayRow.DataBindings.Add("Value", basicSetting, nameof(basicSetting.TrayRow), true, DataSourceUpdateMode.OnPropertyChanged);
            nudTrayNum.DataBindings.Add("Value", basicSetting, nameof(basicSetting.TrayNum), true, DataSourceUpdateMode.OnPropertyChanged);
            nudInjectionTime.DataBindings.Add("Value", basicSetting, nameof(basicSetting.InjectionTime), true, DataSourceUpdateMode.OnPropertyChanged);
            nudSample2.DataBindings.Add("Value", basicSetting, nameof(basicSetting.Sample2), true, DataSourceUpdateMode.OnPropertyChanged);
            nudSample3.DataBindings.Add("Value", basicSetting, nameof(basicSetting.Sample3), true, DataSourceUpdateMode.OnPropertyChanged);
            nudRefreshTime.DataBindings.Add("Value", basicSetting, nameof(basicSetting.RefreshTime), true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
