using Elevator.Extend;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator.Helpers
{
    public class LiftHelper : ILiftHelper
    {
        public int liftcount(List<int> path, int floorNumber)
        {
            var count = 0;
            foreach (var item in path)
            {
                if (item == floorNumber)
                    count++;
            }
            return count;
        }

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
