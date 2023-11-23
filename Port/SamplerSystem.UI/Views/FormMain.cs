using SamplerControlSystem;
using SamplerControlSystem.Condition;
using SamplerControlSystem.Entity;
using SamplerControlSystem.Server;
using SamplerSystem.Port;
using SamplerSystem.UI.FileWriter;
using SamplerSystem.UI.MES;
using SamplerSystem.UI.Models;
using SamplerSystem.UI.Models.Settings;
using SamplerSystem.UI.Properties;
using SamplerSystem.UI.Testing;
using SamplerSystem.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SamplerSystem.UI.Views
{
    public partial class FormMain : Form
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


        private SysSettings _settings;
        private SampleSerialPort _port;
        private ControlSystem _controlSystem;
        private MesAPI _mes;

        private bool _isDebug;
        public bool IsOffline { get; set; } = false;
        public FormMain()
        {
            InitializeComponent();

            _settings = SysSettings.Load(GetConfigFilePath("sysset.ini"));
            if (_settings == null) _settings = new SysSettings();
            _controlSystem = new ControlSystem(_settings.BasicSettings.SensorBradNum, _settings.BasicSettings.SensorNum);
            _mes = new MesAPI(_settings.MesSettings, MesInfo.Load(GetConfigFilePath("MesInfo.ini")));
            _mes.MesInfo.TrayIDs = new string[_settings.BasicSettings.TrayNum];
#if DEBUG
            _isDebug = true;
#endif

            tsslUserName_DoubleClick(null, null);

            UIHelper.EnableDoubleBufferedDataGridView(dgvSampleInfo);
            UIHelper.EnableDoubleBufferedDataGridView(dgvStatusInfo);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dgvSampleInfo.RowCount = _settings.BasicSettings.TrayRow + 1;
            dgvSampleInfo.ColumnCount = (_settings.BasicSettings.TrayCol + 1) * _settings.BasicSettings.TrayNum;
            dgvStatusInfo.RowCount = _statusHeads.Count;
            dgvStatusInfo.ColumnCount = 2;
            chbIsOffline.DataBindings.Add("Checked", this, nameof(this.IsOffline), true, DataSourceUpdateMode.OnPropertyChanged);
            var woInfo = _mes.MesInfo.WOResponse;
            if (woInfo != null)
            {
                lblWO.Text = woInfo.WO;
                lblMN.Text = woInfo.MN;
                lblMNName.Text = woInfo.MNName;
                lblMNType.Text = woInfo.MNType;
                lblWOStatus.Text = woInfo.WOStatus;
            }

            ReceiveDataParse.OnErrorHndle += (msg) =>
            {
                MessageBox.Show($"{msg}", "异常");
            };
            ReceiveDataParse.OnUpdateDisplay += ()=>
            {
                UpdateDispaly();
            };

            if (_isDebug)
            {
                Task.Run(() => DebugSerialHeartbeat());
            }

            InitSerialPort();
            _port.OnParseReceiveData += (datas) =>
            {
                try
                {
                    this?.Invoke(
                        new Action(() =>
                        {
                            ReceiveDataParse.ReceiveParse(datas, _controlSystem);
                        })
                        );
                }
                catch (ObjectDisposedException)
                {
                    //界面线程取消,Invoke会报错
                }
            };

        }


        #region 串口相关设置
        private void InitSerialPort()
        {
            var set = _settings.PortSettings;
            _port = new SampleSerialPort(set.PortName, set.BaudRate, set.Parity, set.DataBits, set.StopBits);
            _port.OnReceiveSendDisplay += (str) =>
            {
                this?.Invoke(
                    new Action(() =>
                    {
                        var time = DateTime.Now.ToString();
                        tbPortCommandInfo.AppendText(time + ":" + str + "\r\n");
                        tbPortCommandInfo.SelectionStart = tbPortCommandInfo.Text.Length;
                        tbPortCommandInfo.ScrollToCaret();//滚动到光标处
                    })
                    );

            };
            tsslSerialPortInfo.Text = _port.DisplayInfo();
            _port.ChangePortMessager += (str) =>
            {
                tsslSerialPortInfo.Text = str;
            };
        }
        private void tsslStatusChange_DoubleClickAsync(object sender, EventArgs e)
        {
            if (tsslStatusChange.Text.Contains("关闭串口"))
            {
                ClosePort();
                tsslStatusChange.Text = "打开串口";
            }
            else
            {
                OpenPort();
                tsslStatusChange.Text = "关闭串口";
            }
        }
        private void ClosePort()
        {
            var serialPort = _port?.SerialPort;
            if (serialPort == null) return;
            _port.ClosePort();
            _port.Close();
        }
        private async void OpenPort()
        {
            await Task.Run(() =>
            {
                try
                {
                    var serialPort = _port?.SerialPort;
                    if (serialPort == null) return;
                    if (!serialPort.IsOpen)
                    {
                        _port.OpenPort();
                        // 打开后启动对应的过滤器线程
                        //portTabItem.StartFilterTask();
                        //portTabItem.StartMonitorTask();
                        _port.Open();
                    }
                }
                catch (Exception)
                {

                }
            });
        }
        #endregion

        private void UpdateDispaly()
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    lblFixtureInfo.Text = _controlSystem.FixtureInfo;
                    lblSampleStatus.Text = _controlSystem.SampleStatus;
                    lblStatusMsg.Text = _ctx?.SampleInfoMsg;
                    lblTestStatus.Text = _ctx?.TestStatusMsg;
                    lblStartTime.Text = _ctx?.StartTestTime;

                    dgvSampleInfo.Invalidate();
                    dgvStatusInfo.Invalidate();
                }));
            }
            catch (System.ObjectDisposedException)
            {
                //界面线程取消,Invoke会报错
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_idle)
            {
                e.Cancel = true;
                return;
            }
            _resetEventDebug.Set();
            ClosePort();
        }

        private string GetConfigFilePath(string fileName)
        {
            return Path.Combine(Path.Combine(Application.StartupPath, "configs"), fileName);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            var frm = new FormSettings(_settings);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!_idle) return;
                frm.Settings.Save(GetConfigFilePath("sysset.ini"));
                _settings = SysSettings.Load(GetConfigFilePath("sysset.ini"));

                var set = _settings.PortSettings;
                _port.ChangeSerialPort(set.PortName, set.BaudRate, set.Parity, set.DataBits, set.StopBits);
            }
        }

        private void btnControlSystem_Click(object sender, EventArgs e)
        {
            var frm = new FormControlSystem(_port, _controlSystem, _settings.BasicSettings.InjectionTime, _settings.BasicSettings.Sample2, _settings.BasicSettings.Sample3);
            frm.Show();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SizeMode = TabSizeMode.Fixed;
                tabControl1.ItemSize = new Size((tabControl1.Width - 5) / tabControl1.TabCount, 20);
            }
            catch (Exception)
            {
                // 最小化时异常
            }
        }

        private void SensorDataDispaly(int row, int col)
        {
            var sensorBrad = _controlSystem.SensorBoards[row];
            var sensor = sensorBrad.SensorDatas[col];

            var strTemp = string.Empty;
            var strError = string.Empty;
            //strTemp += "传感器板ID:" + $"{sensorBrad.SensorBoardID}" + "\r\n"; 
            strTemp += "传感器SN:" + $"{sensor.BindSN}" + "\r\n";
            strTemp += "标定状态:" + (sensor.IsCalibration ? "已标定" : "未标定") + "\r\n";
            strTemp += "传感器连接状态:" + (sensor.IsConnected ? "已连接" : "未连接") + "\r\n";
            strTemp += "第一点电压(mV):" + $"{sensor.Voltage0}" + "\r\n";
            strTemp += "第二点电压(mV):" + $"{sensor.Voltage1}" + "\r\n";
            strTemp += "第三点电压(mV):" + $"{sensor.Voltage2}" + "\r\n";
            strTemp += "标定斜率(mV/ppm):" + $"{sensor.CalibrationSlope}" + "\r\n";
            strTemp += "运放实时电压(mV):" + $"{sensor.RealTimeVoltage}" + "\r\n";
            strTemp += "空载电压(mV):" + $"{sensor.NonLoadedVoltage}" + "\r\n";
            strTemp += "零点电压(mV):" + $"{sensor.ZeroVoltage}" + "\r\n";
            strTemp += "第二点标定浓度(ppm):" + $"{_controlSystem.Analyzer2Concentration}" + "\r\n";
            strTemp += "第三点标定浓度(ppm):" + $"{_controlSystem.Analyzer3Concentration}" + "\r\n";
            strTemp += "标定温度(℃):" + $"{_controlSystem.FixtureTemperature}" + "\r\n";
            strTemp += "标定湿度(%):" + $"{_controlSystem.FixtureHumidity}" + "\r\n";
            strTemp += "异常详情:";
            if (!sensor.IsCalibration)
            {
                if (sensor.Flags != SensorResultFlags.UnMeasured)
                {
                    if ((sensor.Flags & SensorResultFlags.ParamError) != 0) strError += $"设置参数错误!\r\n";
                    if ((sensor.Flags & SensorResultFlags.Voltage0flow) != 0) strError += $"标定1电压纹波超出范围!\r\n";
                    if ((sensor.Flags & SensorResultFlags.Voltage1flow) != 0) strError += $"标定2电压纹波超出范围!\r\n";
                    if ((sensor.Flags & SensorResultFlags.Voltage2flow) != 0) strError += $"标定3电压纹波超出范围!\r\n";
                    if ((sensor.Flags & SensorResultFlags.Slopeflow) != 0) strError += $"传感器斜率不在范围!\r\n";
                    if ((sensor.Flags & SensorResultFlags.SlopeCheckError) != 0) strError += $"斜率校验不通过!\r\n";
                    if ((sensor.Flags & SensorResultFlags.ZeroOrNonLoadedVoltageflow) != 0) strError += $"零点或空载电压不在标定范围!\r\n";
                }
            }
            strTemp += strError;
            MessageBox.Show(strTemp, $"传感器{sensor.Index}信息", MessageBoxButtons.OK);
        }

        #region DGV刷新显示
        private void dgvSampleInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender == null) return;
            var dgv = (DataGridView)sender;
            var setting = _settings.BasicSettings;

            var mul = e.ColumnIndex / (setting.TrayCol + 1);
            var remainder = e.ColumnIndex % (setting.TrayCol + 1);
            if (e.RowIndex == 0 || remainder == 0) return;

            var trayBradNum = (setting.TrayCol * setting.TrayRow / setting.SensorNum);
            var bradOccupyRow = setting.SensorNum / setting.TrayCol;
            var offsetRow = (e.RowIndex - 1) / bradOccupyRow + (mul * trayBradNum);
            var offsetCol = ((e.RowIndex - 1) % bradOccupyRow * setting.TrayCol) + (remainder - 1);
            SensorDataDispaly(offsetRow, offsetCol);
        }

        private void dgvSampleInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender == null) return;
            var dgv = (DataGridView)sender;

            var remainder = e.ColumnIndex % (_settings.BasicSettings.TrayCol + 1);
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (e.RowIndex == 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(230, 245, 255);
                return;
            }

            if (remainder == 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(245, 230, 255);
                dgv.Columns[e.ColumnIndex].Width = 40;
                return;
            }
            dgv.Columns[e.ColumnIndex].Width = 32;
            var setting = _settings.BasicSettings;
            var mul = e.ColumnIndex / (setting.TrayCol + 1);
            var trayBradNum = (setting.TrayCol * setting.TrayRow / setting.SensorNum);
            var bradOccupyRow = setting.SensorNum / setting.TrayCol;
            var offsetRow = (e.RowIndex - 1) / bradOccupyRow + (mul * trayBradNum);
            var offsetCol = ((e.RowIndex - 1) % bradOccupyRow * setting.TrayCol) + (remainder - 1);
            var sensor = _controlSystem.SensorBoards[offsetRow].SensorDatas[offsetCol];

            if (!sensor.IsConnected) e.CellStyle.BackColor = Color.FromArgb(190, 190, 190);
            else if (!sensor.IsNormalPreheat) e.CellStyle.BackColor = Color.FromArgb(255, 0, 0);
            else 
            {
                switch (_controlSystem.SensorBoards[offsetRow].SensorStatus)
                {
                    case SensorStatusType.Preheating: e.CellStyle.BackColor = Color.FromArgb(255, 180, 90);break;
                    case SensorStatusType.Point1CalibrationCompleted: e.CellStyle.BackColor = Color.Pink; break;
                    case SensorStatusType.Point2CalibrationCompleted: e.CellStyle.BackColor = Color.AliceBlue; break;
                    case SensorStatusType.Point3CalibrationCompleted: 
                        if(!sensor.IsCalibration) e.CellStyle.BackColor = Color.FromArgb(255, 0, 0);
                        else e.CellStyle.BackColor = Color.FromArgb(128, 128, 255);break;
                    case SensorStatusType.Point1Calibration: e.CellStyle.BackColor = Color.Pink; break;
                    case SensorStatusType.Point2Calibration: e.CellStyle.BackColor = Color.Blue; break;
                    case SensorStatusType.Point3Calibration: e.CellStyle.BackColor = Color.FromArgb(255, 190, 255);break;
                }
            }
        }

        private void dgvSampleInfo_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (sender == null) return;
            var dgv = (DataGridView)sender;
            var setting = _settings.BasicSettings;

            var mul = e.ColumnIndex / (setting.TrayCol + 1);
            var remainder = e.ColumnIndex % (setting.TrayCol + 1);
            if (e.RowIndex == 0)
            {
                if (remainder == 0)
                    e.Value = $"Tray{mul + 1}";
                else
                    e.Value = $"列{remainder}";
                return;
            }

            if (remainder == 0)
            {
                e.Value = $"行{e.RowIndex}";
                return;
            }

            //TODO:需要考虑托盘列大于传感器数量问题
            var trayBradNum = (setting.TrayCol * setting.TrayRow / setting.SensorNum);
            var bradOccupyRow = setting.SensorNum / setting.TrayCol;
            var offsetRow = (e.RowIndex - 1) / bradOccupyRow + (mul * trayBradNum);
            var offsetCol = ((e.RowIndex - 1) % bradOccupyRow * setting.TrayCol) + (remainder - 1);

            e.Value = _controlSystem.SensorBoards[offsetRow].SensorDatas[offsetCol].Index;
        }

        private void dgvStatusInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void dgvStatusInfo_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
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

        #endregion

        private void btnMesInfo_Click(object sender, EventArgs e)
        {
            _mes.MesInfo.Save(GetConfigFilePath("MesInfo.ini"));
            var frm = new FormMesInfo(_mes);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _mes.MesInfo.Save(GetConfigFilePath("MesInfo.ini"));
                tsslCompanyName.Text = _mes.MesInfo.CompanyName;

                var woInfo = _mes.MesInfo.WOResponse;
                if (woInfo != null)
                {
                    lblWO.Text = woInfo.WO;
                    lblMN.Text = woInfo.MN;
                    lblMNName.Text = woInfo.MNName;
                    lblMNType.Text = woInfo.MNType;
                    lblWOStatus.Text = woInfo.WOStatus;
                }
            }
            else
            {
                _mes.GetType().GetProperty("MesInfo").SetValue(_mes, MesInfo.Load(GetConfigFilePath("MesInfo.ini")));
            }
        }

        private void tsslUserName_DoubleClick(object sender, EventArgs e)
        {
            if (!_idle) return;

            if (_isDebug && sender == null)
            {
                _mes.PostToken("pro", "123456");
                _mes.MesInfo.UserName = "pro";
            }
            else
            {
                //TODO:双击无效
                var frmLogin = new FormLogin(_mes);
                frmLogin.ShowDialog(this);
            }
            if (_mes.IsOnline)
            {
                tsslIsOnline.Text = "在线";
                tsslUserName.Text = $"[{_mes.MesInfo.UserName}]";
            }
            else
            {
                tsslIsOnline.Text = "离线";
                tsslUserName.Text = $"[***]";
            }
        }


        private TestContext _ctx;
        private bool _idle = true;
        private async void btnTest_Click(object sender, EventArgs e)
        {
            if (btnTest.Text == "开始标定")
            {
                //TODO:校验参数是否可以开始标定
                if (!_isDebug && !CheckControlSystemStatus(out string msg))
                {
                    MessageBox.Show($"{msg}", "状态检测未通过");
                    return;
                }
                if (MessageBox.Show("状态检测通过,确认开始标定吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
                _idle = false;
                Permission(!_idle);
                btnTest.Text = "结束标定";

                try
                {
                    var beginTime =  DateTime.Now;

                    var dir = $"{_settings.FileSettings.ResultPath}{Path.DirectorySeparatorChar}";
                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                    _controlSystem.NewSampleTest(_settings.BasicSettings.SensorBradNum, _settings.BasicSettings.SensorNum);

                    if (!_isDebug && !IsOffline)
                    {
                        foreach (var trayID in _mes.MesInfo.TrayIDs)
                        {
                            if (!_mes.PostGetTrayInfo(trayID, _controlSystem)) return;
                        }
                    }
                    else
                    {
                        for (var i = 0; i < _settings.BasicSettings.TrayNum; i++)
                        {
                            var sns = new List<string>();
                            var snNum = _settings.BasicSettings.TrayRow * _settings.BasicSettings.TrayCol;
                            for (var j = 0; j < snNum; j++)
                            {
                                sns.Add($"SN{i + 1}" + (j + 1).ToString().PadLeft(5, '0'));
                            }
                            _controlSystem.SetSensorBindSN(sns);
                        }
                    }

                    _ctx = new TestContext(_controlSystem, _settings);
                    _ctx.StartTestTime = beginTime.ToString("yyyy-MM-dd HH:mm:ss");
                    //控制程序运行用
                    ReceiveDataParse.OnReceiveCommand += _ctx.ReceiveCommand;

                    //TODO:做debug数据
                    _ctx.ResetEvent.Reset();
                    //发送设置参数
                    _port.Write(SamplerCmder.Init(_ctx.Settings.SensorBoardSettings));
                    if (!_isDebug && !_ctx.ResetEvent.WaitOne(_ctx.Settings.SensorBoardSettings.PortTimeout * 1000))
                    {
                        _ctx.TestStatus = TestType.StopTest;
                        _ctx.SampleInfoMsg = $"接收答复指令超时!超时答复指令:{SamplerCmder.CheckCmd:X2}";
                        return;
                    }

                    //开始标定命令
                    var wcp = new WriteCmdParameters(CmdType.Start) { InjectionGasTime = _ctx.Settings.SensorBoardSettings.GasInjectionTimeout };
                    _port.Write(SamplerCmder.WriteCommand(wcp));
                    if (!_isDebug && !_ctx.ResetEvent.WaitOne(_ctx.Settings.SensorBoardSettings.PortTimeout * 1000))
                    {
                        _ctx.TestStatus = TestType.StopTest;
                        _ctx.SampleInfoMsg = $"接收答复指令超时!超时答复指令:{SamplerCmder.CheckCmd:X2}";
                        return;
                    }

                    _ctx.TestStatus = TestType.Preheating;
                    _ctx.PreheatStartTime = DateTime.Now;
                    _ctx.SampleInfoMsg = $"已预热时间:{(DateTime.Now - _ctx.PreheatStartTime).TotalSeconds}s({_ctx.Settings.SensorBoardSettings.PreheatTime}s)";
                    UpdateDispaly();

                    _ = Task.Run(async () =>
                    {
                        await Task.Delay(_ctx.Settings.SensorBoardSettings.PreheatTime * 1000);
                        if (!_idle) _ctx.TestStatus = TestType.Testing;
                    });


                    await Task.Run(() =>
                    {
                        while (true)
                        {
                            _ctx.ResetEvent.WaitOne(_settings.BasicSettings.RefreshTime * 1000);
                            switch (_ctx.TestStatus)
                            {
                                case TestType.Preheating:
                                    _ctx.SampleInfoMsg = $"已预热时间:{(DateTime.Now - _ctx.PreheatStartTime).TotalSeconds}s({_ctx.Settings.SensorBoardSettings.PreheatTime}s)";
                                    break;
                                case TestType.Testing:
                                    if (_isDebug)

                                        if (_ctx.ControlSystem.IsSampleComplete)
                                        {
                                            _ctx.TestStatus = TestType.MesPush;
                                        }
                                        else
                                        {
                                            switch (_ctx.ControlSystem.TestStatus)
                                            {
                                                case SensorStatusType.Point1Calibration:
                                                    _ctx.SampleInfoMsg = $"第一点已标定:{_ctx.ControlSystem.Point1CalibrationNum}";
                                                    break;
                                                case SensorStatusType.Point2Calibration:
                                                    _ctx.SampleInfoMsg = $"第二点已标定:{_ctx.ControlSystem.Point2CalibrationNum}";
                                                    break;
                                                case SensorStatusType.Point3Calibration:
                                                    _ctx.SampleInfoMsg = $"第三点已标定:{_ctx.ControlSystem.Point3CalibrationNum}";
                                                    break;
                                            }
                                        }
                                    break;
                                case TestType.MesPush:
                                    _ctx.SampleInfoMsg = $"标定完成!";
                                    return;
                                case TestType.StopTest:
                                    _ctx.SampleInfoMsg = $"强制结束标定!";
                                    return;
                            }

                            UpdateDispaly();
                        }
                    });

                    UpdateDispaly();

                    var endTime = DateTime.Now;
                    var fileName = $"自动化标定数据_{endTime:yyyyMMddHHmmss}_{_mes.MesInfo.TrayIDs[0]}#{_mes.MesInfo.TrayIDs[1]}#{_mes.MesInfo.TrayIDs[2]}.CSV";
                    var fp = Path.Combine(dir, fileName);
                    var resultFile = new ResultFile(fp, endTime.ToString("yyyy/MM/dd HH:mm:ss"), _ctx.StartTestTime, _settings);
                    resultFile.WriteHead(_ctx.ControlSystem.FixtureTemperature, _ctx.ControlSystem.FixtureHumidity);
                    foreach (var sensorBorad in _ctx.ControlSystem.SensorBoards)
                    {
                        foreach (var sensor in sensorBorad.SensorDatas)
                        {
                            resultFile.WriteData(sensor);
                        }
                    }


                    if (!_isDebug && !IsOffline)
                    {
                        if (_ctx.TestStatus == TestType.MesPush)
                        {
                            //过站
                            foreach (var sensorBorad in _ctx.ControlSystem.SensorBoards)
                            {
                                foreach (var sensor in sensorBorad.SensorDatas)
                                {
                                    sensorBorad.IsProductDeviceOK &= _mes.PostProductDevice(sensor.BindSN);
                                }
                            }

                            //上传数据
                            foreach (var sensorBorad in _ctx.ControlSystem.SensorBoards)
                            {
                                foreach (var sensor in sensorBorad.SensorDatas)
                                {
                                    var jsonStr = GetSensorPushData(sensor, _ctx.ControlSystem);
                                    sensorBorad.IsPushDataOK &= _mes.PostSetSampleResult(jsonStr, sensor.BindSN, sensor.Flags);
                                }
                            }
                            //托盘解绑
                            var setting = _settings.BasicSettings;
                            _ctx.SampleInfoMsg = $"已解绑托盘:";
                            for (var i = 0; i < setting.TrayNum; i++)
                            {
                                var trayBradNum = setting.TrayCol * setting.TrayRow / setting.SensorNum;
                                var flag = true;
                                for (var j = 0; j < trayBradNum; i++)
                                {
                                    var offset = trayBradNum * i;
                                    if (!_ctx.ControlSystem.SensorBoards[offset + j].IsProductDeviceOK)
                                        flag = false;
                                    if (!_ctx.ControlSystem.SensorBoards[offset + j].IsPushDataOK)
                                        flag = false;
                                }

                                if (flag)
                                {
                                    _mes.PostUnbindTray(_mes.MesInfo.TrayIDs[i]);
                                    _ctx.SampleInfoMsg += _mes.MesInfo.TrayIDs[i];
                                }
                            }
                            //_ctx.SampleInfoMsg = $"上传完成!";
                            _ctx.TestStatus = TestType.EndTest;
                        }
                    }
                    else
                    {
                        _ctx.SampleInfoMsg = $"单机标定完成";
                        _ctx.TestStatus = TestType.EndTest;
                    }

                    ReceiveDataParse.OnReceiveCommand -= null;
                    UpdateDispaly();

                    _idle = true;
                    Permission(!_idle);
                    btnTest.Text = "开始标定";
                }
                catch (Exception)
                {

                }
            }
            else if (btnTest.Text == "结束标定")
            {
                if (MessageBox.Show("确定要强制结束标定吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (_isDebug)
                    {
                        ReceiveDataParse.ReceiveParse(CommandHelper.HexStrToByteArray("AA 55 00 04 10 01 5A 02 03 FF FF FF B1"), _controlSystem);
                    }
                    else 
                        _port.Write(SamplerCmder.WriteCommand(new WriteCmdParameters(CmdType.Reset)));
                    btnTest.Text = "等待设备结束...";
                    _ctx.TestStatus = TestType.StopTest;
                }
            }
        }

        private void Permission(bool testting)
        {
            btnMesInfo.Enabled = !testting;
            tsslStatusChange.Enabled = !testting;
            btnControlSystem.Enabled = !testting;
            btnTraySet.Enabled = !testting;
        }

        private bool CheckControlSystemStatus(out string msg)
        {
            msg = string.Empty;
            var ret = true;
            if (_controlSystem == null) return false;

            if (!IsOffline && _mes.MesInfo.WOResponse == null)
            {
                msg += "未设置标定工单\r\n";
                ret = false;
            }

            var status = _controlSystem.ControlSystemStatus;
            if (!status.GasStableStatus)
            {
                msg += "气体稳定状态异常\r\n";
                ret = false;
            }
            if (!status.AirboxDoorsStatus)
            {
                msg += "气箱门未关闭\r\n";
                ret = false;
            }
            if (!status.ZeroClearanceStatus)
            {
                msg += "零点状态异常\r\n";
                ret = false;
            }
            if (!status.AnalyserStatus)
            {
                msg += "分析仪浓度漂移异常\r\n";
                ret = false;
            }
            if (!status.FlowMeterConnectionStatus)
            {
                msg += "流量计未连接\r\n";
                ret = false;
            }
            if (!status.ADCConcentrationStatus)
            {
                msg += "模数转换器未连接\r\n";
                ret = false;
            }
            if (!status.GasInjectionConcentrationStatus)
            {
                msg += "注气检测状态异常\r\n";
                ret = false;
            }
            if (!status.FlowMeterSetStatus)
            {
                msg += "流量计未设置\r\n";
                ret = false;
            }

            if (!IsOffline)
            {
                for (var i = 0; i < _settings.BasicSettings.TrayNum; i++)
                {
                    if (string.IsNullOrEmpty(_mes.MesInfo?.TrayIDs[i]))
                    {
                        msg += $"{i + 1}托盘编码未设置\r\n";
                        ret = false;
                        continue;
                    }
                }
            }
            return ret;
        }

        private string GetSensorPushData(SensorData sensor, ControlSystem controlSystem)
        {
            var ret = string.Empty;

            if (sensor == null) return ret;

            ret+= "{\"Dev\":\"" + sensor?.Index + "\"" +
                ",\"PMS\":\"HM-722ESY\"" +
                ",\"IdType\":\"sn\"" +
                ",\"CGT\":\"" + Enum.GetName(typeof(GasType),_settings.SensorBoardSettings.GasType) + "\"" +
                ",\"SN\":\"" + sensor?.BindSN + "\"" +
                ",\"CCS1\":0"+
                ",\"CCS2\":" + controlSystem?.Analyzer2Concentration +
                ",\"CCS3\":" + controlSystem?.Analyzer3Concentration +
                ",\"SPTime\":" + _settings.SensorBoardSettings.PreheatTime +
                ",\"SCT\":" + controlSystem?.FixtureTemperature  +
                ",\"SCH\":" + controlSystem?.FixtureHumidity  +
                ",\"SCS\":" + sensor?.CalibrationResult  +
                ",\"SCVV0\":" + sensor?.ZeroVoltage +
                ",\"SCVV1\":" + sensor?.Voltage0 +
                ",\"SCVV2\":" + sensor?.Voltage1 +
                ",\"SCVV3\":" + sensor?.Voltage2 +
                ",\"SCVV4\":" + sensor?.RealTimeVoltage +
                ",\"CSUV0\":" + sensor?.NonLoadedVoltage +
                ",\"SCVS\":\"" + sensor?.CalibrationSlope + "\"" +
                "}";
            return ret;
        }

        //private int boradIndexDebug = 1;
        private AutoResetEvent _resetEventDebug = new AutoResetEvent(false);
        /// <summary>
        /// debug调试用,模拟数据
        /// </summary>
        private void DebugSerialHeartbeat()
        {
            _resetEventDebug.Reset();
            while (true)
            {
                if (_resetEventDebug.WaitOne(_settings.BasicSettings.RefreshTime * 1000)) return;
                
                if (!_idle)
                {
                    //if (boradIndexDebug > _settings.BasicSettings.SensorBradNum) boradIndexDebug = 1;
                    switch (_ctx?.TestStatus)
                    {
                        case TestType.Init:
                            ReceiveDataParse.ReceiveParse(CommandHelper.HexStrToByteArray("AA 55 00 03 10 01 30 01 01 17 01 34"), _controlSystem);
                            break;
                        case TestType.Start:
                            ReceiveDataParse.ReceiveParse(CommandHelper.HexStrToByteArray("AA 55 00 03 10 01 31 01 03 17 01 37"), _controlSystem);
                            break;
                        case TestType.Preheating:
                            for (var i = 0; i < _settings.BasicSettings.SensorBradNum; i++)
                            {
                                var str = $"AA 55 01 1D 07 22 0F 01 81 01 02 14 {i+1:X2} " +
                                    "01 00 FF FF FF FF FF FF FF FF 0C 28 04 13 " +
                                    "02 00 FF FF FF FF FF FF FF FF 07 F0 03 DB " +
                                    "03 00 FF FF FF FF FF FF FF FF 08 DB 04 5B " +
                                    "04 00 FF FF FF FF FF FF FF FF 0A 6E 03 D1 " +
                                    "05 00 FF FF FF FF FF FF FF FF 0A D8 04 33 " +
                                    "06 00 FF FF FF FF FF FF FF FF 0A D3 04 06 " +
                                    "07 00 FF FF FF FF FF FF FF FF 0C 34 04 0B " +
                                    "08 00 FF FF FF FF FF FF FF FF 07 E5 04 22 " +
                                    "09 00 FF FF FF FF FF FF FF FF 09 67 04 1C " +
                                    "0A 00 FF FF FF FF FF FF FF FF 0B 70 04 5D " +
                                    "0B 00 FF FF FF FF FF FF FF FF 15 74 03 CC " +
                                    "0C 00 FF FF FF FF FF FF FF FF 0A 6E 03 F3 " +
                                    "0D 00 FF FF FF FF FF FF FF FF 0A CD 04 35 " +
                                    "0E 00 FF FF FF FF FF FF FF FF 07 B8 04 2A " +
                                    "0F 00 FF FF FF FF FF FF FF FF 09 78 04 51 " +
                                    "10 00 FF FF FF FF FF FF FF FF 0A 25 03 EA " +
                                    "11 00 FF FF FF FF FF FF FF FF 13 3E 04 21 " +
                                    "12 00 FF FF FF FF FF FF FF FF 0B 4E 03 ED " +
                                    "13 00 FF FF FF FF FF FF FF FF 09 56 04 0F " +
                                    "14 00 FF FF FF FF FF FF FF FF 07 85 03 E3 ";
                                str += CommandHelper.CalculateCheckSum(CommandHelper.HexStrToByteArray(str), false)?.ToString("X2");
                                ReceiveDataParse.ReceiveParse(CommandHelper.HexStrToByteArray(str), _controlSystem);
                            }
                            break;
                        case TestType.Testing:
                            for (var i = 0; i < _settings.BasicSettings.SensorBradNum; i++)
                            {
                                var status = 0;
                                switch (_controlSystem.SensorBoards[i].SensorStatus)
                                {
                                    case SensorStatusType.Point1CalibrationCompleted: status = 5; break;
                                    case SensorStatusType.Point2CalibrationCompleted: status = 7; break;
                                    case SensorStatusType.Point3CalibrationCompleted: status = 7; break;
                                    case SensorStatusType.Preheating: status = 3; break;
                                }
                                var str = $"AA 55 01 1D 07 22 09 01 81 {status:X2} 02 14 {i+1:X2} " +
                                    $"01 A5 04 37 06 63 09 9D 05 59 09 9A 04 15 " +
                                    $"02 A5 03 E3 05 FE 09 0A 05 0D 09 3B 03 E1 " +
                                    $"03 A5 04 68 06 78 09 83 05 0B 09 7E 04 5D " +
                                    $"04 A5 03 EF 05 D1 08 A6 04 B2 08 AA 03 D4 " +
                                    $"05 A5 04 4A 06 5D 09 6E 05 15 09 8A 04 33 " +
                                    $"06 A5 04 1C 06 33 09 49 05 1E 09 30 04 05 " +
                                    $"07 A5 04 2C 06 3E 09 5C 05 2B 09 4C 04 0C " +
                                    $"08 A5 04 24 06 37 09 37 04 F9 09 2A 04 21 " +
                                    $"09 A5 04 27 06 3A 09 43 05 08 09 1A 04 1C " +
                                    $"0A A5 04 72 06 90 09 AC 05 28 09 79 04 5C " +
                                    $"0B A5 03 F6 06 1C 09 4D 05 4A 09 2A 03 CD " +
                                    $"0C A5 04 12 06 32 09 66 05 4F 09 36 03 F4 " +
                                    $"0D A5 04 48 06 63 09 84 05 30 09 52 04 35 " +
                                    $"0E A5 04 38 06 41 09 39 04 EC 08 ED 04 29 " +
                                    $"0F A5 04 6A 06 71 09 71 04 F9 09 25 04 51 " +
                                    $"10 A5 03 F3 06 17 09 29 05 17 09 03 03 EC " +
                                    $"11 48 04 53 06 4C 08 C2 04 14 09 A6 04 1F " +
                                    $"12 A5 04 06 06 35 09 6B 05 53 09 57 03 EC " +
                                    $"13 A5 04 26 06 23 09 1D 04 EF 09 09 04 10 " +
                                    $"14 A5 03 EF 06 01 09 00 04 F7 08 FE 03 E4 ";
                                str += CommandHelper.CalculateCheckSum(CommandHelper.HexStrToByteArray(str), false)?.ToString("X2");
                                ReceiveDataParse.ReceiveParse(CommandHelper.HexStrToByteArray(str), _controlSystem);
                            }
                            break;

                        case TestType.MesPush: 
                        case TestType.EndTest: 
                        case TestType.StopTest: 
                        default: break;
                    }
                }
                //主机心跳
                ReceiveDataParse.ReceiveParse(CommandHelper.HexStrToByteArray("AA 55 00 19 10 01 0B 01 90 00 00 02 00 00 06 00 00 00 00 09 A6 18 E2 FF FF FF 3F 00 00 00 00 00 00 03"), _controlSystem);
            }
        }

        private void btnTraySet_Click(object sender, EventArgs e)
        {
            var frm = new FormAddTrayID(_mes.MesInfo);
            frm.ShowDialog();
        }
    }
}
