using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SamplerSystem.UI.Condition.Mes
{
    public class UserPost
    {
        // "clientId": "web",
        //"clientSecret": "web",
        //"grantTypes": "web",
        //"identityid": "web",
        //"password": "MTIzNDU2",
        //"username": "en05"

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "clientId")]
        public string ID { get; set; } = "web";

        [JsonProperty(PropertyName = "clientSecret")]
        public string Secret { get; set; } = "web";

        [JsonProperty(PropertyName = "grantTypes")]
        public string Type { get; set; } = "web";

        [JsonProperty(PropertyName = "identityid")]
        public string Identityid {  get; set; } = "web";

        public UserPost(string user,string passWord) 
        {
            UserName = user;
            Password = Convert.ToBase64String(Encoding.Default.GetBytes(passWord ?? ""));
        }
    }
}
