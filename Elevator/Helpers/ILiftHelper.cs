using Elevator.Extend;
using System.Collections.Generic;

namespace Elevator.Helpers
{
    public interface ILiftHelper
    {
        Direction CalculateDirection(List<int> path);
        bool StopCount(List<int> path, int floorNumber);
    }
}