using Elevator.Extend;
using Elevator.Extend.Model;
using Elevator.Helpers;
using System;
using System.Collections.Generic;

namespace Elevator
{
    public class Lift : ILift
    {
        private int _currentFloor;
        private readonly List<int> _path;
        private readonly LiftHelper _liftHelper;

        public volatile bool IsMoving;
        public volatile Direction Direction;

        public EventHandler<int> IsMoved;

        public Lift()
        {
            _currentFloor = 4;
            _path = new List<int>();
            _liftHelper = new LiftHelper();
        }

        public void Request(Message message)
        {
            if (_path.Contains(message.FloorNumber) && (message.Direction == Direction.ToString() || message.Direction == "Go"))
            {
                if (message.Direction == "Go")
                {
                    _path.InsertRange(_path.IndexOf(message.FloorNumber), new List<int> { message.FloorNumber, message.FloorNumber });
                    var exists = _liftHelper.CustomCount(_path, message.FloorNumber);
                    _path.RemoveRange(exists, 2);
                }
                else
                {
                    if (_liftHelper.StopCountIsValid(_path, message.FloorNumber))
                        _path.InsertRange(_path.IndexOf(message.FloorNumber), new List<int> { message.FloorNumber, message.FloorNumber });
                    else
                        return;
                }
            }
            else
            {
                var currentFloor = _path.Count != 0 ? _path[^1] : _currentFloor;
                if (message.FloorNumber == currentFloor)
                    return;
                else if (message.FloorNumber > currentFloor)
                    for (var i = currentFloor; i <= message.FloorNumber; i++)
                        _path.Add(i);
                else
                    for (var i = currentFloor; i >= message.FloorNumber; i--)
                        _path.Add(i);
                _path.Add(message.FloorNumber);
            }
        }

        public void GoTo()
        {
            try
            {
                Direction = _liftHelper.CalculateDirection(_path);
                IsMoved.Raise(this, _path[0]);
                _currentFloor = _path[0];
                IsMoving = true;
                _path.RemoveAt(0);
            }
            catch (Exception)
            {
                IsMoving = false;
                Direction = Direction.Stop;
            }
        }
    }
}
