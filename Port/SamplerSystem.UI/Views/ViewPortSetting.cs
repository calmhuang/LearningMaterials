using SamplerSystem.UI.Models.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplerSystem.UI.Views
{
    public partial class ViewPortSetting : UserControl
    {
        public ViewPortSetting()
        {
            InitializeComponent();
        }

        public void SetData(PortSetting printSettings)
        {
            cmbComName.DataSource = printSettings.PortNames;
            cmbComName.DataBindings.Add("Text", printSettings, nameof(printSettings.PortName),
             true, DataSourceUpdateMode.OnPropertyChanged);

            cmbBaudRate.DataSource = printSettings.BaudRates;
            cmbBaudRate.DataBindings.Add("Text", printSettings, nameof(printSettings.BaudRate),
             true, DataSourceUpdateMode.OnPropertyChanged);

            cmbParite.DataSource = Enum.GetNames(typeof(Parity));
            cmbParite.DataBindings.Add("Text", printSettings, nameof(printSettings.Parity),
             true, DataSourceUpdateMode.OnPropertyChanged);

            cmbDataBits.DataSource = printSettings.DataBitss;
            cmbDataBits.DataBindings.Add("Text", printSettings, nameof(printSettings.DataBits),
             true, DataSourceUpdateMode.OnPropertyChanged);

            cmbStopBits.DataSource = Enum.GetNames(typeof(StopBits));
            cmbStopBits.DataBindings.Add("Text", printSettings, nameof(printSettings.StopBits),
            true, DataSourceUpdateMode.OnPropertyChanged);


            // ckbUseResponse.DataBindings.Add("Checked", printSettings, nameof(printSettings.UseResponse) ,
            // true, DataSourceUpdateMode.OnPropertyChanged);
            // txbComm.DataBindings.Add("Text", printSettings, nameof(printSettings.StrResponse));

            // txbComm.DataBindings.Add("Enabled", printSettings, nameof(printSettings.UseResponse));


        }

    }
}
