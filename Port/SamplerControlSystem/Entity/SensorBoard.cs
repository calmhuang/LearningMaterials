using System.Collections.Generic;

namespace SamplerControlSystem.Entity
{
    public enum SensorStatusType
    {
        /// <summary>
        /// 等待预热
        /// </summary>
        WaitPreheat,
        /// <summary>
        /// 预热中
        /// </summary>
        Preheating,
        /// <summary>
        /// 第1点标定中
        /// </summary>
        Point1Calibration,
        /// <summary>
        /// 第1点标定完成
        /// </summary>
        Point1CalibrationCompleted,
        /// <summary>
        /// 第2点标定中
        /// </summary>
        Point2Calibration,
        /// <summary>
        /// 第2点标定完成
        /// </summary>
        Point2CalibrationCompleted,
        /// <summary>
        /// 第3点标定中
        /// </summary>
        Point3Calibration,
        /// <summary>
        /// 第3点标定完成
        /// </summary>
        Point3CalibrationCompleted,

        ///// <summary>
        ///// 传感器板断开连接
        ///// </summary>
        //SensorBoardDisconnected,
    }

    public class SensorBoard
    {
        /// <summary>
        /// 传感器板ID
        /// </summary>
        public int SensorBoardID { get; set; }

        /// <summary>
        /// 传感器板版本
        /// </summary>
        public int SensorBoardVersion { get; set; }

        /// <summary>
        /// 传感器数量
        /// </summary>
        public int SensorNumber { get; set; }

        /// <summary>
        /// 传感器板连接状态
        /// </summary>
        public bool IsConnected { get; private set; }

        public List<SensorData> SensorDatas { get; set; } = new List<SensorData>();

        public bool IsProductDeviceOK = true;

        public bool IsPushDataOK = true;
        /// <summary>
        /// 传感器板标定状态
        /// </summary>
        public SensorStatusType SensorStatus { get; private set; }

        public void SetConnectedValue(bool value)
        {
            IsConnected = value;
            foreach (var sensor in SensorDatas)
            {
                sensor.IsConnected = value;
            }
        }

        public void SetSensorStatus(byte value)
        {
            switch (value)
            {
                case 0x00: SensorStatus = SensorStatusType.WaitPreheat; break;
                case 0x01: SensorStatus = SensorStatusType.Preheating; break;
                case 0x02: SensorStatus = SensorStatusType.Point1Calibration; break;
                case 0x03: SensorStatus = SensorStatusType.Point1CalibrationCompleted; break;
                case 0x04: SensorStatus = SensorStatusType.Point2Calibration; break;
                case 0x05: SensorStatus = SensorStatusType.Point2CalibrationCompleted; break;
                case 0x06: SensorStatus = SensorStatusType.Point3Calibration; break;
                case 0x07: SensorStatus = SensorStatusType.Point3CalibrationCompleted; break;
                case 0xFF: SetConnectedValue(false); break;
            }
        }

    }
}
