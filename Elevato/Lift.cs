using Elevator.Extend;
using Elevator.Extend.Model;
using Elevator.Models;
using System;
using System.Collections.Generic;

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
            if (_path.Contains(message.FloorNumber))
            {
                if (message.Direction == direction.ToString())
                    _path.Insert(_path.IndexOf(message.FloorNumber), message.FloorNumber);
            }
            else
            {
                var currentFloor = _path.Count != 0 ? _path[_path.Count - 1] : (_CurrentFloor + 1);
                if (message.FloorNumber > currentFloor)
                    for (var i = currentFloor; i <= message.FloorNumber; i++)
                        _path.Add(i);
                else
                    for (var i = currentFloor; i >= message.FloorNumber; i--)
                        _path.Add(i);
                // this one for reaching the destination
                _path.Add(message.FloorNumber);
            }
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

        public void CalculateDirection()
        {
            try
            {
                if (_path[0] < _path[1])
                    direction = Direction.Down;
                else if (_path[0] > _path[1])
                    direction = Direction.Up;
                else
                    direction = Direction.Stop;
            }
            catch
            {
                direction = Direction.Stop;
            }
        }


    }

}
