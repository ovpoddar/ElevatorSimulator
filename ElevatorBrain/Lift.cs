using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorBrain
{
    public partial class Lift : Form
    {

        private Socket _clientSocket;
        private byte[] _buffer;

        private int _CurrentFloor;
        private volatile List<int> _path;

        public volatile bool IsMoving;
        public CancellationTokenSource TokenSource;

        public Lift()
        {
            InitializeComponent();
            ConnectToSarver();

            _CurrentFloor = 3;
            _path = new List<int>();
        }

        void ConnectToSarver()
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3333));
            _buffer = new byte[_clientSocket.ReceiveBufferSize];
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            int received = _clientSocket.EndReceive(ar);

            if (received == 0)
            {
                return;
            }


            string message = Encoding.ASCII.GetString(_buffer, 0, received);
            Invoke((Action)delegate
            {
                if (IsMoving)
                {
                    TokenSource.Cancel();
                    Request(int.Parse(message));
                    GoTo();
                }
                else
                {
                    Request(int.Parse(message));
                    GoTo();
                }
            });




            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
        }


        private void sendMessage(string Message)
        {
            _clientSocket.Send(Encoding.ASCII.GetBytes(Message));
        }

        public void Request(int floor)
        {
            var currentFloor = CalculateCurrentFloor();
            if (floor > currentFloor)
            {
                for (var i = currentFloor; i <= floor; i++)
                {
                    _path.Add(i);
                }
            }
            else
            {
                for (var i = currentFloor; i >= floor; i--)
                {
                    _path.Add(i);
                }
            }
            // this one for reaching the destination
            _path.Add(floor);
        }

        private int CalculateCurrentFloor()
        {
            if (_path.Count != 0)
                return _path[_path.Count - 1];
            return _CurrentFloor;
        }

        public void GoTo()
        {
            Task.Run(() =>
            {
                var index = 0;
                TokenSource = new CancellationTokenSource();
                var _cancellationToken = TokenSource.Token;
                var temppath = _path.Count;
                while (index < temppath)
                {
                    if (_cancellationToken.IsCancellationRequested)
                        break;
                    Thread.Sleep(5000);
                    try
                    {
                        sendMessage(_path[0].ToString());
                        _CurrentFloor = _path[0];
                        IsMoving = true;
                        _path.RemoveAt(0);
                        index++;
                    }
                    catch (Exception)
                    {
                        IsMoving = true;
                        index++;
                    }
                }
                IsMoving = false;
            });


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var floorEnc = Encoding.ASCII.GetBytes("lift");
            _clientSocket.Send(floorEnc);
        }
    }
}
