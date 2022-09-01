using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {     
        //客户端用来接收数据的socket
        private readonly Socket _listenSocket;

        private EndPoint _localPort = new IPEndPoint(IPAddress.Parse("192.168.2.34"), 7942);
        private readonly EndPoint _serverPort = new IPEndPoint(IPAddress.Parse("192.168.2.34"), 7942);

        //保存聊天信息
        private readonly byte[] _buffer = new byte[1024];

        //保存服务器地址
        private EndPoint _serverIpPort;

        //收到的数据（字符串）
        private string _receiveData = string.Empty;

        //定义委托
        private delegate void ShowDataDelegate();

        public Client()
        {
            InitializeComponent();

            //获取服务端聊天信息
            _listenSocket = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.Udp);
            _listenSocket.Bind(_localPort);
            _listenSocket.BeginReceiveFrom(_buffer, 0, 1024, SocketFlags.None, ref _localPort, new AsyncCallback(ReceiveData), _listenSocket);
        }

        private void ShowData()
        {
            if (!string.IsNullOrEmpty(_receiveData))
            {
                this.richTextBox.Text = $"接收到服务端（{_serverIpPort}）的信息:\n{_receiveData}";
            }
        }

        private void ReceiveData(IAsyncResult ar)
        {
            // 创建ip+port
            var sender = new IPEndPoint(IPAddress.Any, 0);
            var tempRemoteEp = (EndPoint)sender;

            //获取socket
            Socket remote = (Socket)ar.AsyncState;

            //获取服务端发来的数据（服务端ip+port在第二个参数中）
            var recv = remote.EndReceiveFrom(ar, ref tempRemoteEp);

            //服务端ip+端口
            _serverIpPort = tempRemoteEp;

            //将数据流转成字符串
            _receiveData = Encoding.Unicode.GetString(_buffer, 0, recv);

            //刷新界面数据
            this.richTextBox.Invoke(new ShowDataDelegate(ShowData));
            
            if (!this.IsDisposed)
            {
                _listenSocket.BeginReceiveFrom(_buffer, 0, 1024, SocketFlags.None, ref _localPort, new AsyncCallback(ReceiveData), _listenSocket);
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            SendDataToServer();
        }

        private void SendDataToServer()
        {
            var dataArray = new byte[1024];

            //创建udp socket
            Socket udpClientSocketHeartbeat = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //字符串转成byte[] 准备发送
            dataArray = Encoding.Unicode.GetBytes(this.textBox_sendInfo.Text);

            //发送至服务端
            udpClientSocketHeartbeat.SendTo(dataArray, 0, dataArray.Length, SocketFlags.None, _serverPort);
        }
    }
}
