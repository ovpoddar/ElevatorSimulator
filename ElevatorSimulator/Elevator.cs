using ElevatorSimulator.CustomeComponents;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ElevatorSimulator
{
    public partial class Elevator : Form
    {
        private Lift _lift;

        private Socket _serverSocket;
        private Socket _clientSocket; 
        private byte[] _buffer;
        public Elevator()
        {
            InitializeComponent();
            InitializeDynamicComponent();
            InitializeLift();
            InitializeMethods();
            CreateSarver();
        }

        void CreateSarver()
        {
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 3333));
            _serverSocket.Listen(10);

            ConnectingSarver();
        }

        private void Elevator_Load(object sender, EventArgs e)
        {
        }

        void ConnectingSarver()
        {
            _serverSocket.BeginAccept(AcceptCallback, null);
        }

        void AcceptCallback(IAsyncResult ar)
        {
            _clientSocket = _serverSocket.EndAccept(ar);
            _buffer = new byte[_clientSocket.ReceiveBufferSize];
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
            ConnectingSarver();
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
                _lift.updatepos(int.Parse(message));
            });

            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
        }


        private void Btn_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var floor = Convert.ToInt32(button.Text);

            var floorEnc = Encoding.ASCII.GetBytes(floor.ToString());

            _clientSocket.Send(floorEnc);

        }



        #region ugly methods
        private void InitializeMethods()
        {
            foreach (var button in LiftInside.Controls.OfType<Button>())
                button.Click += Btn_Click;
        }

        private void InitializeDynamicComponent()
        {
            var totalHeight = panel3.Height;
            var totalButtons = LiftInside.Controls.OfType<Button>().Count();
            var height = totalHeight / totalButtons;
            for (int i = 0; i < totalButtons - 2; i++)
                DynamicFloorHolder.Controls.Add(new Floor(height, true, true));
            DynamicFloorHolder.Height = height * (totalButtons - 2);
            TopFloorHolder.Controls.Add(new Floor(height, true, false));
            TopFloorHolder.Height = height;
            BottomFloorHolder.Controls.Add(new Floor(height, false, true));
            BottomFloorHolder.Height = height;
        }

        private void InitializeLift()
        {
            var totalHeight = panel3.Height;
            var totalButtons = LiftInside.Controls.OfType<Button>().Count();
            var height = totalHeight / totalButtons;
            _lift = new Lift(height);
            panel2.Controls.Add(_lift);

            _lift.updatepos(totalButtons - 1);
        }
        #endregion
    }
}
