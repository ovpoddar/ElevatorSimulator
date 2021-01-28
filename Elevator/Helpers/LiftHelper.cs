using Elevator.Extend;
using System.Collections.Generic;
using System.Linq;

namespace Elevator.Helpers
{
    public class LiftHelper : ILiftHelper
    {
        public bool StopCountIsValid(List<int> path, int floorNumber) =>
            path.Where(item => item == floorNumber).Count() < 2;

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

        public int CustomCount(List<int> path, int floorNumber)
        {
            var temp = new List<int>(path);
            var firstindex = temp.IndexOf(floorNumber) + 3;
            temp.RemoveRange(0, firstindex);
            return temp.IndexOf(floorNumber) + firstindex;
        }
    }
}
