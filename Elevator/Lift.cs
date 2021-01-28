using Elevator.Extend;
using Elevator.Extend.Model;
using Elevator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elevator
{
    public class Lift : ILift
    {
        private int _CurrentFloor;
        private readonly List<int> _path;
        private readonly LiftHelper _liftHelper;

        public volatile bool IsMoving;
        public volatile Direction direction;

        public EventHandler<int> IsMoved;

        public Lift()
        {
            _CurrentFloor = 4;
            _path = new List<int>();
            _liftHelper = new LiftHelper();
        }

        public void Request(Message message)
        {
            if (_path.Contains(message.FloorNumber) && _liftHelper.liftcount(_path, message.FloorNumber) < 2 && (message.Direction == direction.ToString() || message.Direction == "Go"))
                    _path.InsertRange(_path.IndexOf(message.FloorNumber), new List<int> { message.FloorNumber, message.FloorNumber });
            else
            {
                var currentFloor = _path.Count != 0 ? _path[^1] : _CurrentFloor;
                if (message.FloorNumber == currentFloor)
                    return;
                else if (message.FloorNumber > currentFloor)
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
                direction = _liftHelper.CalculateDirection(_path);
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

    }

}
