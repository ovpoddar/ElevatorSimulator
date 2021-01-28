using Elevator.Extend;
using System.Collections.Generic;

namespace Elevator.Helpers
{
    public interface ILiftHelper
    {
        Direction CalculateDirection(List<int> path);
        bool StopCountIsValid(List<int> path, int floorNumber);
        int CustomCount(List<int> path, int floorNumber);
    }
}