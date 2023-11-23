using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplerSystem.UI.Condition.Mes
{
    [Serializable]
    public class WOResponse
    {
        //        "{
        //  ""createTime"": ""2023-11-10 10:19:48"",
        //  ""updateTime"": ""2023-11-10 11:56:02"",
        //  ""orderId"": ""ef4bb941bb9f422495c0c2f411dbe809"",
        //  ""orderCode"": ""TEST-313010031-6"",
        //  ""orderDescription"": """",
        //  ""orderNum"": 50000,
        //  ""orderType"": ""2"",
        //  ""craftLineVersionId"": ""bbf985916fec47f69b11237f6c9ca781"",
        //  ""materielId"": ""313010031"",
        //  ""materielName"": ""电化学CO传感器,(HX)"",
        //  ""materielCode"": ""313010031"",
        //  ""materielDescription"": """",
        //  ""manufacturerModel"": ""dhxCOcgq"",
        //  ""materielTypeId"": ""31301"",
        //  ""materielTypeName"": ""传感器"",
        //  ""planStartTime"": ""2023-11-10 10:19:31"",
        //  ""planEndTime"": ""2023-12-30 10:19:35"",
        //  ""orderStatus"": 10,
        //  ""isSnPool"": true,
        //  ""snPoolId"": 483,
        //  ""snPoolName"": ""313010031-测试6"",
        //  ""isMacPool"": false,
        //  ""orderStatusName"": ""生产中"",
        //  ""productName"": ""电化学CO传感器"",
        //  ""productId"": 3001,
        //  ""craftLineVersion"": ""V0001"",
        //  ""lineName"": ""电化学CO传感器,(HX)"",
        //  ""bomId"": ""313010031->0"",
        //  ""startTime"": ""2023-11-10 11:56:02"",
        //  ""companyId"": ""0032b7fed9734379b48be671082b159a""
        //}"

        [JsonProperty(PropertyName = "orderCode")]
        public string WO { get; set; }

        [JsonProperty(PropertyName = "materielId")]
        public string MN { get; set; }

        [JsonProperty(PropertyName = "materielName")]
        public string MNName { get; set; }

        [JsonProperty(PropertyName = "materielTypeName")]
        public string MNType {  get; set; }

        [JsonProperty(PropertyName = "orderStatusName")]
        public string WOStatus {  get; set; }

        /// <summary>
        /// 工艺ID
        /// </summary>
        [JsonProperty(PropertyName = "craftLineVersionId")]
        public string CraftID { get; set; } //


        public WOResponse() { }

    }
}
