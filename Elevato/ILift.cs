using Elevato.Models;

namespace Elevator
{
    public interface ILift
    {
        void GoTo();
        void Request(Message message);
    }
}