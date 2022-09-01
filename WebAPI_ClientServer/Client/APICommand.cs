using Newtonsoft.Json;
using Piccolo.Condition.WebCondition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Piccolo.UI.JiJiaMES
{
    class APICommand
    {
        public static string Post(string url, string data)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                    SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                var request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";

                var byteArray = Encoding.UTF8.GetBytes(data);
                request.ContentLength = byteArray.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(byteArray, 0, byteArray.Length);
                }

                var response = request.GetResponse() as HttpWebResponse;
                var ret = string.Empty;
                using (var mySR = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    ret = mySR.ReadToEnd();
                }

                return ret;
            }
            catch (WebException ee)
            {
                var body = new ResponseBody() { Code = 0, Message = ee.Message };
                return JsonConvert.SerializeObject(body);
            }
        }

        public static string Get(string url)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                    SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                var request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/json";

                var response = request.GetResponse() as HttpWebResponse;
                var ret = string.Empty;
                using (var mySR = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    ret = mySR.ReadToEnd();
                }

                return ret;
            }
            catch (WebException ee)
            {
                var body = new ResponseBody() { Code = 0, Message = ee.Message };
                return JsonConvert.SerializeObject(body);
            }
        }
    }
}
