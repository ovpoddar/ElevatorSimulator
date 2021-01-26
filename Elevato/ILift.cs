using Elevator.Extend.Model;
using Elevator.Models;

namespace Elevator
{
    public interface ILift
    {
        void GoTo();
        void Request(Message message);
        void CalculateDirection();
    }
}