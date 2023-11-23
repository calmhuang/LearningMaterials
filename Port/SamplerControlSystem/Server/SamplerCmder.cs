using SamplerControlSystem.Condition;
using SamplerControlSystem.Model;
using System.Collections.Generic;

namespace SamplerControlSystem.Server
{
    public class SamplerCmder
    {
        /// <summary>
        /// 保存上一次发送命令,对接收回复的命令进行对比
        /// </summary>
        public static byte CheckCmd = 0xFF;
        /// <summary>
        /// 初始化设备参数信息（命令号0x01）
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static byte[] Init(SensorBoardSetting setting)
        {
            CheckCmd = 0x01;
            var ret = new List<byte>();
            var i = -1;
            var strTemp = "01";
            switch (setting.GasType)
            {
                case GasType.CH4: strTemp += "01"; i = 0; break;
                case GasType.C3H8: strTemp += "02"; i = 1; break;
                case GasType.CO: strTemp += "03"; i = 2; break;
            }
            if (i == -1) return null;
            strTemp += setting.GasParams[i].SamplePoint1.ToString("X4");
            strTemp += setting.GasParams[i].SamplePoint2.ToString("X4");
            strTemp += ((ushort)(setting.GasParams[i].GasInjectionTime1 * 100)).ToString("X4");
            strTemp += ((ushort)(setting.GasParams[i].GasInjectionTime2 * 100)).ToString("X4");

            strTemp += ((ushort)(setting.VoltageLimit.Min * 10 * setting.VoltageLimit.Decimal)).ToString("X4");
            strTemp += ((ushort)(setting.VoltageLimit.Max * 10 * setting.VoltageLimit.Decimal)).ToString("X4");
            strTemp += ((ushort)(setting.SlopeLimit.Min * 10 * setting.SlopeLimit.Decimal)).ToString("X4");
            strTemp += ((ushort)(setting.SlopeLimit.Max * 10 * setting.SlopeLimit.Decimal)).ToString("X4");

            strTemp += ((ushort)(setting.VoltageRippleRange * 10)).ToString("X4");
            strTemp += ((ushort)(setting.CheckDeviationRange * 10)).ToString("X4");
            strTemp += ((ushort)(setting.PreheatTime)).ToString("X4");

            strTemp += ((ushort)(setting.IdleVoltageLimit.Max * 10 * setting.IdleVoltageLimit.Decimal)).ToString("X4");
            strTemp += ((ushort)(setting.IdleVoltageLimit.Min * 10 * setting.IdleVoltageLimit.Decimal)).ToString("X4");
            strTemp += ((ushort)(setting.IdleVoltageRange * 10)).ToString("X4");

            ret.AddRange(CommandHelper.GetCompleteCommand(CommandHelper.HexStrToByteArray(strTemp)));
            return ret.ToArray();
        }

        /// <summary>
        /// 上位机主动查询所有从机的标定数据（命令号0x05）
        /// </summary>
        /// <returns></returns>
        public static byte[] QuerySampleResults()
        {
            CheckCmd = 0x05;
            var ret = new List<byte>();
            var strTemp = "0501";

            ret.AddRange(CommandHelper.GetCompleteCommand(CommandHelper.HexStrToByteArray(strTemp)));
            return ret.ToArray();
        }

        /// <summary>
        /// 上位机升级固件块下发（命令号0x52）
        /// </summary>
        /// <param name="upgradeFirmwareParam"></param>
        /// <returns></returns>
        public static byte[] UpgradeFirmware(UpgradeFirmwareParameters upgradeFirmwareParam)
        {
            CheckCmd = 0x52;
            var ret = new List<byte>();
            var strTemp = "52";

            ret.AddRange(CommandHelper.GetCompleteCommand(CommandHelper.HexStrToByteArray(strTemp)));
            return ret.ToArray();
        }

        /// <summary>
        /// 上位机升级固件信息通知（命令号0x51）
        /// </summary>
        /// <param name="upgradeFirmwareParam"></param>
        /// <returns></returns>
        public static byte[] UpgradeFirmwareNotice(UpgradeFirmwareNoticeParameters upgradeFirmwareParam)
        {
            CheckCmd = 0x51;
            var ret = new List<byte>();
            var strTemp = "51";

            ret.AddRange(CommandHelper.GetCompleteCommand(CommandHelper.HexStrToByteArray(strTemp)));
            return ret.ToArray();
        }

        /// <summary>
        /// 上位机设置气体标定指令（命令号0x03）
        /// </summary>
        /// <param name="writeCmdParam"></param>
        /// <returns></returns>
        public static byte[] WriteCommand(WriteCmdParameters writeCmdParam)
        {
            CheckCmd = 0x03;
            var ret = new List<byte>();
            var strTemp = "03";

            strTemp += ((byte)writeCmdParam.CmdType).ToString("X2");
            switch (writeCmdParam.CmdType)
            {
                case CmdType.Check40PPM: strTemp += ((ushort)(writeCmdParam.Sample2 * 10)).ToString("X4"); break;
                case CmdType.Check1000PPM: strTemp += ((ushort)(writeCmdParam.Sample3 * 10)).ToString("X4"); break;
                case CmdType.Start:
                case CmdType.InjectionGas: strTemp += ((ushort)(writeCmdParam.InjectionGasTime * 100)).ToString("X4"); break;
                default: strTemp += "FFFF"; break;
            }

            ret.AddRange(CommandHelper.GetCompleteCommand(CommandHelper.HexStrToByteArray(strTemp)));
            return ret.ToArray();
        }

        /// <summary>
        /// 接收后回复指令
        /// </summary>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static byte[] ReplyCommand(string cmdType)
        {
            var ret = new List<byte>();
            var strTemp = cmdType + "01";

            ret.AddRange(CommandHelper.GetCompleteCommand(CommandHelper.HexStrToByteArray(strTemp)));
            return ret.ToArray();
        }

    }
}
