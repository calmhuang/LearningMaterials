using SamplerSystem.UI.MES;
using SamplerSystem.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplerSystem.UI.Views
{
    public partial class FormLogin : Form
    {
        private MesAPI _mes;
        private UserInfo _userInfo;

        public FormLogin(MesAPI mes)
        {
            InitializeComponent();

            _mes= mes;
            _userInfo = UserInfo.Load(GetConfigFilePath("UserInfo.ini")) ?? new UserInfo();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            cmbUsers.DataSource = _userInfo.UserNameHistorys;
            cmbUsers.DataBindings.Add("Text", _userInfo, nameof(_userInfo.UserName), true, DataSourceUpdateMode.OnPropertyChanged);

            tbPassWord.DataBindings.Add("Text", _userInfo, nameof(_userInfo.Password), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private string GetConfigFilePath(string fileName)
        {
            return Path.Combine(Path.Combine(Application.StartupPath, "configs"), fileName);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var index = _userInfo.UserNameHistorys.FindIndex(a => a.Equals(_userInfo.UserName));
            if (index == -1)
            {
                _userInfo.UserNameHistorys.Add(_userInfo.UserName);
            }

            if (_mes.PostToken(_userInfo.UserName, _userInfo.Password))
            {
                _mes.MesInfo.UserName = _userInfo.UserName;
                _userInfo.Save(GetConfigFilePath("UserInfo.ini"));
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
