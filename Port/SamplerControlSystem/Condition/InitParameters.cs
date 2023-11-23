using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplerControlSystem.Condition
{
    public enum GasType
    {
        CH4,
        C3H8,
        CO
    }

    [Serializable]
    public class GasParam
    {
        /// <summary>
        /// 标定点1
        /// 甲烷（CH4）    4000ppm
        /// 丙烷（C3H8）   2200ppm
        /// 一氧化碳（CO） 40ppm
        /// </summary>
        public ushort SamplePoint1 { get; set; }

        /// <summary>
        /// 标定点2
        /// 甲烷（CH4）    5000ppm
        /// 丙烷（C3H8）   无（参数为0xFFFF为无效）
        /// 一氧化碳（CO） 100ppm
        /// </summary>
        public ushort SamplePoint2 { get; set; }

        /// <summary>
        /// 标定点1注气时间 0x00 0x64 表示时间为1000ms。（单位：10ms）
        /// 软件单位为s,发送时乘100再转16进制
        /// </summary>
        public float GasInjectionTime1 { get; set; }
        /// <summary>
        /// 标定点2注气时间 0x00 0x64 表示时间为1000ms。（单位：10ms）
        /// </summary>
        public float GasInjectionTime2 { get; set; }

        public GasParam(GasType type)
        {
            switch (type)
            {
                case GasType.CH4: 
                    SamplePoint1 = 4000; 
                    SamplePoint2 = 5000;
                    break;
                case GasType.C3H8:
                    SamplePoint1 = 2200;
                    SamplePoint2 = ushort.MaxValue; 
                    break;
                case GasType.CO: 
                    SamplePoint1 = 40; 
                    SamplePoint2 = 100; 
                    break;
            }
            GasInjectionTime1 = 20;
            GasInjectionTime2 = 40;
        }
    }

    [Serializable]
    public class InitParameters
    {
        /// <summary>
        /// 气体类型
        /// </summary>
        public GasType GasType { get; set; }

        /// <summary>
        /// 按GasType排序
        /// </summary>
        public List<GasParam> GasParams { get; set; } = new List<GasParam>()
        {
        new GasParam(GasType.CH4),
        new GasParam (GasType.C3H8),
        new GasParam(GasType.CO)
        };


        /// <summary>
        /// 限制标定0点电压上/下限单位 mv
        /// </summary>
        public SampleConfig VoltageLimit { get; set; }=new SampleConfig(ParamType.Vol);

        /// <summary>
        /// 限制斜率上/下限
        /// </summary>
        public SampleConfig SlopeLimit { get; set; } = new SampleConfig(ParamType.Slope);

        /// <summary>
        /// 传感器电压波纹范围单位 mv
        /// </summary>
        public float VoltageRippleRange {  get; set; }

        /// <summary>
        /// 校验误差范围
        /// </summary>
        public float CheckDeviationRange {  get; set; }

        /// <summary>
        /// 预热时间传感器板预热时间单位s,(0~1200s) 默认15分钟即900s
        /// </summary>
        public ushort PreheatTime {  get; set; }

        /// <summary>
        /// 运放空载电压上/下限
        /// </summary>
        public SampleConfig IdleVoltageLimit { get; set; } = new SampleConfig(ParamType.Vol);

        /// <summary>
        /// 标定板空载电压范围
        /// </summary>
        public float IdleVoltageRange {  get; set; }

    }
}
