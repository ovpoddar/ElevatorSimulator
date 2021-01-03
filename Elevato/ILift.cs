namespace Elevator
{
    public interface ILift
    {
        void GoTo();
        void Request(int floor);
    }
}