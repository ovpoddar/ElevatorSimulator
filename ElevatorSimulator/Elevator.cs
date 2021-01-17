using ElevatorSimulator.CustomeComponents;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            _serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3333));
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

            int message = int.Parse(Encoding.ASCII.GetString(_buffer, 0, received));
            Invoke((Action)delegate
            {
                Task.Run(() =>
                {
                    Thread.Sleep(5000);
                    _lift.updatepos(message);
                    _clientSocket.Send(Encoding.ASCII.GetBytes("Done"));
                });
            });
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
        }


        private void Btn_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            var floorEnc = Encoding.ASCII.GetBytes($"{button.Text}-Go");

            _clientSocket.Send(floorEnc);

        }



        #region ugly methods
        private void InitializeMethods()
        {
            foreach (var button in LiftInside.Controls.OfType<Button>())
                button.Click += Btn_Click;

            foreach (var floor in DynamicFloorHolder.Controls.OfType<Floor>())
                foreach (var button in floor.Controls.OfType<Button>())
                    button.Click += DirBtnClick;

            foreach (var floor in TopFloorHolder.Controls.OfType<Floor>())
                foreach (var button in floor.Controls.OfType<Button>())
                    button.Click += CustomClick;

            foreach (var floor in BottomFloorHolder.Controls.OfType<Floor>())
                foreach (var button in floor.Controls.OfType<Button>())
                    button.Click += CustomClick;
        }

        private void CustomClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            var floorEnc = Encoding.ASCII.GetBytes(MakeFix(button));

            _clientSocket.Send(floorEnc);
        }

        private string MakeFix(Button button)
        {
            var name = button.Name.ToString();
            if (name == "T-Down")
                return "0-Up";
            return "3-Down";
        }

        private void DirBtnClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            var floorEnc = Encoding.ASCII.GetBytes(button.Name.ToString());

            _clientSocket.Send(floorEnc);
        }

        private void InitializeDynamicComponent()
        {
            var totalHeight = panel3.Height;
            var totalButtons = LiftInside.Controls.OfType<Button>().Count();
            var height = totalHeight / totalButtons;
            for (int i = 0; i < totalButtons - 2; i++)
                DynamicFloorHolder.Controls.Add(new Floor(height, true, true, $"{i + 1}"));
            DynamicFloorHolder.Height = height * (totalButtons - 2);
            TopFloorHolder.Controls.Add(new Floor(height, false, true, "T"));
            TopFloorHolder.Height = height;
            BottomFloorHolder.Controls.Add(new Floor(height, true, false, "G"));
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
