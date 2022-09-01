using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ControlApp
{
    public partial class ControlFrom : Form
    {
        public const int WM_COPYDATA = 0x004A;

        [DllImport("user32.dll")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int WM_COPYDATA, int i,ref COPYDATASTRUCT lParam);
        /// <summary>
        /// 常规指令
        /// </summary>
        DataInstructionSpec ins;
        /// <summary>
        /// 需存储的分段加压指令
        /// </summary>
        DataInstructionSpec ins2;//保存分段加压指令

        private int hWnd;

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }
  
        private COPYDATASTRUCT cds=new COPYDATASTRUCT();

        public ControlFrom()
        {
            InitializeComponent();
        }

        private void ControlFrom_Load(object sender, EventArgs e)
        {
            List<int> comput = new List<int> { 0, 1, 2, 3 };
            List<int> run = new List<int> { 1, 2, 3, 4 };
            comboBox2.DataSource = comput;
            comboBox3.DataSource = run;
        }
        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="cds"></param>
        private void sendMessage(COPYDATASTRUCT cds)
        {
            //发送指令
            byte[] arry = getArry();
            IntPtr hg = Marshal.AllocHGlobal(arry.Length);
            Marshal.Copy(arry, 0, hg, arry.Length);
            cds.cbData = arry.Length;
            cds.lpData = hg;
            cds.dwData = (IntPtr)hWnd;
            SendMessage((IntPtr)hWnd, WM_COPYDATA, 0, /*(this.LPARAM) &*/ ref cds);

            XianShi(arry,false);
        }
        /// <summary>
        /// 将字节数据转换成字符串
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="SF"></param>
        public void XianShi(byte[] arry,bool SF)
        {
            //显示接受指令
            if (SF)
            {
                string str = "收到返回指令：";
                foreach (var a in arry)
                    str += a.ToString("X2");
                if (Check(arry))
                    str += " (校验正确)";
                else str += " (校验错误)";
                JiLu(str);
                return;
            }
            //显示发送指令
            switch (ins.Function)
            {
                case 0x01:
                    {
                        string str = "";
                        if (btStartStop.Text == "启动测试")
                            str += "发送结束测试指令：";
                        else str += "发送启动测试指令：";
                        foreach (var a in arry)
                            str += a.ToString("X2");
                        JiLu(str);
                    }; break;
                case 0x02:
                    {
                        string str = "发送分段加压指令：";
                        foreach (var a in arry)
                            str += a.ToString("X2");
                        JiLu(str);
                    }; break;
                case 0x03:
                    {
                        string str = "发送检测结果指令：";
                        foreach (var a in arry)
                            str += a.ToString("X2");
                        JiLu(str);
                    }; break;
                default: break;
            }
        }
        /// <summary>
        /// 显示收发记录
        /// </summary>
        /// <param name="str"></param>
        public void JiLu(string str)
        {
            this.listView1.View = View.List;
            this.listView1.BeginUpdate();
            ListViewItem lvi = new ListViewItem();
            lvi.Text = str;                
            this.listView1.Items.Add(lvi);
            this.listView1.EndUpdate();
        }
        /// <summary>
        /// 指令数据字节化
        /// </summary>
        /// <returns></returns>
        private byte[] getArry()
        {
            byte str ;
            List<byte> bt = new List<byte>();

            if (ins.Function == 2)
            {
                ins = ins2;
                ins.GetCheck();
            }

            switch (ins.Function)
            {
                case 0x01:
                    {
                        str = (byte)((ins.Head & 0xFF00) >> 8);
                        bt.Add(str);
                        str = (byte)(ins.Head & 0xFF);
                        bt.Add(str);
                        str = ins.Function;
                        bt.Add(str);
                        str = ins.Data1;
                        bt.Add(str);
                        str = ins.Check;
                        bt.Add(str);
                        str = (byte)((ins.End & 0xFF00) >> 8);
                        bt.Add(str);
                        str = (byte)(ins.End & 0xFF);
                        bt.Add(str);
                    }; break;
                case 0x02:
                    {
                        str = (byte)((ins.Head & 0xFF00) >> 8);
                        bt.Add(str);
                        str = (byte)(ins.Head & 0xFF);
                        bt.Add(str);
                        str = ins.Function;
                        bt.Add(str);
                        str = ins.Data1;
                        bt.Add(str);
                        foreach (var h in ins.Data)
                            foreach (var l in h)
                            {
                                str = (byte)(l & 0x00FF >> 8);
                                bt.Add(str);
                                str = (byte)(l & 0xFF );
                                bt.Add(str);
                            }
                        str = ins.Check;
                        bt.Add(str);
                        str = (byte)((ins.End & 0xFF00) >> 8);
                        bt.Add(str);
                        str = (byte)(ins.End & 0xFF);
                        bt.Add(str);
                    }; break;
                case 0x03:
                    {
                        str = (byte)((ins.Head & 0xFF00) >> 8);
                        bt.Add(str);
                        str = (byte)(ins.Head & 0xFF);
                        bt.Add(str);
                        str = ins.Function;
                        bt.Add(str);
                        str = ins.Data1;
                        bt.Add(str);
                        str = ins.Data2;
                        bt.Add(str);
                        str = ins.Check;
                        bt.Add(str);
                        str = (byte)((ins.End & 0xFF00) >> 8);
                        bt.Add(str);
                        str = (byte)(ins.End & 0xFF);
                        bt.Add(str);
                    }; break;
                default:break;
            }

            byte[] b = new byte[bt.Count];
            for (int i=0;i<bt.Count;i++)
            {
                b[i] = bt[i];
            }
            return b;
            //string s = "";
            //foreach (var bb in b)
            //    s += bb.ToString("X2");
            //return s;
        }
        /// <summary>
        /// 校验指令帧
        /// </summary>
        /// <param name="bt"></param>
        /// <returns></returns>
        public bool Check(byte[] bt)
        {
            bool check = false;
            ushort cs = 0;
            foreach (var b in bt)
            {
                if (b == bt[bt.Length - 3])
                    break;
                cs += b;
            }
            if (cs > 0x00FF)
            {
                cs = (ushort)(cs & 0xFFFF);
                //cs += 1;
            }
            cs = (byte)(cs & 0x00FF);
            if (cs == bt[bt.Length - 3])
                check = true;
            return check;
        }
        /// <summary>
        /// 接收返回数据
        /// </summary>
        /// <param name="m"></param>
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                    Type mytype = mystr.GetType();
                    mystr = (COPYDATASTRUCT)m.GetLParam(new COPYDATASTRUCT().GetType());
                    byte[] bytearray = new byte[mystr.cbData];
                    Marshal.Copy(mystr.lpData, bytearray, 0, bytearray.Length);
                    XianShi(bytearray,true);
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }


        /// <summary>
        /// 分段加压
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPressurize_Click(object sender, EventArgs e)
        {
            hWnd = FindWindow(null, @"PDSmart-6405");
            if (ins == null) ins=new DataInstructionSpec(2);
            if (ins2 == null) return;
            ins.Function = 0x02;

            sendMessage(cds);
        }
        /// <summary>
        /// 检测结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btReadResult_Click(object sender, EventArgs e)
        {
            hWnd = FindWindow(null, @"PDSmart-6405");
            ins = new DataInstructionSpec(3);
            ins.DataLoad();
            ins.Data1 = (byte)(byte.Parse(comboBox2.SelectedValue.ToString()) & 0xFF);
            ins.Data2 = (byte)(byte.Parse(comboBox3.SelectedValue.ToString()) & 0xFF);
            ins.GetCheck();
            sendMessage(cds);

        }
        /// <summary>
        /// 启动或结束测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btStartStop_Click(object sender, EventArgs e)
        {
            hWnd = FindWindow(null, @"PDSmart-6405");
            ins = new DataInstructionSpec(1);
            ins.DataLoad();

            if (btStartStop.Text == "启动测试")
            {
                btStartStop.Text = "结束测试";
                ins.Data1 = 0x00;
            }
            else 
            {
                btStartStop.Text = "启动测试";
                ins.Data1 = 0x01;
            }
            ins.GetCheck();
            sendMessage(cds);
        }

        private void tbSum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Int64.Parse(tbSum.Text) > 0)
                {
                    if (UInt64.Parse(tbSum.Text) > 255)
                    {
                        MessageBox.Show("输入值超出存储范围（0--255），请重新输入");
                        tbSum.Text = "0";
                        //ins2 = null;
                        //tbSum.Text = "0";
                        comboBox1.DataSource = null;
                        comboBox1.Update();
                        //MessageBox.Show("分段总数超出限制范围 （20段），请重新设置！");
                        return;
                    }
                    else
                    {
                        List<string> str = new List<string>();
                        for (int i = 0; i < byte.Parse(tbSum.Text); i++)
                        {
                            str.Add($"第{i + 1}段");
                        }
                        comboBox1.DataSource = str;
                    }
                }
                else
                {
                    if (Int64.Parse(tbSum.Text) == 0)
                        return;
                    tbSum.Text = "0";
                    MessageBox.Show("分段总数不能为负数，请重新设置！");
                    comboBox1.DataSource = null;
                    return;
                }
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 保存分段加压数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (ins2 == null)
            {
                ins2 = new DataInstructionSpec(2);
                ins2.Data1 = new byte();
                ins2.Data1 = (byte)(byte.Parse(tbSum.Text) & 0xFF);
                ins2.DataLoad();
            }
            if (Int64.Parse(textBox1.Text) < UInt16.MinValue || Int64.Parse(textBox2.Text) < UInt16.MinValue
                || UInt64.Parse(textBox1.Text) > UInt16.MaxValue || UInt64.Parse(textBox2.Text) > UInt16.MaxValue)
            {
                MessageBox.Show("输入数值超出存储范围（0--65535）,请重新输入！");
                textBox1.Text = "0";
                textBox2.Text = "0";
                return;
            }
            ins2.Data[comboBox1.SelectedIndex][0] = (ushort)(UInt16.Parse(textBox1.Text) & 0xFFFF);
            ins2.Data[comboBox1.SelectedIndex][1] = (ushort)(UInt16.Parse(textBox2.Text) & 0xFFFF);

        }
        /// <summary>
        /// 清空历史记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.Details;
            listView1.Items.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ins2 == null)
                return;
            else 
            if (ins2.Data.Count > 0)
            {
                textBox1.Text = ins2.Data[comboBox1.SelectedIndex][0].ToString();
                textBox2.Text = ins2.Data[comboBox1.SelectedIndex][1].ToString();
            }
            else return;
        }
    }
}
