using Newtonsoft.Json;
using SamplerControlSystem.Entity;
using SamplerSystem.UI.Condition.Mes;
using SamplerSystem.UI.Models.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SamplerSystem.UI.MES
{
    internal enum PtocessType
    {
        PUT,
        POST,
        GET
    }

    public class MesAPI : ContextBoundObject
    {
        public bool IsOnline => !string.IsNullOrEmpty(_token);
        public MesInfo MesInfo { get; private set; }

        private const string TokenType = "Bearer ";

        private readonly string _token;
        private MesSetting _mesSettings;

        public MesAPI(MesSetting mesSettings, MesInfo mesInfo = null)
        {
            _mesSettings = mesSettings;
            _token = string.Empty;
            MesInfo = mesInfo ?? new MesInfo();
        }

        private string UrlCombine(string url, string value = "")
        {
            return _mesSettings.Url + url + value;
        }

        private ResponseCode Process(PtocessType type, string url, string value)
        {
            var temp = string.Empty;
            switch (type)
            {
                case PtocessType.PUT: temp = "PUT"; break;
                case PtocessType.POST: temp = "POST"; break;
                case PtocessType.GET: temp = "GET"; break;
            }
            var ret = JsonConvert.DeserializeObject<ResponseCode>(APICommand.Command(url, value, _token, temp));

            return ret;
        }

        private void PromptCommand(ResponseCode value)
        {
            if (value == null)
            {
                MessageBox.Show("响应体为空（Null），请检查后重试！", "错误");
                return;
            }

            if (value.Code != 200)
            {
                var title = ResponseCode.GetResponseCodeTitle(value.Code);

                MessageBox.Show(value.Message, title);
            }
        }

        /// <summary>
        /// 用户登录获取令牌
        /// </summary>
        public bool PostToken(string userName,string passWord)
        {
            var strValue = JsonConvert.SerializeObject(new UserPost(userName, passWord), Formatting.Indented);

            var data = Process(PtocessType.POST,UrlCombine(_mesSettings.PostToken), strValue);

            if (data != null && data.Code == 200)
            {
                var obj = Newtonsoft.Json.Linq.JObject.Parse(data.Data.ToString());
                var token = TokenType + obj["access_token"].ToString();

                this.GetType()
                    .GetField("_token", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(this, token);
                return true;
            }
            else
            {
                PromptCommand(data);

                return false;
            }
        }

        /// <summary>
        /// 获取工单信息
        /// </summary>
        public bool PostWODto()
        {
            var strValue = "{\"orderCode\":\"" + MesInfo.WO + "\"}";

            var data = Process(PtocessType.POST, UrlCombine(_mesSettings.PostWODto), strValue);

            if (data != null && data.Code == 200)
            {
                MesInfo.WOResponse = JsonConvert.DeserializeObject<List<WOResponse>>(data.Data.ToString()).FirstOrDefault();
                return true;
            }
            else
            {
                PromptCommand(data);

                return false;
            }
        }


        /// <summary>
        /// 获取厂商信息设置到MesInfo中
        /// </summary>
        /// <returns></returns>
        public bool GetCompanyInfo()
        {
            var strValue = "{\"page\":\"1\",\"pageSize\":\"8\"}";
            var data = Process(PtocessType.POST,UrlCombine(_mesSettings.PostCompanyInfo), strValue);
            if (data != null && data.Code == 200)
            {
                var obj = Newtonsoft.Json.Linq.JObject.Parse(data.Data.ToString())["data"];
                MesInfo.CompanyInfos = JsonConvert.DeserializeObject<List<CompanyInfo>>(obj.ToString());

                return true;
            }

            PromptCommand(data);

            return false;
        }

        /// <summary>
        /// 获取车间
        /// </summary>
        public bool PostWorkShop()
        {
            var strValue = "{\"companyId\":\"" + MesInfo.CompanyId + "\"}";

            var data = Process(PtocessType.POST,UrlCombine(_mesSettings.PostWorkShopList), strValue);
            if (data != null && data.Code == 200)
            {
                var obj = Newtonsoft.Json.Linq.JObject.Parse(data.Data.ToString())["data"];
                MesInfo.WorkShopInfos = JsonConvert.DeserializeObject<List<WorkShopInfo>>(obj.ToString());
                return true;
            }

            PromptCommand(data);

            return false;
        }
        /// <summary>
        /// 获取线别
        /// </summary>
        public bool PostWorkLine()
        {
            var strValue = "{\"shopId\":\"" + MesInfo.WorkShopId + "\"}";

            var data = Process(PtocessType.POST,UrlCombine(_mesSettings.PostWorkLineList), strValue);
            if (data != null && data.Code == 200)
            {
                var obj = Newtonsoft.Json.Linq.JObject.Parse(data.Data.ToString())["data"];
                MesInfo.WorkLineInfos = JsonConvert.DeserializeObject<List<WorkLineInfo>>(obj.ToString());
                return true;
            }

            PromptCommand(data);

            return false;
        }

        /// <summary>
        /// 获取工序名称
        /// </summary>
        public bool PostVersionNode()
        {
            var strValue = "{\"craftLineVersionId\":\"" + MesInfo.WOResponse?.CraftID + "\",\"nodeShowMode\":\"SHOW_ON_UPPER\"}";
            var data = Process(PtocessType.POST,UrlCombine(_mesSettings.PostVersionNode), strValue);

            if (data != null && data.Code == 200)
            {
                var obj = Newtonsoft.Json.Linq.JObject.Parse(data.Data.ToString())["detailVOList"];
                MesInfo.CraftInfos = JsonConvert.DeserializeObject<List<CraftInfo>>(obj.ToString());
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 过站需要(工序ID,工单号,sn/imen/mac的值)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool PostProductDevice(string sn)
        {
            var strValue = "{\"craftLineVersionId\":\"" + MesInfo.CraftNodeId + "\",\"orderCode\":\"" + MesInfo.WO + "\",\"sn\":\"" + sn + "\"}";
            var data = Process(PtocessType.POST, UrlCombine(_mesSettings.PostProductDevice), strValue);

            if (data != null && data.Code == 200)
            {
                return true;
            }

            //PromptCommand(data);
            return false;
        }

        /// <summary>
        /// 托盘解绑
        /// </summary>
        public bool PostUnbindTray(string trayID)
        {
            var strValue = "{\"dragTrayCode\":\"" + trayID + "\"}";
            var data = Process(PtocessType.POST, UrlCombine(_mesSettings.PostUnbindTray), strValue);

            if (data != null && data.Code == 200)
            {
                return true;
            }

            //PromptCommand(data);
            return false;
        }
        /// <summary>
        /// 创建托盘对应的SNList,标定不用该接口
        /// </summary>
        /// <param name="trayID"></param>
        /// <returns></returns>
        public bool PostSetTrayInfo(string trayID,string wo,int count)
        {
            var strValue = "{\"dragTrayCode\":\"" + trayID + "\",\"count\":\"" + count + "\",\"orderCode\":\"" + wo + "\"}";
            var data = Process(PtocessType.POST, UrlCombine(_mesSettings.PostUnbindTray), strValue);

            if (data != null && data.Code == 200)
            {
                return true;
            }

            PromptCommand(data);
            return false;
        }

        /// <summary>
        /// 用托盘ID获取SNList
        /// </summary>
        /// <param name="trayID"></param>
        /// <returns></returns>
        public bool PostGetTrayInfo(string trayID, ControlSystem controlSystem)
        {
            var strValue = "{\"dragTrayCode\":\"" + trayID + "\"}";
            var data = Process(PtocessType.POST, UrlCombine(_mesSettings.PostUnbindTray), strValue);

            if (data != null && data.Code == 200)
            {
                //TODO:SN解析赋值
                var obj = Newtonsoft.Json.Linq.JObject.Parse(data.Data.ToString())["snList"];
                controlSystem.SetSensorBindSN(JsonConvert.DeserializeObject<List<string>>(obj.ToString()));

                return true;
            }

            PromptCommand(data);
            return false;
        }

        /// <summary>
        /// 上传传感器标定数据
        /// </summary>
        /// <param name="jsonValue"></param>
        /// <param name="wo"></param>
        /// <param name="sn"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool PostSetSampleResult(string jsonValue, string sn, SensorResultFlags sensorResult)
        {
            var strValue = "{\"craftLineVersionNodeId\":\"" + MesInfo.CraftNodeId + "\",\"orderCode\":\"" + MesInfo.WO + "\",\"sn\":\"" + sn +
                "\",\"sourceTypeId\":7,\"logTypeId\":" + (sensorResult == SensorResultFlags.Ok ? 0 : 5) + ",\"shiftId\":0,\"lineId\":\"" +
                MesInfo.WorkLineId + "\",\"describe\":\"" + jsonValue + "\"\\}";
            var data = Process(PtocessType.POST, UrlCombine(_mesSettings.PostSetSampleResult), strValue);

            if (data != null && data.Code == 200)
            {
                return true;
            }

            //PromptCommand(data);
            return false;
        }
    }
}
