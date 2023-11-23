using SamplerSystem.UI.MES;
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
    public partial class FormMesInfo : Form
    {
        private MesAPI _mes;
        private MesInfo _mesInfo;

        public FormMesInfo(MesAPI mes)
        {
            InitializeComponent();

            _mes = mes;
            _mesInfo = mes.MesInfo;
        }

        private void FormMesInfo_Load(object sender, EventArgs e)
        {
            _mes.GetCompanyInfo();

            cmbCompany.ValueMember = "ID";
            cmbCompany.DisplayMember = "Name";
            cmbCompany.DataSource = _mesInfo.CompanyInfos;
            cmbCompany.DataBindings.Add("SelectedValue", _mesInfo, nameof(_mesInfo.CompanyId), true, DataSourceUpdateMode.OnPropertyChanged);
            if (_mesInfo.CompanyInfos.Count > 0 && string.IsNullOrEmpty(_mesInfo.CompanyId)) cmbCompany.SelectedIndex = 0;

            tbWO.DataBindings.Add("Text", _mesInfo, nameof(_mesInfo.WO), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnGetWOInfo_Click(object sender, EventArgs e)
        {
            //TODO:不输入WO号也可以点击
            if (_mes.PostWODto())
            {
                _mes.PostVersionNode();
                cmbCraftNode.DataBindings.Clear();

                cmbCraftNode.ValueMember = "CraftLineVersionNodeId";
                cmbCraftNode.DisplayMember = "ProcessAnotherName";
                cmbCraftNode.DataSource = _mesInfo.CraftInfos;
                cmbCraftNode.DataBindings.Add("SelectedValue", _mesInfo, nameof(_mesInfo.CraftNodeId), true, DataSourceUpdateMode.OnPropertyChanged);
                if (_mesInfo.CraftInfos.Count > 0) cmbCraftNode.SelectedIndex = 0;
            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mes.PostWorkShop();
            cmbWorkShop.DataBindings.Clear();


            cmbWorkShop.ValueMember = "ID";
            cmbWorkShop.DisplayMember = "Name";
            cmbWorkShop.DataSource = _mesInfo.WorkShopInfos;
            cmbWorkShop.DataBindings.Add("SelectedValue", _mesInfo, nameof(_mesInfo.WorkShopId), true, DataSourceUpdateMode.OnPropertyChanged);

            if (_mesInfo.WorkShopInfos.Count > 0) cmbWorkShop.SelectedIndex = 0;
        }

        private void cmbWorkShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mes.PostWorkLine();
            cmbWorkLine.DataBindings.Clear();

            cmbWorkLine.ValueMember = "ID";
            cmbWorkLine.DisplayMember = "Name";
            cmbWorkLine.DataSource = _mesInfo.WorkLineInfos;
            cmbWorkLine.DataBindings.Add("SelectedValue", _mesInfo, nameof(_mesInfo.WorkLineId), true, DataSourceUpdateMode.OnPropertyChanged);
            if (_mesInfo.WorkLineInfos.Count > 0) 
                cmbWorkLine.SelectedIndex = 0;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           _mes.MesInfo.CompanyName = cmbCompany.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
