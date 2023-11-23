using System.Collections.Generic;
using System.Reflection;

namespace SamplerControlSystem.Entity
{
    public enum SetControlAttributeType
    {
        SampleInjectorConnectionStatus,
        Analyzer1Concentration,
        Analyzer2Concentration,
        Analyzer3Concentration,
        FixtureTemperature,
        FixtureHumidity,
        ConnectedStatus,
        TestStatus,

    }
    public class ControlSystem
    {
        /// <summary>
        /// 标定阶段,整体显示用
        /// </summary>
        public SensorStatusType TestStatus { get; private set; } = SensorStatusType.WaitPreheat;

        /// <summary>
        /// 标定状态
        /// </summary>
        public string SampleStatus
        {
            get
            {
                switch (TestStatus)
                {
                    case SensorStatusType.WaitPreheat: return "等待预热";
                    case SensorStatusType.Preheating: return "预热中...";
                    case SensorStatusType.Point1Calibration: return "第一点标定中...";
                    case SensorStatusType.Point2Calibration: return "第二点标定中...";
                    case SensorStatusType.Point3Calibration: return "第三点标定中...";
                    case SensorStatusType.Point3CalibrationCompleted: return "第三点标定完成";
                    case SensorStatusType.Point2CalibrationCompleted: return "第二点标定完成";
                    case SensorStatusType.Point1CalibrationCompleted: return "第一点标定完成";
                    default: return "标定状态错误";
                }
            }
        }


        ///// <summary>
        ///// 气体当前浓度
        ///// </summary>
        //public ushort CurrentGasConcentration { get; private set; }

        /// <summary>
        /// 主机及注样仪等设备状态信息
        /// </summary>
        public ControlSystemStatus ControlSystemStatus { get; set; } = new ControlSystemStatus();

        /// <summary>
        /// 标定完成
        /// </summary>
        public bool IsSampleComplete
        {
            get
            {
                foreach (var sBoard in SensorBoards)
                {
                    if (!sBoard.IsConnected) continue;
                    if (sBoard.SensorStatus != SensorStatusType.Point3CalibrationCompleted) return false;
                }
                return true;
            }
        }
        /// <summary>
        /// 传感器板
        /// </summary>
        public List<SensorBoard> SensorBoards { get; set; } = new List<SensorBoard>();



        public int Point1CalibrationNum
        {
            get
            {
                var i = 0;
                foreach (var sBoard in SensorBoards)
                {
                    if (sBoard.SensorStatus == SensorStatusType.Point1CalibrationCompleted)
                        i += sBoard.SensorNumber;
                }
                return i;
            }
        }
        public int Point2CalibrationNum
        {
            get
            {
                var i = 0;
                foreach (var sBoard in SensorBoards)
                {
                    if (sBoard.SensorStatus == SensorStatusType.Point2CalibrationCompleted)
                        i += sBoard.SensorNumber;
                }
                return i;
            }
        }
        public int Point3CalibrationNum
        {
            get
            {
                var i = 0;
                foreach (var sBoard in SensorBoards)
                {
                    if (sBoard.SensorStatus == SensorStatusType.Point3CalibrationCompleted)
                        i += sBoard.SensorNumber;
                }
                return i;
            }
        }

        public int CalibrationNum
        {
            get
            {
                var i = 0;
                foreach (var sBoard in SensorBoards)
                {
                    foreach (var sensor in sBoard.SensorDatas)
                    {
                        if (sensor.IsCalibration)
                            i++;
                    }
                }
                return i;
            }
        }

        public int NormalPreheatNum
        {
            get
            {
                var i = 0;
                foreach (var sBoard in SensorBoards)
                {
                    foreach (var sensor in sBoard.SensorDatas)
                    {
                        if (sensor.IsNormalPreheat)
                            i++;
                    }
                }
                return i;
            }
        }

        public int PassStationNum
        {
            get
            {
                var i = 0;
                foreach (var sBoard in SensorBoards)
                {
                    foreach (var sensor in sBoard.SensorDatas)
                    {
                        if (sensor.IsPassStation)
                            i++;
                    }
                }
                return i;
            }
        }

        public int ConnectedNum
        {
            get
            {
                var i = 0;
                foreach (var sBoard in SensorBoards)
                {
                    foreach (var sensor in sBoard.SensorDatas)
                    {
                        if (sensor.IsConnected)
                            i++;
                    }
                }
                return i;
            }
        }

        /// <summary>
        /// 注样仪连接状态,0正常为true,1断开false
        /// </summary>
        public bool SampleInjectorConnectionStatus { get; private set; }

        /// <summary>
        /// 分析仪实时浓度
        /// </summary>
        public float Analyzer1Concentration { get; private set; }

        /// <summary>
        /// 第二点标定时分析仪浓度值（40点PPM）
        /// </summary>
        public float Analyzer2Concentration { get; private set; }

        /// <summary>
        /// 第三点标定时分析仪浓度值（100点PPM)
        /// </summary>
        public float Analyzer3Concentration { get; private set; }

        /// <summary>
        /// 治具温度
        /// </summary>
        public float FixtureTemperature { get; private set; }

        /// <summary>
        /// 治具湿度
        /// </summary>
        public float FixtureHumidity { get; private set; }

        /// <summary>
        /// 治具信息,温度湿度浓度
        /// </summary>
        public string FixtureInfo => "浓度:" + $"{Analyzer1Concentration}ppm" + " 温度:" + $"{FixtureTemperature}℃" + " 湿度:" + $"{FixtureHumidity}%";

        /// <summary>
        /// 普通接收消息备注显示
        /// </summary>
        public string ReceiveRemarks { get; set; }

        public ControlSystem(int sensorBradNum = 30, int sensorNum = 20)
        {
            for (int i = 0; i < sensorBradNum; i++)
            {
                var sensorBrad = new SensorBoard();
                for (var j = 0; j < sensorNum; j++)
                {
                    var sensor = new SensorData(i * sensorNum + j + 1);

                    sensorBrad.SensorDatas.Add(sensor);
                }
                SensorBoards.Add(sensorBrad);
            }
        }

        public void NewSampleTest(int sensorBradNum = 30, int sensorNum = 20)
        {
            for (var i = 0; i < SensorBoards.Count; i++)
            {
                for (var j = 0; j < SensorBoards[i].SensorDatas.Count; j++)
                {
                    SensorBoards[i].SensorDatas[j] = new SensorData(i * sensorNum + j + 1);
                }
                SensorBoards[i].SetConnectedValue(SensorBoards[i].IsConnected);
            }
            TestStatus = SensorStatusType.WaitPreheat;
        }

        public void SetAttributeValue(ushort value, SetControlAttributeType type)
        {
            switch (type)
            {
                case SetControlAttributeType.SampleInjectorConnectionStatus:
                    SampleInjectorConnectionStatus = value == 0;
                    break;
                case SetControlAttributeType.Analyzer1Concentration:
                    Analyzer1Concentration = (float)value / 10;
                    break;
                case SetControlAttributeType.Analyzer2Concentration:
                    Analyzer2Concentration = value;
                    break;
                case SetControlAttributeType.Analyzer3Concentration:
                    Analyzer3Concentration = value;
                    break;
                case SetControlAttributeType.FixtureHumidity:
                    FixtureHumidity = (float)value / 100;
                    break;
                case SetControlAttributeType.FixtureTemperature:
                    FixtureTemperature = (float)value / 100; break;
                case SetControlAttributeType.ConnectedStatus:
                    var index = (byte)value;
                    var connectStatus = (byte)(value >> 8);
                    if (index >= SensorBoards.Count) return;
                    SensorBoards[index].SetConnectedValue(connectStatus == 0xFF);
                    break;
                case SetControlAttributeType.TestStatus:
                    switch ((byte)value)
                    {
                        case 0x00: TestStatus = SensorStatusType.WaitPreheat; break;
                        case 0x01: TestStatus = SensorStatusType.Preheating; break;
                        case 0x02: TestStatus = SensorStatusType.Point1Calibration; break;
                        case 0x03: TestStatus = SensorStatusType.Point1CalibrationCompleted; break;
                        case 0x04: TestStatus = SensorStatusType.Point2Calibration; break;
                        case 0x05: TestStatus = SensorStatusType.Point2CalibrationCompleted; break;
                        case 0x06: TestStatus = SensorStatusType.Point3Calibration; break;
                        case 0x07: TestStatus = SensorStatusType.Point3CalibrationCompleted; break;

                        //case 0xFF: TestStatus = SensorStatusType.SensorBoardDisconnected; break;
                    }
                    break;
            }
        }


        private int _sensorBradIndex = 0;
        public void SetSensorBindSN(List<string> sns)
        {
            if (sns == null || sns.Count == 0) return;
            var index = 0;

            foreach (var sn in sns)
            {
                SensorBoards[_sensorBradIndex].SensorDatas[index++].BindSN = sn;
                if (index >= SensorBoards[_sensorBradIndex].SensorDatas.Count)
                {
                    index = 0;
                    _sensorBradIndex++;
                    if (_sensorBradIndex >= SensorBoards.Count) _sensorBradIndex = 0; 
                }
            }
        }



    }
}
