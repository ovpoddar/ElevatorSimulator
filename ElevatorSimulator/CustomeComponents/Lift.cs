using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorSimulator.CustomeComponents
{
    public partial class Lift : UserControl
    {
        private readonly int _height;
        private int _CurrentFloor;

        public Lift(int height)
        {
            InitializeComponent();
            this._height = height;
            this.Height = _height;
            _CurrentFloor = 0;
        }
        public void GoTo(int floor)
        {
                if (floor > _CurrentFloor)
                {
                    for (var i = _CurrentFloor; i <= floor; i++)
                    {
                        Thread.Sleep(1000);
                        updatepos(i);
                    }
                }
                else
                {
                    for (var i = _CurrentFloor; i >= floor; i--)
                    {
                        Thread.Sleep(1000);
                        updatepos(i);
                    }
                }
        }

        public void updatepos(int floor)
        {
            this.Top = floor * _height;
            _CurrentFloor = floor;
        }
    }
}
