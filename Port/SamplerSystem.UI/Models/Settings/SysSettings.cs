using Newtonsoft.Json;
using SamplerControlSystem.Model;
using System;
using System.IO;
using System.Text;

namespace SamplerSystem.UI.Models.Settings
{
    [Serializable]
    public class SysSettings
    {
        public PortSetting PortSettings = new PortSetting();
        public SensorBoardSetting SensorBoardSettings = new SensorBoardSetting();
        public MesSetting MesSettings = new MesSetting();
        public BasicSetting BasicSettings = new BasicSetting();
        public FileSetting FileSettings = new FileSetting();

        public static SysSettings Load(string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception($"{"未找到配置文件"} {filePath}");
            return JsonConvert.DeserializeObject<SysSettings>(File.ReadAllText(filePath));

        }

        public void Save(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                var json = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii });
                fs.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
            }
        }

        //public static SysSettings Get()
        //{
        //    if (_inst == null) _inst = Load();
        //    if (_inst == null) _inst = Create();
        //    return _inst;
        //}
    }
}
