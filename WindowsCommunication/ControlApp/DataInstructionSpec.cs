using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApp
{
    class DataInstructionSpec
    {
        /// <summary>
        /// 帧头
        /// </summary>
        public ushort Head = 0xA55A;
        /// <summary>
        /// 功能码（识别指令码）
        /// </summary>
        public byte Function;

        public byte Data1;
        public byte Data2;

        public List<List<ushort>> Data = new List<List<ushort>>();
        /// <summary>
        /// 校验码
        /// </summary>
        public byte Check;
        /// <summary>
        /// 帧尾
        /// </summary>
        public ushort End = 0x0D0A;

        public DataInstructionSpec(byte fun)
        {
            Function = (byte)(fun & 0xFF);
        }
        /// <summary>
        /// 初始化指令数据部分
        /// </summary>
        public void DataLoad()
        {
            switch (Function)
            {
                case 0x01: Data1 = new byte(); break;
                case 0x02:
                    {
                        for (int i = 0; i < Data1; i++)
                        {
                            Data.Add(new List<ushort>());
                            Data[i].Add(new ushort());
                            Data[i].Add( new ushort());
                        }
                    }; break;
                case 0x03:
                    {
                        Data1 = new byte();
                        Data2 = new byte();
                    }; break;
                default: break;
            }
        }
        /// <summary>
        /// 生成校验和
        /// </summary>
        public void GetCheck()
        {
            UInt16 ck = 0;
            switch (Function)
            {
                case 0x01:
                    {
                        ck += (byte)(Head >> 8);
                        ck += (byte)(Head & 0x00FF);
                        ck += Function;
                        ck += Data1;
                        if (ck > 0xFF)
                        {
                            ck = (byte)(ck & 0x00FF);
                            //ck += 1;
                        }
                        Check = (byte)(ck & 0xff);
                    }
                    break;
                case 0x02:
                    {
                        ck += (byte)(Head >> 8);
                        ck += (byte)(Head & 0x00FF);
                        ck += Function;
                        ck += Data1;
                        foreach (var dat in Data)
                            foreach (var da in dat)
                            {
                                ck += (byte)(da >> 8);
                                ck += (byte)(da & 0x00FF);
                            }
                        if (ck > 0xFF)
                        {
                            ck = (byte)(ck & 0xFF);
                        }
                        Check = (byte)(ck & 0xff);
                    }; break;
                case 0x03:
                    {
                        ck += (byte)(Head >> 8);
                        ck += (byte)(Head & 0x00FF);
                        ck += Function;
                        ck += Data1;
                        ck += Data2;
                        if (ck > 0xFF)
                        {
                            ck = (byte)(ck & 0xFF);
                        }
                        Check = (byte)(ck & 0xff);
                    }; break;
                default: break;
            }
        }
    }
}
           