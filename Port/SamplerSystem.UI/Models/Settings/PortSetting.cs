using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplerSystem.UI.Models.Settings
{
    [Serializable]
    public class PortSetting
    {
        //TODO:当没有配置文件对应端口时,有bug
        public string PortName { get; set; } = "COM1";
        public int BaudRate { get; set; } = 115200;
        public Parity Parity { get; set; } = Parity.None;
        public int DataBits { get; set; } = 8;
        public StopBits StopBits { get; set; } = StopBits.One;

        [JsonIgnore]
        public List<string> PortNames = SerialPort.GetPortNames().ToList();

        [JsonIgnore]
        public List<int> BaudRates = new List<int> { 2400, 4800, 9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600 };

        [JsonIgnore]
        public List<Parity> Paritys = new List<Parity> { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };

        [JsonIgnore]
        public List<int> DataBitss = new List<int> { 5, 6, 7, 8 };

        [JsonIgnore]
        public List<StopBits> StopBitss = new List<StopBits> { StopBits.None, StopBits.One, StopBits.Two, StopBits.OnePointFive };

        public PortSetting()
        {
        }

    }
}
