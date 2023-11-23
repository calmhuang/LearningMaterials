using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplerControlSystem.Condition
{
    public enum ParamType
    {
        Vol,
        Slope,
        Temperature,
        Humidity,
    }

    [Serializable]
    public class SampleConfig
    {
        public ParamType ParamType { get; set; }

        public string Unit { get; set; }

        public float Min { get; set; }

        public float Max { get; set; }

        public int Decimal { get; set; }


        [JsonIgnore]
        public string Name => $"{Min}-{Max} {Unit}";

        public SampleConfig() { }
        public SampleConfig(ParamType type)
        {
            switch(type)
            {
                case ParamType.Vol:Decimal = 1;Unit = "mV"; break;
                case ParamType.Slope:Decimal = 3;Unit = "mV/ppm"; break;
                case ParamType.Temperature: Decimal = 1;Unit = "°C"; break;
                case ParamType.Humidity: Decimal = 1;Unit = "%"; break;
            }
            Min = 0; Max = 0;
        }
    }
}
