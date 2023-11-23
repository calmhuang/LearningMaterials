using Newtonsoft.Json;
using SamplerControlSystem.Condition;
using System;
using System.Collections.Generic;

namespace SamplerControlSystem.Model
{
    [Serializable]
    public class SensorBoardSetting
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

        [JsonIgnore]
        public GasParam GasParam => GasParams[(int)GasType];

        /// <summary>
        /// 限制标定0点电压上/下限单位 mv
        /// </summary>
        public SampleConfig VoltageLimit { get; set; } = new SampleConfig(ParamType.Vol);

        /// <summary>
        /// 限制斜率上/下限
        /// </summary>
        public SampleConfig SlopeLimit { get; set; } = new SampleConfig(ParamType.Slope);

        /// <summary>
        /// 传感器电压波纹范围单位 mv
        /// </summary>
        public float VoltageRippleRange { get; set; }

        /// <summary>
        /// 校验误差范围
        /// </summary>
        public float CheckDeviationRange { get; set; }

        /// <summary>
        /// 预热时间传感器板预热时间单位s,(0~1200s) 默认15分钟即900s
        /// </summary>
        public ushort PreheatTime { get; set; }

        /// <summary>
        /// 运放空载电压上/下限
        /// </summary>
        public SampleConfig IdleVoltageLimit { get; set; } = new SampleConfig(ParamType.Vol);

        /// <summary>
        /// 标定板空载电压范围
        /// </summary>
        public float IdleVoltageRange { get; set; }


        /// <summary>
        /// ve-v0最小电压值
        /// </summary>
        public float VolMinDifference {  get; set; }

        /// <summary>
        /// 注气超时时间
        /// </summary>
        public int GasInjectionTimeout { get; set; }

        /// <summary>
        /// 温度上下限
        /// </summary>
        public SampleConfig TemperatureLimit { get; set; } = new SampleConfig(ParamType.Temperature);


        /// <summary>
        /// 湿度上下限
        /// </summary>
        public SampleConfig HumidityLimit { get; set; } = new SampleConfig(ParamType.Humidity);

        /// <summary>
        /// 串口指令回复超时时间
        /// </summary>
        public int PortTimeout { get; set; }

    }
}
