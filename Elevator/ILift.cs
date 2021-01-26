using Elevator.Extend.Model;

namespace Elevator
{
    public interface ILift
    {
        void GoTo();
        void Request(Message message);
        void CalculateDirection();
    }
}