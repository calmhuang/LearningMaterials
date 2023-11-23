using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplerSystem.UI.Condition.Mes
{
    public class ResponseCode
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }

        [JsonProperty(PropertyName = "msg")]
        public string Message { get; set; }

        public static string GetResponseCodeTitle(int code)
        {
            switch (code)
            {
                case 200:
                    return "Succeed";
                case 201:
                    return "Created";
                case 401:
                    return "Unauthorized";
                case 403:
                    return "Forbidden";
                case 404:
                    return "Not Fuound";
                default:
                    return "Error";
            }
        }
    }
}
