using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SamplerSystem.UI.Condition.Mes;
using SamplerSystem.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplerSystem.UI.MES
{
    [Serializable]
    public class CompanyInfo
    {   
        [JsonProperty(PropertyName = "companyId")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    [Serializable]
    public class WorkShopInfo
    {
        [JsonProperty(PropertyName = "workShopId")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "workShopName")]
        public string Name { get; set; }
    }

    [Serializable]
    public class WorkLineInfo
    {
        [JsonProperty(PropertyName = "lineId")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "lineName")]
        public string Name { get; set; }
    }

    [Serializable]
    public class CraftInfo
    {
        [JsonProperty(PropertyName = "craftLineVersionNodeId")]
        public string CraftLineVersionNodeId { get; set; }

        [JsonProperty(PropertyName = "procesId")]
        public string ProcesId { get; set; }

        [JsonProperty(PropertyName = "procesName")]
        public string ProcesName { get; set; }

        [JsonProperty(PropertyName = "processAnotherName")]
        public string ProcessAnotherName { get; set; }
    }

    [Serializable]
    public class MesInfo
    {
        /// <summary>
        /// 厂商
        /// </summary>
        //public string CompanyId => CompanyIndex >= CompanyInfos.Count ? null : CompanyInfos[CompanyIndex].ID;
        public string CompanyId { get; set; }
        public List<CompanyInfo> CompanyInfos { get; set; } = new List<CompanyInfo>();

        /// <summary>
        /// 车间
        /// </summary>
      //  public string WorkShopId => WorkShopIndex >= WorkShopInfos.Count ? null : WorkShopInfos[WorkShopIndex].ID;
        public string WorkShopId { get; set; }
        public List<WorkShopInfo> WorkShopInfos { get; set; } = new List<WorkShopInfo>();

        /// <summary>
        /// 流水线
        /// </summary>
     //   public string WorkShopId => WorkShopIndex >= WorkShopInfos.Count ? null : WorkShopInfos[WorkShopIndex].ID;
        public string WorkLineId { get; set; }
        public List<WorkLineInfo> WorkLineInfos { get; set; } = new List<WorkLineInfo>();

        /// <summary>
        /// 过站使用
        /// </summary>
        // public string CraftNodeId => CraftIndex >= CraftInfos.Count ? null : CraftInfos[CraftIndex].CraftLineVersionNodeId;
        [JsonIgnore] public string CraftNodeId { get; set; }
        [JsonIgnore] public List<CraftInfo> CraftInfos { get; set; } = new List<CraftInfo>();


        //public int CompanyIndex { get; set; } = 0;
        //public int WorkShopIndex { get; set; } = 0;
        //public int WorkLineIndex { get; set; } = 0;
        //public int CraftIndex { get; set; } = 0;

        /// <summary>
        /// 工单
        /// </summary>
        public string WO {  get; set; }

        //[JsonIgnore]
        public WOResponse WOResponse { get; set; }


        public string UserName { get; set; }

        public string CompanyName { get; set; }

        /// <summary>
        /// 托盘编号
        /// </summary>
        public string[] TrayIDs { get; set; }

        public MesInfo()
        {
        }



        public static MesInfo Load(string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception($"{"未找到配置文件"} {filePath}");
            return JsonConvert.DeserializeObject<MesInfo>(File.ReadAllText(filePath));

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
