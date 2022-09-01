using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        private readonly Socket _listenSocket;
        private Socket _socket;

        //定个委托
        public delegate void ShowDataDelegate(string data);

        public Server()
        {
            InitializeComponent();

            //创建接收客户端消息的socket
            _listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _listenSocket.Bind(new IPEndPoint(IPAddress.Any, 7942));//本机用Bind,远程用Connect
            _listenSocket.Listen(10);


            Task.Run(() =>
            {
                //_socket = _listenSocket.Accept();
                byte[] receive = new byte[1024];
                while (true)
                {
                    _socket = _listenSocket.Accept();
                    _socket.Receive(receive);
                    var data = Encoding.Unicode.GetString(receive);
                    this.richTextBox.Invoke(new ShowDataDelegate(ShowData), data);
                }
            });
        }

        private void ShowData(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                this.richTextBox.Text = $"接收到客户端（{_socket?.RemoteEndPoint}）的信息:\n{data}";
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            SendDataToClient();
        }

        private void SendDataToClient()
        {
            var data = new byte[1024];

            //字符串转byte[] 准备发送
            data = Encoding.Unicode.GetBytes(this.textBox_sendInfo.Text);

            //发送
            _socket?.SendTo(data, 0, data.Length, SocketFlags.None, _socket?.RemoteEndPoint);
        }
    }
}
