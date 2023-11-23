using SamplerSystem.UI.MES;
using System;
using System.Windows.Forms;

namespace SamplerSystem.UI.Views
{
    public partial class FormAddTrayID : Form
    {
        private MesInfo _mesInfo;

        public FormAddTrayID(MesInfo mesInfo)
        {
            _mesInfo = mesInfo;

            InitializeComponent();
        }

        private void FormAddTrayID_Load(object sender, EventArgs e)
        {
            tbTray1.Text = _mesInfo.TrayIDs[0];
            tbTray2.Text = _mesInfo.TrayIDs[1];
            tbTray3.Text = _mesInfo.TrayIDs[2];
            tbTray1.KeyUp += (s,ee) =>
            {
                if (ee.KeyCode == Keys.Enter)
                {
                    tbTray2.Select();
                }
            };
            tbTray2.KeyUp += (s, ee) =>
            {
                if (ee.KeyCode == Keys.Enter)
                {
                    tbTray3.Select();
                    //SelectNextControl(tbTray3, true, true, true, true);
                }
            };
            tbTray3.KeyUp += (s, ee) =>
            {
                if (ee.KeyCode == Keys.Enter)
                {
                    tbTray1.Select();
                    //SelectNextControl(tbTray1, true, true, true, true);
                }
            };
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _mesInfo.TrayIDs[0]=(tbTray1.Text);
            _mesInfo.TrayIDs[1]=(tbTray2.Text);
            _mesInfo.TrayIDs[2]=(tbTray3.Text);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
