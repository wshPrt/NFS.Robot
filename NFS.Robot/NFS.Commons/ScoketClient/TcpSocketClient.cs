using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NFS.Commons.ScoketClient
{
  public class TcpSocketClient
    {
        public int _connectState; //连接状态 1表示连上,0表示未连接
        private Thread beatThread; //心跳线程
        private Thread receiptThread; //接收线程
        private Thread sendThread;     //发送线程
        static Semaphore sema;
        private TcpClient tcpClient;
        private Socket _client = null;
        public string _ipString;
        public int _port;
        private readonly byte[] buffer = new byte[256];
        public IPAddress _ipAddress = null;
        public EndPoint _endPoint = null;

        private readonly object lockSendData = new object();
        private readonly Queue<CmdDataPacket> dataPackets = new Queue<CmdDataPacket>();
        public event EventHandler<CmdDataPacket> _Receipt;
        public Action<byte[]> OnReceiveBuffer;
        public static string ByteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2")+" ";
                }
            }
            return returnStr;
        }


        public TcpSocketClient()
        {
            _ipString = ConfigurationManager.AppSettings["ServerIP"];
            _port = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
            _ipAddress = IPAddress.Parse(_ipString);
            _endPoint = new IPEndPoint(_ipAddress, _port);
            IPEndPoint iPEndPoint = new IPEndPoint(_ipAddress, _port);
            tcpClient = new TcpClient();
            tcpClient.Connect(iPEndPoint);
            Task task = new Task(() => 
            {
                while (true)
                {
                    try
                    {
                        if (tcpClient.Connected == false)
                        {
                            Thread.Sleep(1000);continue;
                        }
                        byte[] buffer = new byte[2048 * 1024];
                        int lenght = tcpClient.Client.Receive(buffer);
                        byte[] receiveBuffer = buffer.Take(lenght).ToArray();
                        OnReceiveBuffer?.Invoke(receiveBuffer);
                        
                        //receiveBuffer获取数据
                       // Console.WriteLine(ByteToHexStr(receiveBuffer));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            });
            task.Start();
        }
        public void TcpSendCmd(CmdDataPacket dataPacket)
        {
            if (_client.Connected)
            {
                dataPackets.Enqueue(dataPacket);
                sema.Release();
            }
        }
        private void OnReceipt()
        {
            //连接
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine("+++++++++++++");
                _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                {
                    DontFragment = false,
                    ExclusiveAddressUse = true,
                    UseOnlyOverlappedIO = false,
                    SendBufferSize = 1024 * 1024 * 10,
                    ReceiveBufferSize = 1500
                    //ReceiveTimeout = 3000
                };
                while (true)
                {
                    try
                    {
                        Console.WriteLine("----开始连接...");
                        _client.Connect(_endPoint);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }

                _connectState = 1;//连接上
                Console.WriteLine(_client.NoDelay);
                Console.WriteLine("-----连接成功----");

                //读取数据
                while (true)
                {
                    try
                    {
                        //读取数据
                        int size = _client.Receive(buffer, 256, SocketFlags.None);
                        if (size > 0)
                        {
                            Console.WriteLine(buffer);
                            //读取数据
                            _Receipt(this, new CmdDataPacket
                            {
                                Data = buffer,
                                Size = size
                            });
                        }
                    }
                    catch (System.Net.Sockets.SocketException ex)
                    {
                        Console.WriteLine("连接断开！");
                        _connectState = 0;
                        _client.Close();
                        break;
                    }
                }
                Console.WriteLine("------");
            }
        }

        private void OnBeat()
        {
            byte[] dstr = new byte[100];
            dstr[0] = 0;
            while (_connectState == 1)
            {
                SendData(dstr, 1);
                Thread.Sleep(1000);
            }
        }
        private void SendData(byte[] data, int size)
        {
            lock (lockSendData)
            {
                byte[] dstr = new byte[100];
                dstr[0] = 0x55;
                dstr[1] = 0xAA;
                dstr[2] = (byte)(size + 3);
                for (int i = 0; i < size; i++)
                {
                    dstr[i + 3] = data[i];
                }
                _client.Send(dstr, size + 3, SocketFlags.None);
            }
        }

        private void OnSend()
        {
            while (true)
            {
                sema.WaitOne();
                if (_connectState == 1)
                {
                    if (dataPackets.Count > 0)
                    {
                        var dataPacket = dataPackets.Dequeue();
                        SendData(dataPacket.Data, dataPacket.Size);
                        Console.WriteLine("----onSend----");
                    }
                }
            }
        }

        public struct CmdDataPacket
        {
            /// <summary>
            /// 数据
            /// </summary>
            public byte[] Data;

            /// <summary>
            /// 数据长度
            /// </summary>
            public int Size;
        }

        private void onQuery()
        {
            byte[] dstr = new byte[100];
            dstr[0] = 2;
           // SendData(dstr, 1);
        }
    }
}
