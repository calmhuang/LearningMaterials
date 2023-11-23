using Newtonsoft.Json;
using SamplerSystem.UI.Condition.Mes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SamplerSystem.UI.MES
{
    internal class APICommand
    {
        public static string Command(string url, string data, string token, string method)
        {
            //var log = log4net.LogManager.GetLogger(typeof(APICommand));
            //log.InfoFormat("[{0}:{1}] {2}\r\n{3}", url, method, token, data);
            try
            {
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Ssl3
                    | SecurityProtocolType.Tls
                    | SecurityProtocolType.Tls11
                    | SecurityProtocolType.Tls12;

                var request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = method;
                request.ContentType = "application/json";
                request.ProtocolVersion = HttpVersion.Version10;
                request.Headers["Authorization"] = token;

                if (!method.Contains("GET"))
                {
                    var byteArray = Encoding.UTF8.GetBytes(data);
                    request.ContentLength = byteArray.Length;
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(byteArray, 0, byteArray.Length);
                    }
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
                var body = new ResponseCode() { Code = 0, Message = ee.Message };
                return JsonConvert.SerializeObject(body);
            }
        }

    }
}
