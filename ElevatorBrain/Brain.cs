﻿using Elevator.Extend;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Elevator.Brain
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
            var message = MessageHelper.ComcomposeMessage(e, _lift.direction.ToString());
            listBox1.Items.Add(message);
            sendMessage(message);
        }

        private void ConnectToSarver()
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3333));
            _buffer = new byte[_clientSocket.ReceiveBufferSize];
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            var received = _clientSocket.EndReceive(ar);

            if (received == 0)
                return;

            var message = Encoding.ASCII.GetString(_buffer, 0, received);
            if (message == "Done")
                Invoke((Action)delegate
                {
                    _lift.GoTo();
                });
            else
                Invoke((Action)delegate
                {
                    _lift.Request(MessageHelper.ParseMessage(message));
                    if (!_lift.IsMoving)
                        _lift.GoTo();
                });
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
        }


        private void sendMessage(string Message) =>
            _clientSocket.Send(Encoding.ASCII.GetBytes(Message));
    }
}