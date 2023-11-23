using System;
using System.Collections.Generic;

namespace SamplerControlSystem.Server
{
    public static class CommandHelper
    {
        public static byte SN { get; set; } = 1;

        /// <summary>
        /// 获取完整指令内容,给报文体添加报文头和校验码
        /// </summary>
        /// <param name="badyData"></param>
        /// <returns></returns>
        public static byte[] GetCompleteCommand(List<byte> badyData)
        {
            var ret = new List<byte>();
            var strTemp="AA55";
            strTemp += badyData.Count.ToString("X2");
            strTemp += "1001";
            strTemp += SN++.ToString("X2");
            strTemp += "02";
            
            ret.AddRange(HexStrToByteArray(strTemp));
            ret.AddRange(badyData);

            if (CalculateCheckSum(ret, false) is byte checkSum)
                ret.Add(checkSum);

            return ret.ToArray();
        }

        public static List<byte> HexStrToByteArray(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                return null;

            hex = hex.Replace("0x", "").Replace(" ","");
            var ret = new List<byte>();
            var temp = string.Empty;
            if (hex.Length % 2 != 0)
            {
                temp = hex[hex.Length - 1].ToString();
                hex = hex.Remove(hex.Length - 1);
            }
            for (var i = 0; i < hex.Length; i += 2)
            {
                ret.Add(Convert.ToByte(hex[i].ToString() + hex[i + 1].ToString(), 16));
            }
            if (!string.IsNullOrEmpty(temp))
                ret.Add(Convert.ToByte(temp, 16));
            return ret;
        }

        /// <summary>
        /// 除起始符和校验位,所有内容异或
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="type">true为接收,false为发送</param>
        /// <returns></returns>
        public static byte? CalculateCheckSum(List<byte> datas, bool type)
        {
            if (datas == null || datas.Count <= 2) return null;

            var ret = datas[2];
            var count = datas.Count;
            count -= (type ? 4 : 3);

            //ret本身为2,所以数据异或从3始
            for (var i = 0; i < count; i++)
            {
                ret ^= datas[i + 3];
            }

            return ret;
        }


        public static string GetHexStrByBytes(List<byte> datas)
        {
            if (datas == null) return string.Empty;

            var ret = string.Empty;
            foreach (var data in datas)
            {
                ret += data.ToString("X2")+" ";
            }
            return ret;
        }
    }
}
