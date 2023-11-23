using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SamplerSystem.UI.Models
{
    [Serializable]
    public class UserInfo
    {
        public List<string> UserNameHistorys { get; set; } = new List<string>();

        public string UserName { get; set; }

        public string Password { get; set; }


        public static UserInfo Load(string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception($"{"未找到配置文件"} {filePath}");
            return JsonConvert.DeserializeObject<UserInfo>(File.ReadAllText(filePath));

        }

        public void Save(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                var json = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii });
                fs.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
            }
        }

    }
}
