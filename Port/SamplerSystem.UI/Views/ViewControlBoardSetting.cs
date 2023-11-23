using SamplerControlSystem.Condition;
using SamplerControlSystem.Model;
using System;
using System.Windows.Forms;

namespace SamplerSystem.UI.Views
{
    public partial class ViewControlBoardSetting : UserControl
    {
        private SensorBoardSetting _sensorBoardSettings;

        public ViewControlBoardSetting()
        {
            InitializeComponent();
        }

        public void SetData(SensorBoardSetting sensorBoardSettings)
        {
            _sensorBoardSettings = sensorBoardSettings;
            cmbGasType.DataSource = Enum.GetNames(typeof(GasType));
            cmbGasType.DataBindings.Add("Text", sensorBoardSettings, nameof(sensorBoardSettings.GasType),
            true, DataSourceUpdateMode.OnPropertyChanged);


            nudHumidityD.DataBindings.Add("Value", sensorBoardSettings.HumidityLimit, nameof(sensorBoardSettings.HumidityLimit.Min),
             true, DataSourceUpdateMode.OnPropertyChanged);
            nudHumidityU.DataBindings.Add("Value", sensorBoardSettings.HumidityLimit, nameof(sensorBoardSettings.HumidityLimit.Max),
 true, DataSourceUpdateMode.OnPropertyChanged);

            nudVoltageLimitD.DataBindings.Add("Value", sensorBoardSettings.VoltageLimit, nameof(sensorBoardSettings.VoltageLimit.Min),
 true, DataSourceUpdateMode.OnPropertyChanged);
            nudVoltageLimitU.DataBindings.Add("Value", sensorBoardSettings.VoltageLimit, nameof(sensorBoardSettings.VoltageLimit.Max),
 true, DataSourceUpdateMode.OnPropertyChanged);

            nudTemperatureD.DataBindings.Add("Value", sensorBoardSettings.TemperatureLimit, nameof(sensorBoardSettings.TemperatureLimit.Min),
 true, DataSourceUpdateMode.OnPropertyChanged);
            nudTemperatureU.DataBindings.Add("Value", sensorBoardSettings.TemperatureLimit, nameof(sensorBoardSettings.TemperatureLimit.Max),
 true, DataSourceUpdateMode.OnPropertyChanged);

            nudSlopeLimitD.DataBindings.Add("Value", sensorBoardSettings.SlopeLimit, nameof(sensorBoardSettings.SlopeLimit.Min),
 true, DataSourceUpdateMode.OnPropertyChanged);
            nudSlopeLimitU.DataBindings.Add("Value", sensorBoardSettings.SlopeLimit, nameof(sensorBoardSettings.SlopeLimit.Max),
 true, DataSourceUpdateMode.OnPropertyChanged);

            nudIdleVoltageLimitD.DataBindings.Add("Value", sensorBoardSettings.IdleVoltageLimit, nameof(sensorBoardSettings.IdleVoltageLimit.Min),
 true, DataSourceUpdateMode.OnPropertyChanged);
            nudIdleVoltageLimitU.DataBindings.Add("Value", sensorBoardSettings.IdleVoltageLimit, nameof(sensorBoardSettings.IdleVoltageLimit.Max),
 true, DataSourceUpdateMode.OnPropertyChanged);

            nudCheckDeviationRange.DataBindings.Add("Value", sensorBoardSettings, nameof(sensorBoardSettings.CheckDeviationRange),
true, DataSourceUpdateMode.OnPropertyChanged);
            nudPreheatTime.DataBindings.Add("Value", sensorBoardSettings, nameof(sensorBoardSettings.PreheatTime),
 true, DataSourceUpdateMode.OnPropertyChanged);

            nudVoltageRippleRange.DataBindings.Add("Value", sensorBoardSettings, nameof(sensorBoardSettings.VoltageRippleRange),
true, DataSourceUpdateMode.OnPropertyChanged);
            nudGasInjectionTimeout.DataBindings.Add("Value", sensorBoardSettings, nameof(sensorBoardSettings.GasInjectionTimeout),
 true, DataSourceUpdateMode.OnPropertyChanged);

            nudVolMinDifference.DataBindings.Add("Value", sensorBoardSettings, nameof(sensorBoardSettings.VolMinDifference),
true, DataSourceUpdateMode.OnPropertyChanged);

            nudPortTimeOut.DataBindings.Add("Value", sensorBoardSettings, nameof(sensorBoardSettings.PortTimeout),
true, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void cmbGasType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == null) return;
            var cmb = (ComboBox)sender;

            nudSamplePoint1.DataBindings.Clear();
            nudSamplePoint2.DataBindings.Clear();
            nudGasInjectionTime1.DataBindings.Clear();
            nudGasInjectionTime2.DataBindings.Clear();

            if (cmb.SelectedIndex >= 0 && cmb.SelectedIndex < _sensorBoardSettings.GasParams.Count)
            {
                var gasParams = _sensorBoardSettings.GasParams[cmb.SelectedIndex];
                nudSamplePoint1.DataBindings.Add("Value", gasParams, nameof(gasParams.SamplePoint1),
                    true, DataSourceUpdateMode.OnPropertyChanged);
                nudSamplePoint2.DataBindings.Add("Value", gasParams, nameof(gasParams.SamplePoint2),
                    true, DataSourceUpdateMode.OnPropertyChanged);
                nudGasInjectionTime1.DataBindings.Add("Value", gasParams, nameof(gasParams.GasInjectionTime1),
                    true, DataSourceUpdateMode.OnPropertyChanged);
                nudGasInjectionTime2.DataBindings.Add("Value", gasParams, nameof(gasParams.GasInjectionTime2),
                    true, DataSourceUpdateMode.OnPropertyChanged);
            }
        }
    }
}
