using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplerControlSystem.Condition
{
    public class UpgradeFirmwareParameters
    {
        /// <summary>
        /// 块索引
        /// </summary>
        public ushort Index { get; set; }

        /// <summary>
        /// 块大小(默认512)
        /// </summary>
        public ushort Size { get; set; }

        /// <summary>
        /// 块内容
        /// </summary>
        public byte[] Datas { get; set; }
    }
}
