namespace SamplerControlSystem.Entity
{
    public enum SetSensorAttributeType
    {
        CalibrationStatus,
        Voltage0,
        Voltage1,
        Voltage2,
        Slope,
        RealTimeVoltage,
        NonLoadedVoltage,
        ZeroVoltage,

    }

    public enum SensorResultFlags
    {
        None = 0,
        Ok = 0x1,
        Voltage0flow = 0x2,
        Voltage1flow = 0x4,
        Voltage2flow = 0x8,
        Slopeflow = 0x10,
        SlopeCheckError = 0x20,
        ZeroOrNonLoadedVoltageflow = 0x40,
        ParamError=0x08,
        // 尚未测试
        UnMeasured=0x10000,
    }

    public class SensorData
    {
        /// <summary>
        /// 传感器序号
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 传感器绑定的SN
        /// </summary>
        public string BindSN { get; set; }
        /// <summary>
        /// 标定结果,0xA5为成功,其他失败
        /// </summary>
        public byte CalibrationResult { get; private set; } = 0xFF;

        /// <summary>
        /// 标定状态,true为标定正常,其余异常
        /// </summary>
        public bool IsCalibration => CalibrationResult == 0xA5;
        /// <summary>
        /// 预热状态,true为正常
        /// </summary>
        public bool IsNormalPreheat { get; set; } = true;
        /// <summary>
        /// 过站状态,true为已过站
        /// </summary>
        public bool IsPassStation { get; set; }
        /// <summary>
        /// 传感器连接状态
        /// </summary>
        public bool IsConnected { get; set; }

        public SensorResultFlags Flags {
            get
            {
                if (CalibrationResult == 0xFF) return SensorResultFlags.UnMeasured;
                if (CalibrationResult == 0xA5) return SensorResultFlags.Ok;

                var result = SensorResultFlags.None;
                if ((CalibrationResult & 0x01) != 0) result |= SensorResultFlags.ZeroOrNonLoadedVoltageflow;
                if ((CalibrationResult & 0x02) != 0) result |= SensorResultFlags.ParamError;
                if ((CalibrationResult & 0x04) != 0) result |= SensorResultFlags.Slopeflow;
                if ((CalibrationResult & 0x08) != 0) result |= SensorResultFlags.SlopeCheckError;
                if ((CalibrationResult & 0x10) != 0) result |= SensorResultFlags.Voltage0flow;
                if ((CalibrationResult & 0x20) != 0) result |= SensorResultFlags.Voltage1flow;
                if ((CalibrationResult & 0x40) != 0) result |= SensorResultFlags.Voltage2flow;

                return result;
            }
        }

        /// <summary>
        /// 标定0点电压
        /// </summary>
        public float Voltage0 { get; private set; }

        public float Voltage1 { get; private set; }

        public float Voltage2 { get; private set; }

        /// <summary>
        /// 标定斜率
        /// </summary>
        public float CalibrationSlope { get; private set; }

        /// <summary>
        /// 运放实时电压
        /// </summary>
        public float RealTimeVoltage { get; private set; }

        /// <summary>
        /// 空载电压
        /// </summary>
        public float NonLoadedVoltage { get; private set; }

        /// <summary>
        /// 零点电压//预热时,赋值实时电压
        /// </summary>
        public float ZeroVoltage { get; set; } = float.NaN;

        public SensorData(int index)
        {
            Index = index;
        }

        public void SetAttributeValue(ushort data, SetSensorAttributeType type)
        {
            switch (type)
            {
                case SetSensorAttributeType.CalibrationStatus: CalibrationResult = (byte)data; break;
                case SetSensorAttributeType.Voltage0: Voltage0 = (float)data / 10; break;
                case SetSensorAttributeType.Voltage1: Voltage1 = (float)data / 10; break;
                case SetSensorAttributeType.Voltage2: Voltage2 = (float)data / 10; break;
                case SetSensorAttributeType.Slope: CalibrationSlope = (float)data / 1000; break;
                case SetSensorAttributeType.RealTimeVoltage:  RealTimeVoltage = (float)data / 10; break;
                case SetSensorAttributeType.ZeroVoltage: ZeroVoltage = (float)data / 10; break;
                case SetSensorAttributeType.NonLoadedVoltage: NonLoadedVoltage = (float)data / 10; break;
            }
        }


    }
}
