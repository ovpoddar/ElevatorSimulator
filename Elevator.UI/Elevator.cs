using Elevator.Extend;
using Elevator.UI.CustomeComponents;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elevator.UI
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

        private void CreateSarver()
        {
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3333));
            _serverSocket.Listen(10);

            ConnectingServer();
        }

        private void ConnectingServer() =>
            _serverSocket.BeginAccept(AcceptCallback, null);

        private void AcceptCallback(IAsyncResult ar)
        {
            _clientSocket = _serverSocket.EndAccept(ar);
            _buffer = new byte[_clientSocket.ReceiveBufferSize];
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
            ConnectingServer();
        }

        private void ReceiveCallback(IAsyncResult messageAsyncResult)
        {
            var received = _clientSocket.EndReceive(messageAsyncResult);

            if (received == 0)
                return;

            var message = MessageHelper.ParseMessage((Encoding.ASCII.GetString(_buffer, 0, received)));
            Invoke((Action)delegate
            {
                Task.Run(() =>
                {
                    _lift.UpdatePosition(message.FloorNumber);
                    Thread.Sleep(4000);

                    if (string.Equals(message.Direction, "Stop"))
                        ShowStopToFloor(message.FloorNumber).Stop();
                    Send("Done");
                });
            });
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
        }


        private void Btn_Click(object sender, EventArgs e) =>
            Send($"{((Button)sender).Text}-Go");

        private Floor ShowStopToFloor(int floorNumber)
        {
            var result = new object();
            if (floorNumber == 0)
                result = TopFloorHolder.Controls.OfType<Floor>().ToList()[0];
            else if (floorNumber == (LiftInside.Controls.OfType<Button>().Count() -1))
                result = BottomFloorHolder.Controls.OfType<Floor>().ToList()[0];
            else
                foreach (var floor in DynamicFloorHolder.Controls.OfType<Floor>())
                    if (floor.Name == floorNumber.ToString())
                        result = floor;

            return (Floor)result;
        }

        private void InitializeMethods()
        {
            foreach (var button in LiftInside.Controls.OfType<Button>())
                button.Click += Btn_Click;

            foreach (var floor in DynamicFloorHolder.Controls.OfType<Floor>())
                foreach (var button in floor.Controls.OfType<Button>())
                    button.Click += DirBtnClick;

            foreach (var button in TopFloorHolder.Controls.OfType<Floor>().ToList()[0].Controls.OfType<Button>())
                button.Click += CustomClick;

            foreach (var button in BottomFloorHolder.Controls.OfType<Floor>().ToList()[0].Controls.OfType<Button>())
                button.Click += CustomClick;
        }

        private void CustomClick(object sender, EventArgs e) =>
            Send("T-Down" == ((Button)sender).Name.ToString()
                ? "0-Down"
                : "4-Up");


        private void DirBtnClick(object sender, EventArgs e) =>
            Send(((Button)sender).Name.ToString());

        private void Send(string message) =>
            _clientSocket.Send(Encoding.ASCII.GetBytes(message));

        private void InitializeDynamicComponent()
        {
            var totalButtons = LiftInside.Controls.OfType<Button>().Count();
            var height = panel3.Height / totalButtons;
            for (var i = 0; i < totalButtons - 2; i++)
                DynamicFloorHolder.Controls.Add(new Floor(height, true, true, $"{i + 1}"));
            DynamicFloorHolder.Height = height * (totalButtons - 2);
            TopFloorHolder.Controls.Add(new Floor(height, false, true, "T"));
            TopFloorHolder.Height = height;
            BottomFloorHolder.Controls.Add(new Floor(height, true, false, "G"));
            BottomFloorHolder.Height = height;
        }

        private void InitializeLift()
        {
            var totalButtons = LiftInside.Controls.OfType<Button>().Count();
            var height = panel3.Height / totalButtons;
            _lift = new Lift(height);
            panel2.Controls.Add(_lift);

            _lift.UpdatePosition(totalButtons - 1);
        }
    }
}
