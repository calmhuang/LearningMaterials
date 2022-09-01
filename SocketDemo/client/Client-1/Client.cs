using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        //客户端用来接收数据的socket
        private readonly Socket _listenSocket;

        private EndPoint _serverPort = new IPEndPoint(IPAddress.Parse("192.168.2.34"), 7942);

        //定义委托
        private delegate void ShowDataDelegate(string data);

        public Client()
        {
            InitializeComponent();

            TryParsePointFs("(0.3107|0.3335);(0.319|0.3283);(0.312|0.3145);(0.3035|0.3195)", out var ps);
            ps = new PointF[5];

            _listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                _listenSocket.Connect(_serverPort);
            }
            catch
            { 
            }

            Task.Run(() =>
            {
                byte[] receive = new byte[1024];
                while (true)
                {
                    Array.Clear(receive, 0, 1024);
                    _listenSocket.Receive(receive);
                    var data = Encoding.Unicode.GetString(receive);
                    new ShowDataDelegate(ShowData).Invoke(data);
                    this.richTextBox.Invoke(new ShowDataDelegate(ShowData), data);
                }
            });
        }
        private bool TryParsePointFs(string points, out PointF[] ps)
        {
            ps = null;
            if (string.IsNullOrWhiteSpace(points)) return false;

            var dataList = points.Split(';');
            ps = new PointF[4];
            for (var i = 0; i < dataList.Length; i++)
            {
                if (string.IsNullOrEmpty(dataList[i])) continue;

                var values = dataList[i].Split('|');
                if (values.Length < 2) return false;

                var x = values[0].Replace("(", string.Empty);
                var y = values[1].Replace(")", string.Empty);

                if (!float.TryParse(y, out var py)) return false;
                ps[i].Y = py;
                if (!float.TryParse(x, out var px)) return false;
                ps[i].X = px;
            }

            return true;
        }

        private void ShowData(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                this.richTextBox.Text = $"接收到服务端（{_listenSocket.RemoteEndPoint}）的信息:\n{data}";
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            SendDataToServer();
        }

        private void SendDataToServer()
        {
            var dataArray = new byte[1024];

            //字符串转成byte[] 准备发送
            dataArray = Encoding.Unicode.GetBytes(this.textBox_sendInfo.Text);

            //发送至服务端
            _listenSocket.SendTo(dataArray, 0, dataArray.Length, SocketFlags.None, _listenSocket.RemoteEndPoint);
        }
    }
}
