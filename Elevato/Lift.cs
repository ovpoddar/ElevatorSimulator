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

        public void Request(Message message)
        {
            /// now i have the which button is being pressed and
            /// which floor i need to go no i need to calculate the path according to the  need
            /// possiable message Directions are Go, Up, Down

            if (_path.Contains(message.FloorNumber))
            {
                if (message.Direction == direction.ToString())
                    _path.Insert(_path.IndexOf(message.FloorNumber), message.FloorNumber);
            }
            else
                AddStop(message);
        }

        private void AddStop(Message message)
        {
            var currentFloor = CalculateCurrentFloor();
            if (message.FloorNumber > currentFloor)
            {
                for (var i = currentFloor; i <= message.FloorNumber; i++)
                {
                    _path.Add(i);
                }
            }
            else
            {
                for (var i = currentFloor; i >= message.FloorNumber; i--)
                {
                    _path.Add(i);
                }
            }
            // this one for reaching the destination
            _path.Add(message.FloorNumber);
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
