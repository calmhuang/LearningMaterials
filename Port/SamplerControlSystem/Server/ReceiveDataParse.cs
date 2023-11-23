using SamplerControlSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamplerControlSystem.Server
{
    public static class ReceiveDataParse
    {
        public static event Action<string> OnErrorHndle;
        public static event Action OnUpdateDisplay;
        public static event Action OnControlSystemUpdateDisplay;
        public static event Action<byte> OnReceiveCommand;
        
        public static void ReceiveParse(List<byte> receiveData, ControlSystem controlData)
        {
            if (controlData == null) throw new NullReferenceException("用于接收数据的对象是NULL");

            if (receiveData == null || receiveData.Count <= 3) return;

            var checkSum = CommandHelper.CalculateCheckSum(receiveData.ToList(), true);
            if (checkSum == null) return;
            if (!checkSum.Equals(receiveData[receiveData.Count - 1])) return;
            if (!receiveData[0].Equals(0xAA) || !receiveData[1].Equals(0x55)) return;
            if (!(receiveData[4].Equals(0x10) || receiveData[4].Equals(0x07)) || 
                !(receiveData[5].Equals(0x22) || receiveData[5].Equals(0x01))) return;

            var length = (receiveData[2] << 8) + receiveData[3];
            if (receiveData.Count != length + 9) return;

            switch (receiveData[8])
            {
                case 0x01:
                case 0x03:
                case 0x05:
                case 0x50:
                case 0x51:
                case 0x52:
                case 0x53: CommonReceiveParse(receiveData, controlData); break;

                case 0x90:
                    ControlSystemStatusReceiveParse(receiveData, controlData);
                    SamplerCmder.ReplyCommand(receiveData[8].ToString("X2"));
                    break;
                case 0x91:
                case 0x81:
                    if (SensorBoardReceiveParse(receiveData, controlData))
                        SamplerCmder.ReplyCommand(receiveData[8].ToString("X2"));
                    else
                        OnErrorHndle?.Invoke("指令格式错误!" + "错误指令:" + CommandHelper.GetHexStrByBytes(receiveData));
                    break;
                case 0x92:
                    controlData.SetAttributeValue(receiveData[9], SetControlAttributeType.TestStatus);
                    SamplerCmder.ReplyCommand(receiveData[8].ToString("X2"));
                    break;
                case 0x93:
                    if (receiveData[9] == 0x01 && receiveData[10] == 0xFF)
                    {
                        var str = "注样系统异常,请重新启动!错误码:";
                        str += receiveData[11].ToString("X2");
                        str += receiveData[12].ToString("X2");
                        OnErrorHndle?.Invoke(str);
                    }
                    break;
            }

            OnReceiveCommand?.Invoke(receiveData[8]);
            if (receiveData[8] == 0x90)
            {
                OnUpdateDisplay?.Invoke();
                OnControlSystemUpdateDisplay?.Invoke();
            }
        }


        /// <summary>
        /// 答复消息解析使用
        /// </summary>
        /// <param name="receiveData"></param>
        /// <param name="controlData"></param>
        private static void CommonReceiveParse(List<byte> receiveData, ControlSystem controlData)
        {
            var strTemp = "命令号:" + receiveData[8].ToString("X2");
            switch (receiveData[8])
            {
                case 0x01:
                case 0x03:
                    strTemp += " 主机版本号:V" + receiveData[9].ToString("X2");
                    strTemp += " 主机接收:" + (receiveData[10] == 0 ? "失败" : "成功");
                    break;
                case 0x05:
                case 0x51:
                case 0x53:
                    strTemp += " 主机接收:" + (receiveData[9] == 0 ? "失败" : "成功");
                    break;
                case 0x50:
                    strTemp += " 硬件版本号:V" + ((receiveData[9] << 8) + receiveData[10]).ToString("X4");
                    strTemp += " 软件版本号:V" + ((receiveData[11] << 8) + receiveData[12]).ToString("X4");
                    break;
                case 0x52:
                    strTemp += " 主机接收:" + (receiveData[9] == 0 ? "失败" : "成功");
                    switch (receiveData[10])
                    {
                        case 0x00:
                            strTemp += " 全部成功，等待更新"; break;
                        case 0x01:
                            strTemp += " 正在升级中"; break;
                        case 0x02:
                            strTemp += " 未全部成功-校验失败-存在失败节点"; break;
                        case 0xFF:
                            strTemp += " OTA固件更新完成"; break;
                    }
                    break;
            }
            
            controlData.ReceiveRemarks = strTemp+" "+DateTime.Now.ToString();
        }

        /// <summary>
        /// 主机上报当前主机状态0x90解析使用
        /// </summary>
        /// <param name="receiveData"></param>
        /// <param name="controlData"></param>
        private static void ControlSystemStatusReceiveParse(List<byte> receiveData, ControlSystem controlData)
        {
            controlData.SetAttributeValue((ushort)((receiveData[9] << 8) + receiveData[10]), SetControlAttributeType.SampleInjectorConnectionStatus);

            controlData.ControlSystemStatus.SetAttributeValue((ushort)((receiveData[11] << 8) + receiveData[12]));

            controlData.SetAttributeValue((ushort)((receiveData[13] << 8) + receiveData[14]), SetControlAttributeType.Analyzer1Concentration);
            controlData.SetAttributeValue((ushort)((receiveData[15] << 8) + receiveData[16]), SetControlAttributeType.Analyzer2Concentration);
            controlData.SetAttributeValue((ushort)((receiveData[17] << 8) + receiveData[18]), SetControlAttributeType.Analyzer3Concentration);

            controlData.SetAttributeValue((ushort)((receiveData[19] << 8) + receiveData[20]), SetControlAttributeType.FixtureTemperature);
            controlData.SetAttributeValue((ushort)((receiveData[21] << 8) + receiveData[22]), SetControlAttributeType.FixtureHumidity);

            for (var i = 0; i < 10; i++)
            {
                var equalsByte = 0x01;      
                var statusByte = receiveData[23 + i];
                for (var j = 0; j < 8; j++)
                {
                    var index = (byte)(i * 8 + j);
                    var connectStatus = byte.MaxValue;
                    if ((statusByte & equalsByte) == 0)
                        connectStatus = byte.MinValue;
                    controlData.SetAttributeValue((ushort)((connectStatus << 8) + index), SetControlAttributeType.ConnectedStatus);
                    equalsByte <<= 1;
                }
            }
        }


        /// <summary>
        /// 主机上报当前从机的标定数据（命令号0x91）(实际命令号:0x81) 解析使用
        /// </summary>
        /// <param name="receiveData"></param>
        /// <param name="controlData"></param>
        private static bool SensorBoardReceiveParse(List<byte> receiveData, ControlSystem controlData)
        {
            // 
            var index = receiveData[12] - 1;
            if (index < 0 || controlData.SensorBoards.Count <= index) return false;

            var sensorBoard = controlData.SensorBoards[index];
            sensorBoard.SetSensorStatus(receiveData[9]);
            sensorBoard.SensorBoardVersion = receiveData[10];
            sensorBoard.SensorNumber = receiveData[11];
            sensorBoard.SensorBoardID = receiveData[12];
            if (sensorBoard.SensorNumber != sensorBoard.SensorDatas.Count) return false;

            for (var i = 0; i < sensorBoard.SensorNumber; i++)
            {
                var offset = i * 14;
                //用传感器ID索引对应的传感器对象
                var sensorId = receiveData[13 + offset];
                var sensor = sensorBoard.SensorDatas[sensorId - 1];

                //所有阶段都需要赋值实时电压和空载电压
                sensor.SetAttributeValue((ushort)((receiveData[23 + offset] << 8) + receiveData[24 + offset]), SetSensorAttributeType.RealTimeVoltage);
                sensor.SetAttributeValue((ushort)((receiveData[25 + offset] << 8) + receiveData[26 + offset]), SetSensorAttributeType.NonLoadedVoltage);
                if (sensorBoard.SensorStatus == SensorStatusType.Preheating)
                {
                    //预热阶段设置预热状态和零点电压
                    sensor.IsNormalPreheat = receiveData[14 + offset] == 0;
                    sensor.SetAttributeValue((ushort)((receiveData[23 + offset] << 8) + receiveData[24 + offset]), SetSensorAttributeType.ZeroVoltage);
                    continue;
                }
                if (sensorBoard.SensorStatus != SensorStatusType.Point2CalibrationCompleted) continue;

                //标定完成,设置其余标定值
                sensor.SetAttributeValue(receiveData[14 + offset], SetSensorAttributeType.CalibrationStatus);
                sensor.SetAttributeValue((ushort)((receiveData[15 + offset] << 8) + receiveData[16 + offset]), SetSensorAttributeType.Voltage0);
                sensor.SetAttributeValue((ushort)((receiveData[17 + offset] << 8) + receiveData[18 + offset]), SetSensorAttributeType.Voltage1);
                sensor.SetAttributeValue((ushort)((receiveData[19 + offset] << 8) + receiveData[20 + offset]), SetSensorAttributeType.Voltage2);
                sensor.SetAttributeValue((ushort)((receiveData[21 + offset] << 8) + receiveData[22 + offset]), SetSensorAttributeType.Slope);
            }
            return true;
        }

    }
}
