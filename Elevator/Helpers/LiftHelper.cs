using Elevator.Extend;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Elevator.Helpers
{
    public class LiftHelper : ILiftHelper
    {
        public bool StopCount(List<int> path, int floorNumber) =>
            path.Where(item => item == floorNumber)
            .Count() < 2;

        public Direction CalculateDirection(List<int> path)
        {
            try
            {
                return path[0] < path[1] ? Direction.Down : path[0] > path[1] ? Direction.Up : Direction.Stop;
            }
            catch
            {
                return Direction.Stop;
            }
        }
    }
}
