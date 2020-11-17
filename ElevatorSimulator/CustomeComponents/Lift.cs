using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorSimulator.CustomeComponents
{
    public partial class Lift : UserControl
    {
        private readonly int _height;
        private int _CurrentFloor;
        private List<int> _path;

        public Lift(int height)
        {
            InitializeComponent();
            this._height = height;
            this.Height = _height;
            _CurrentFloor = 0;
            _path = new List<int>();
        }
        public void Request(int floor)
        {
            if (floor > _CurrentFloor)
            {
                for (var i = _CurrentFloor; i <= floor; i++)
                {
                    _path.Add(i);
                }
            }
            else
            {
                for (var i = _CurrentFloor; i >= floor; i--)
                {
                    _path.Add(i);
                }
            }
        }

        public void GoTo()
        {
            while (_path.Count == 0)
            {
                //updatepos()
            }
        }

        public void updatepos(int floor)
        {
            this.Top = floor * _height;
            _CurrentFloor = floor;
        }
    }
}
