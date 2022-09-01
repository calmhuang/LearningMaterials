using Newtonsoft.Json;
using Piccolo.Condition.WebCondition;
using Piccolo.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piccolo.UI.JiJiaMES
{
    public class WebAPI
    {
        public bool IsOnline { get; set; } = false;
        private readonly APIUrls _urls;

        private WebAPI(APIUrls urls)
        {
            _urls = urls;
        }

        private string POST(string url, string data)
        {
            return APICommand.Post(url, data);
        }

        private string GET(string url)
        {
            return APICommand.Get(url);
        }
        
        /// <summary>
        /// 获取接口完整Url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string UrlCombine(string url, string value = "")
        {
            return _urls.Url + url + value;
        }

        /// <summary>
        /// Get过程
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private ResponseBody GETProcess(string url)
        {
            var ret = Deserialize(GET(url));

            PromptCommand(ret);

            return ret;
        }

        /// <summary>
        /// POST过程
        /// </summary>
        /// <param name="url"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private ResponseBody POSTProcess(string url, string value)
        {
            var ret = Deserialize(POST(url, value));

            PromptCommand(ret);

            return ret;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private ResponseBody Deserialize(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            return JsonConvert.DeserializeObject<ResponseBody>(value);
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="value"></param>
        private void PromptCommand(ResponseBody value)
        {
            if (value == null)
            {
                new FormDialog("响应体为空（Null），请检查后重试！", "错误").ShowDialog();
                return;
            }

            var title = value.Code == 1 ? "成功" : value.Code == 0 ? "失败" : "未知";
            new FormDialog($"{value.Message}", $"{title}").ShowDialog();
        }

        #region POST
        /// <summary>
        ///  返回值ResponseBody.Data为null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ResponseBody Alarm(Alarm value)
        {
            var strValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            return POSTProcess(UrlCombine(_urls.AlarmUrl), strValue);
        }

        /// <summary>
        /// 返回值ResponseBody.Data为null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ResponseBody Equipment(EquipmentType value)
        {
            var strValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            return POSTProcess(UrlCombine(_urls.EquipmentUrl), strValue);
        }
        #region 不需要使用的POST接口
        ///// <summary>
        ///// 返回值ResponseBody.Data为null
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public ResponseBody BaseBoard(BaseBoard value)
        //{
        //    var strValue = JsonConvert.SerializeObject(value, Formatting.Indented);

        //    return POSTProcess(UrlCombine(_urls.BaseBoardUrl), strValue);
        //}

        ///// <summary>
        ///// 返回值ResponseBody.Data为null
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public ResponseBody DBC2BaseBoard(DBC2BaseBoard value)
        //{
        //    var strValue = JsonConvert.SerializeObject(value, Formatting.Indented);

        //    return POSTProcess(UrlCombine(_urls.DBC2BaseBoardUrl), strValue);
        //}

        ///// <summary>
        ///// 返回值ResponseBody.Data为null
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public ResponseBody Carrier(Carrier value)
        //{
        //    var strValue = JsonConvert.SerializeObject(value, Formatting.Indented);

        //    return POSTProcess(UrlCombine(_urls.CarrierUrl), strValue);
        //}

        ///// <summary>
        ///// 返回值ResponseBody.Data为null
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public ResponseBody EquipmentData(List<EquipmentData> value)
        //{
        //    var strValue = JsonConvert.SerializeObject(value, Formatting.Indented);

        //    return POSTProcess(UrlCombine(_urls.EquipmentDataUrl, strValue), strValue);
        //}
        #endregion

        /// <summary>
        /// 返回值ResponseBody.Data为null
        /// </summary>
        /// <param name="lot"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ResponseBody TrackIn(string lot, TrackInData value)
        {
            var strValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            return POSTProcess(UrlCombine(_urls.TrackInUrl, lot), strValue);
        }

        /// <summary>
        /// 返回值ResponseBody.Data为null
        /// </summary>
        /// <param name="lot"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ResponseBody CancelTrackIn(string lot, TrackInData value)
        {
            var strValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            return POSTProcess(UrlCombine(_urls.CancelTrackInUrl, lot), strValue);
        }

        /// <summary>
        /// 返回值ResponseBody.Data为null
        /// </summary>
        /// <param name="lot"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ResponseBody TrackOut(string lot, TrackOutData value)
        {
            var strValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            return POSTProcess(UrlCombine(_urls.TrackOutUrl, lot), strValue);
        }

        /// <summary>
        /// 返回值ResponseBody.Data为null
        /// </summary>
        /// <param name="lot"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ResponseBody Hold(string lot, TrackOutData value)
        {
            var strValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            return POSTProcess(UrlCombine(_urls.HoldUrl, lot), strValue);
        }

        #endregion

        #region GET
        /// <summary>
        /// 返回值ResponseBody.Data为GetLotByLotNo类型
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        public ResponseBody Lot(string lot)
        {
            var ret = GETProcess(UrlCombine(_urls.LotUrl, lot));
            ret.Data = JsonConvert.DeserializeObject<GetLotByLotNo>(ret.Data.ToString());

            return ret;
        }

        #region 不需要使用的GET接口
        ///// <summary>
        ///// 返回值ResponseBody.Data为String类型（RecipeName）
        ///// </summary>
        ///// <param name="lot"></param>
        ///// <returns></returns>
        //public ResponseBody GetRecipeByLot(string lot)
        //{
        //    return GETProcess(UrlCombine(_urls.GetRecipeByLotUrl, lot));
        //}

        ///// <summary>
        ///// 返回值ResponseBody.Data为Int类型
        ///// </summary>
        ///// <param name="lot"></param>
        ///// <returns></returns>
        //public ResponseBody GetMaxTrackOutQty(string lot)
        //{
        //    return GETProcess(UrlCombine(_urls.GetMaxTrackOutQtyUrl, lot));
        //}

        ///// <summary>
        ///// 返回值ResponseBody.Data为GetLotById类型
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public ResponseBody GetCarrierById(string id)
        //{
        //    var ret = GETProcess(UrlCombine(_urls.GetCarrierByIdUrl, id));
        //    ret.Data = JsonConvert.DeserializeObject<GetLotByLotNo>(ret.Data.ToString());

        //    return ret;
        //}
        #endregion

        #endregion

        public static WebAPI Load(string urlsPath)
        {
            var urls = APIUrls.Load(urlsPath);
            if (urls == null)
            {
                urls = new APIUrls();
                urls.Save(urlsPath);
            }

            return new WebAPI(urls);
        }
    }
}
