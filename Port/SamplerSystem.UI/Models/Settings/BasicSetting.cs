using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplerSystem.UI.Models.Settings
{
    [Serializable]
    public class BasicSetting
    {
        public int TrayNum { get; set; } = 3;

        public int TrayRow { get; set; } = 20;

        public int TrayCol { get; set; } = 10;

        public int SensorBradNum { get; set; } = 30;

        public int SensorNum { get; set; } = 20;

        public int InjectionTime { get; set; } = 20;

        public int Sample2 { get; set; } = 0;

        public int Sample3 { get; set; } = 0;

        public int RefreshTime { get; set; }

        public BasicSetting() { }
    }
}
