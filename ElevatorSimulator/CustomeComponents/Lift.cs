using ElevatorSimulator.Extands;
using System;
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
        private volatile List<int> _path;

        public volatile bool IsMoving;
        public CancellationTokenSource TokenSource;
        public event EventHandler<int> LiftMoving; 

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
                while(index < temppath)
                {
                    if (_cancellationToken.IsCancellationRequested)
                        break;
                    Thread.Sleep(1000);
                    try
                    {
                        LiftMoving.Raise(this, _path[0]);
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

        public void updatepos(int floor)
        {
            this.Top = floor * _height;
            _CurrentFloor = floor;
        }
    }
}
