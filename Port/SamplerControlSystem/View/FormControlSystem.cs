using SamplerControlSystem.Condition;
using SamplerControlSystem.Entity;
using SamplerControlSystem.Model;
using SamplerControlSystem.Server;
using SamplerSystem.Port;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SamplerControlSystem
{
    public partial class FormControlSystem : Form
    {
        private readonly List<string> _statusHeads = new List<string>()
        {
        "气体稳定状态",
        "气箱门状态",
        "零点净空状态",
        "分析仪浓度漂移状态",
        "注气状态",
        "流量计连接状态",
        "模数转换器连接状态",
        "注气检测状态",
        "注样运行状态",
        "气缸状态",
        "风扇状态",
        "排气阀状态",
        "排气扇状态",
        "流量计设置状态",

        };
        private SampleSerialPort _port;
        private ControlSystem _controlSystem;
        private ViewModelControlSystem _viewModelControlSystem;

        public FormControlSystem(SampleSerialPort port, ControlSystem controlSystem, decimal injectionTime, decimal sample2, decimal sample3)
        {
            InitializeComponent();

            _port = port;
            _controlSystem = controlSystem ?? new ControlSystem();

            _viewModelControlSystem = new ViewModelControlSystem(controlSystem, injectionTime, sample2, sample3);
        }

        private void FormControlSystem_Load(object sender, EventArgs e)
        {
            ReceiveDataParse.OnUpdateDisplay += () =>
            {
                dgvStatus.Invalidate();
            };

            dgvStatus.RowCount = _statusHeads.Count;
            dgvStatus.ColumnCount = 2;

            nudInjectionTime.DataBindings.Add("Value", _viewModelControlSystem, nameof(_viewModelControlSystem.InjectionTime), true, DataSourceUpdateMode.OnPropertyChanged);
            nudSample2.DataBindings.Add("Value", _viewModelControlSystem, nameof(_viewModelControlSystem.Sample2), true, DataSourceUpdateMode.OnPropertyChanged);
            nudSample3.DataBindings.Add("Value", _viewModelControlSystem, nameof(_viewModelControlSystem.Sample3), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void FormControlSystem_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        #region dgv显示刷新

        private void dgvStatus_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (sender == null) return;
            var dgv = (DataGridView)sender;

            if (e.ColumnIndex == 0)
            {
                e.Value = _statusHeads[e.RowIndex];
                return;
            }

            var status = _controlSystem.ControlSystemStatus;
            if (e.ColumnIndex == 1)
            {
                if (e.RowIndex == 0)
                    e.Value = status.GasStableStatus ? "稳定" : "未稳定";
                if (e.RowIndex == 1)
                    e.Value = status.AirboxDoorsStatus ? "已关闭" : "未关闭";
                if (e.RowIndex == 2)
                    e.Value = status.ZeroClearanceStatus ? "正常" : "浓度大于1ppm";
                if (e.RowIndex == 3)
                    e.Value = status.AnalyserStatus ? "数据正常" : "数据异常";
                if (e.RowIndex == 4)
                    e.Value = status.GasInjectionStatus ? "未注气" : "注气中";
                if (e.RowIndex == 5)
                    e.Value = status.FlowMeterConnectionStatus ? "已连接" : "连接异常";
                if (e.RowIndex == 6)
                    e.Value = status.ADCConcentrationStatus ? "已连接" : "连接异常";
                if (e.RowIndex == 7)
                    e.Value = status.GasInjectionConcentrationStatus ? "正常" : "异常";
                if (e.RowIndex == 8)
                    e.Value = status.CalibrationCompletionStatus ? "已运行" : "未运行";
                if (e.RowIndex == 9)
                    e.Value = status.CylinderStatus ? "已抬起" : "已压下";
                if (e.RowIndex == 10)
                    e.Value = status.CirculationFanStatus ? "已关闭" : "已打开";
                if (e.RowIndex == 11)
                    e.Value = status.ExhaustValveStatus ? "已关闭" : "已打开";
                if (e.RowIndex == 12)
                    e.Value = status.ExhaustFanStatus ? "已关闭" : "已打开";
                if (e.RowIndex == 13)
                    e.Value = status.FlowMeterSetStatus ? "设置成功" : "设置失败";
            }

        }

        private void dgvStatus_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender == null) return;
            var dgv = (DataGridView)sender;

            if (e.ColumnIndex == 0)
            {
                e.CellStyle.BackColor = e.RowIndex % 2 == 0 ? Color.FromArgb(230, 245, 255) : Color.FromArgb(245, 230, 255);
                dgv.Columns[0].Width = 150;
                return;
            }

            if (e.ColumnIndex == 1)
            {
                var status = _controlSystem.ControlSystemStatus;
                if (e.RowIndex == 0)
                    e.CellStyle.BackColor = status.GasStableStatus ? Color.GreenYellow : Color.OrangeRed;
                if (e.RowIndex == 1)
                    e.CellStyle.BackColor = status.AirboxDoorsStatus ? Color.GreenYellow : Color.OrangeRed;
                if (e.RowIndex == 2)
                    e.CellStyle.BackColor = status.ZeroClearanceStatus ? Color.GreenYellow : Color.OrangeRed;
                if (e.RowIndex == 3)
                    e.CellStyle.BackColor = status.AnalyserStatus ? Color.GreenYellow : Color.OrangeRed;
                if (e.RowIndex == 4)
                        e.CellStyle.BackColor = status.GasInjectionStatus ? Color.White : Color.GreenYellow;
                if (e.RowIndex == 5)
                    e.CellStyle.BackColor = status.FlowMeterConnectionStatus ? Color.GreenYellow : Color.OrangeRed;
                if (e.RowIndex == 6)
                    e.CellStyle.BackColor = status.ADCConcentrationStatus ? Color.GreenYellow : Color.OrangeRed;
                if (e.RowIndex == 7)
                    e.CellStyle.BackColor = status.GasInjectionConcentrationStatus ? Color.GreenYellow : Color.OrangeRed;
                if (e.RowIndex == 8)
                    e.CellStyle.BackColor = status.CalibrationCompletionStatus ? Color.White : Color.GreenYellow;
                if (e.RowIndex == 9)
                    e.CellStyle.BackColor = status.CylinderStatus ? Color.White : Color.GreenYellow;
                if (e.RowIndex == 10)
                    e.CellStyle.BackColor = status.CirculationFanStatus ? Color.White : Color.GreenYellow;
                if (e.RowIndex == 11)
                    e.CellStyle.BackColor = status.ExhaustValveStatus ? Color.White : Color.GreenYellow;
                if (e.RowIndex == 12)
                    e.CellStyle.BackColor = status.ExhaustFanStatus ? Color.White : Color.GreenYellow;
                if (e.RowIndex == 13)
                    e.CellStyle.BackColor = status.FlowMeterSetStatus ? Color.GreenYellow : Color.OrangeRed;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }


        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //打开进气阀
        private void btnOpenInletValve_Click(object sender, EventArgs e)
        {
            var writeCmdParam = new WriteCmdParameters(CmdType.InjectionGas);
            writeCmdParam.InjectionGasTime = (float)_viewModelControlSystem.InjectionTime;

            _port.Write(SamplerCmder.WriteCommand(writeCmdParam));
        }
        //关闭进气阀
        private void btnCloseInletValve_Click(object sender, EventArgs e)
        {
            var writeCmdParam = new WriteCmdParameters(CmdType.InjectionGas);
            writeCmdParam.InjectionGasTime = 0;

            _port.Write(SamplerCmder.WriteCommand(writeCmdParam));

        }
        //标定2校准
        private void btnVerifSample2_Click(object sender, EventArgs e)
        {
            var writeCmdParam = new WriteCmdParameters(CmdType.Check40PPM);
            writeCmdParam.Sample2 = (float)_viewModelControlSystem.Sample2;

            _port.Write(SamplerCmder.WriteCommand(writeCmdParam));

        }
        //标定3校准
        private void btnVerifSample3_Click(object sender, EventArgs e)
        {
            var writeCmdParam = new WriteCmdParameters(CmdType.Check1000PPM);
            writeCmdParam.Sample3 = (float)_viewModelControlSystem.Sample3;

            _port.Write(SamplerCmder.WriteCommand(writeCmdParam));
        }
        //打开排气阀
        private void btnOpenExhaustValve_Click(object sender, EventArgs e)
        {
            _port.Write(SamplerCmder.WriteCommand(new WriteCmdParameters(CmdType.OpenExhaustValve)));
        }
        //关闭排气阀
        private void btnCloseExhaustValve_Click(object sender, EventArgs e)
        {
            _port.Write(SamplerCmder.WriteCommand(new WriteCmdParameters(CmdType.CloseExhaustValve)));
        }
        //打开排气扇
        private void btnOpenExhaustFan_Click(object sender, EventArgs e)
        {
            _port.Write(SamplerCmder.WriteCommand(new WriteCmdParameters(CmdType.OpenExhaustFan)));

        }
        //关闭排气扇
        private void btnCloseExhaustFan_Click(object sender, EventArgs e)
        {
            _port.Write(SamplerCmder.WriteCommand(new WriteCmdParameters(CmdType.CloseExhaustFan)));

        }
        //打开循环风扇
        private void btnOpenCirculationFan_Click(object sender, EventArgs e)
        {
            _port.Write(SamplerCmder.WriteCommand(new WriteCmdParameters(CmdType.OpenCirculationFan)));
        }
        //关闭循环风扇
        private void btnCloseCirculationFan_Click(object sender, EventArgs e)
        {
            _port.Write(SamplerCmder.WriteCommand(new WriteCmdParameters(CmdType.CloseCirculationFan)));

        }
        //气缸上升
        private void btnCylinderUpper_Click(object sender, EventArgs e)
        {
            _port.Write(SamplerCmder.WriteCommand(new WriteCmdParameters(CmdType.CylinderUpper)));

        }
        //气缸下降
        private void btnCylinderDown_Click(object sender, EventArgs e)
        {
            _port.Write(SamplerCmder.WriteCommand(new WriteCmdParameters(CmdType.CylinderDown)));

        }
    }
}
