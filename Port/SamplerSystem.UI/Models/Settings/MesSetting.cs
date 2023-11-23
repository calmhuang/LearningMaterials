using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplerSystem.UI.Models.Settings
{
    [Serializable]
    public class MesSetting
    {
        public List<string> Urls { get; set; } = new List<string>();


        public string Url { get; set; }


        public string PostToken { get; set; }

        /// <summary>
        /// 工单信息
        /// </summary>
        public string PostWODto { get; set; }

        /// <summary>
        /// 工艺信息
        /// </summary>
        public string PostVersionNode { get; set; }


        /// <summary>
        /// 厂商信息
        /// </summary>
        public string PostCompanyInfo { get; set; }

        /// <summary>
        /// 车间
        /// </summary>
        public string PostWorkShopList { get; set; }

        /// <summary>
        /// 流水线别
        /// </summary>
        public string PostWorkLineList { get; set; }

        /// <summary>
        /// 过站
        /// </summary>
        public string PostProductDevice { get; set; }

        /// <summary>
        /// 解绑托盘
        /// </summary>
        public string PostUnbindTray { get; set; }

        /// <summary>
        /// 由托盘ID获取SN
        /// </summary>
        public string PostGetSnByTray { get; set; }

        /// <summary>
        /// 传感器标定信息上传
        /// </summary>
        public string PostSetSampleResult { get; set; }

        public MesSetting()
        {
            Url = "http://192.168.1.9:9200";
            PostToken = "/api-auth/oauth/user/token";

            PostVersionNode = "/api-production/craftline/version/node/getListDto";
            PostWODto = "/api-production/order/get/list/dto";
            PostCompanyInfo = "/api-user/company/getList";
            PostWorkShopList = "/api-production/company/workshop/getList/page";
            PostWorkLineList = "/api-production/company/workline/getList/page";
            PostProductDevice = "/api-production/product/device/node/insert/sn";
            PostUnbindTray = "/api-production/order/drag/tray/un";
            PostGetSnByTray = "/api-production/order/drag/tray/get";

            PostSetSampleResult = "/api-production/log/insert";
        }

    }
}
