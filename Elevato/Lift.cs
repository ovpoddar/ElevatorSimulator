using Elevato.Models;
using Elevator.Extand;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Elevator
{
    public class Lift : ILift
    {
        private int _CurrentFloor;
        private readonly List<int> _path;

        public volatile bool IsMoving;
        public volatile Direction direction;

        public EventHandler<int> IsMoved;

        public Lift()
        {
            _CurrentFloor = 3;
            _path = new List<int>();
        }

        public void Request(int floor)
        {
            if (_path.Contains(floor))
                _path.Insert(_path.IndexOf(floor), floor);
            else
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
        }
        private int CalculateCurrentFloor()
        {
            if (_path.Count != 0)
                return _path[_path.Count - 1];
            return _CurrentFloor;
        }

        public void GoTo()
        {
            try
            {
                CalculateDirection();
                IsMoved.Raise(this, _path[0]);
                _CurrentFloor = _path[0];
                IsMoving = true;
                _path.RemoveAt(0);
            }
            catch (Exception)
            {
                IsMoving = false;
                direction = Direction.Stop;
            }

        }

        private void CalculateDirection()
        {
            try
            {
                if (_path[0] < _path[1])
                {
                    direction = Direction.Down;
                }
                else if (_path[0] > _path[1])
                {
                    direction = Direction.Up;
                }
                else
                {
                    direction = Direction.Stop;
                }
            }
            catch
            {
                direction = Direction.Stop;
            }
        }
    }

}
