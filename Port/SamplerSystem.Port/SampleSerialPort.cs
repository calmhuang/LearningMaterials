using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace SamplerSystem.Port
{
    public class SampleSerialPort
    {
        private const int MAX_READ_LENGTH = 10240;

        private AutoResetEvent ResetEvent { get; set; }

        public event Action<string> ChangePortMessager;
        public event Action<string> OnReceiveSendDisplay;
        public event Action<List<byte>> OnParseReceiveData;
        public event Action OnUpdateDisplay;

        /// <summary>
        /// 分包发送时使用,分包间隔时间(超时判断)
        /// </summary>
        public int SubcontractingTimeoutValue { get; set; } = 5;

        private SerialPort _sPort;
        public SerialPort SerialPort
        {
            get => _sPort;
            set
            {
                _sPort = value;
                _sPort.DataReceived += OnReceive;
            }
        }

        private bool _IsClose = false;

        public SampleSerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            ChangeSerialPort(portName, baudRate, parity, dataBits, stopBits);
            ResetEvent = new AutoResetEvent(false);
        }

        public void ChangeSerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            ClosePort();
            SerialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            SerialPort.ReadTimeout = 36000;

        }


        private void OnReceive(object sender, SerialDataReceivedEventArgs e)
        {
            ResetEvent.Set();
        }

        public void ReadTask()
        {
            ResetEvent.Reset();
            while (true)
            {
                ResetEvent.WaitOne();
                if (_IsClose)
                    break;
                List<byte> allData = new List<byte>();
                while (true)
                {
                    if (SerialPort == null || !SerialPort.IsOpen)
                        break;
                    try
                    {
                        int len = SerialPort.BytesToRead;
                        if (len == 0)
                            break;
                        byte[] buffer = new byte[len];
                        SerialPort.Read(buffer, 0, len);
                        if (buffer.Length == 0)
                            break;
                        allData.AddRange(buffer);
                    }
                    catch
                    {
                        break;
                    }

                    if (allData.Count > MAX_READ_LENGTH)
                        break;

                    Thread.Sleep(SubcontractingTimeoutValue); // 不能设置过小，也不能过大，否则一次读取的数据不完整

                }
                if (allData.Count > 0)
                {
                    //TODO:解析收到的字节数组Invoke处理
                    OnReceiveSendDisplay?.Invoke("(Receive)" + ToHexString(allData.ToArray()));
                    OnParseReceiveData?.Invoke(allData);
                    OnUpdateDisplay?.Invoke();
                }
            }
        }

        public void Close()
        {
            _IsClose = true;
            ResetEvent.Set();
        }

        public void Open()
        {
            _IsClose = false;
            new Thread(ReadTask).Start();
        }


        public void ClosePort()
        {
            SerialPort?.Close();
            ChangePortMessager?.Invoke(DisplayInfo());
        }
        public void OpenPort()
        {
            SerialPort?.Open();
            ChangePortMessager?.Invoke(DisplayInfo());
        }

        public void Flush()
        {
            SerialPort?.DiscardInBuffer();
            SerialPort?.DiscardOutBuffer();
        }
        public void Write(byte[] buffer, int offset, int count)
        {
            if (SerialPort.IsOpen)
            {
                SerialPort.Write(buffer, offset, count);
            }
            else
            {
                //TODO 未开启操作
                OnReceiveSendDisplay?.Invoke("串口未打开!");
            }
        }

        public void Write(byte[] buffer)
        {
            //var buff = Encoding.Default.GetBytes(text ?? "{OK}");
            OnReceiveSendDisplay?.Invoke("(Send)" + ToHexString(buffer));
            Write(buffer, 0, buffer.Length);
        }

        private string ToHexString(byte[] bytes)
        {
            var str = string.Empty;
            foreach (var data in bytes)
            {
                str += data.ToString("X2") + " ";
            }
            return str;
        }

        public string DisplayInfo()
        {
            return $"串口:{SerialPort.PortName}{(SerialPort.IsOpen ? "开" : "关")} " +
                   $"{"波特率"}:{SerialPort.BaudRate} " +
                   $"{"停止位"}:{SerialPort.StopBits} " +
                   $"{"奇偶位"}:{SerialPort.Parity} " +
                   $"{"数据位"}:{SerialPort.DataBits} ";
        }

    }
}
