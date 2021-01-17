using Elevato.Extand;
using Elevator;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ElevatorBrain
{
    public partial class Brain : Form
    {

        private Socket _clientSocket;
        private byte[] _buffer;
        private readonly Lift _lift = new Lift();

        public Brain()
        {
            InitializeComponent();
            ConnectToSarver();
            _lift.IsMoved += LiftMoved;
        }

        private void LiftMoved(object sender, int e)
        {
            var messa = e + "  " +_lift.direction;
            listBox1.Items.Add(messa);
            sendMessage(e.ToString());
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
                return;

            string message = Encoding.ASCII.GetString(_buffer, 0, received);
            if (message == "Done")
                Invoke((Action)delegate
                {
                    _lift.GoTo();
                });
            else
                Invoke((Action)delegate
                {
                    _lift.Request(MessageHelper.ParseMessage(message));
                    if(!_lift.IsMoving)
                        _lift.GoTo();
                });
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
        }


        private void sendMessage(string Message)
        {
            _clientSocket.Send(Encoding.ASCII.GetBytes(Message));
        }

    }
}