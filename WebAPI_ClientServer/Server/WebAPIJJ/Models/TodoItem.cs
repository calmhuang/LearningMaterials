using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebAPIJJ.Models
{
    public class Data
    {
        public Data()
        { }

        [Key]
        public string Lot { get; set; }

        public string Value { get; set; }
    }

    public class LotItem
    {
        public LotItem()
        { }

        //[JsonIgnore]
        //[Key, Column(Order = 1)]
        //public int Id { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 客户品名
        /// </summary>
        public string CustomerProductCode { get; set; }

        /// <summary>
        /// 印章号
        /// </summary>
        public string MarketCode { get; set; }

        [Key, Column(Order = 1)]
        /// <summary>
        /// 批次号
        /// </summary>
        public string Lot { get; set; }

        /// <summary>
        /// 批次数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 当前工序
        /// </summary>
        public string CurrentSpecName { get; set; }

        /// <summary>
        /// WIP状态
        /// </summary>
        public string WIPStatus { get; set; }

        /// <summary>
        /// 程序存放路径
        /// </summary>
        public string TestMachinePath { get; set; }

        /// <summary>
        /// 程序名
        /// </summary>
        public string RecipeName { get; set; }

        public string LevelInfo { get; set; }

        public virtual List<TestProgram> TestPrograms { get; set; }
        /// <summary>
        /// 客户号
        /// </summary>
        public string Customer { get; set; }

        public int ControlPassRate { get; set; }

        public int DownPassRate { get; set; }

        public string? DiffutionLot { get; set; }

        public string? DieName { get; set; }

        public string? PackageCode { get; set; }

        /// <summary>
        /// 内部品名
        /// </summary>
        public string? TestName { get; set; }

        public string? PrintCode { get; set; }

        public List<TestBin> TestBins { get; set; }

        public string ptdatecode;

        /// <summary>
        /// 工单号
        /// </summary>
        public string? OrderName { get; set; }


       //[NotMapped]
        /// <summary>
        /// 提篮列表
        /// </summary>
        public List<string> Carriers { get; set; }

        /// <summary>
        /// 打印印章起始号
        /// </summary>
        public string StartNo { get; set; }

        /// <summary>
        /// 载具绑定信息
        /// </summary>
        public virtual List<BindDetail> CarrierDetails { get; set; }

    }

    public class TestProgram
    {
        public TestProgram()
        { }
        public string? Name { get; set; }
        public string? RecipeName { get; set; }
    }

    public class BindDetail
    {
        public BindDetail()
        { }
        /// <summary>
        /// 基板ID或DBC ID
        /// </summary>
        public string? BaseBoard { get; set; }
        /// <summary>
        /// 托盘ID
        /// </summary>
        public string? Tray { get; set; }
        /// <summary>
        /// 提篮ID
        /// </summary>
        public string? Basket { get; set; }
    }

    public class TestBin
    {
        public TestBin()
        { }
        public string? BinName { get; set; }

        public string? BinCategory { get; set; }

        public string? BinComment { get; set; }

        public string? BinProduct { get; set; }

        public string? BinProductVersion { get; set; }

        public int BinQty { get; set; }

        public string? BinLimit { get; set; }
    }

    public class Carrier
    { 
    
    }

    public class ResponseBody
    {
        public ResponseBody()
        { }

        /// <summary>
        /// 1:成功  0:失败
        /// </summary>
        public int Code { get; set; } = 0;

        /// <summary>
        /// 响应体返回结果信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 其他数据为null
        /// </summary>
        public object? Data { get; set; }
    }


}
