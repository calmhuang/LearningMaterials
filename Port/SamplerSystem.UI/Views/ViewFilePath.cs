using SamplerSystem.UI.Models.Settings;
using System;
using System.Windows.Forms;

namespace SamplerSystem.UI.Views
{
    public partial class ViewFilePath : UserControl
    {
        public ViewFilePath()
        {
            InitializeComponent();
        }

        public void SetData(FileSetting fileSettings)
        {
            lblOutFilePath.DataBindings.Add("Text", fileSettings, nameof(fileSettings.ResultPath),
                true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnSetOutDataPath_Click(object sender, EventArgs e)
        {
            SelectDir(lblOutFilePath);
        }

        private void SelectDir(Label lbl)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            if (lbl != null)
            {
                lbl.Text = dialog.SelectedPath;
                return;
            }
        }
    }
}
