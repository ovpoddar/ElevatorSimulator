using Elevator.Models;

namespace Elevator.Extand
{
    public static class MessageHelper
    {
        public static Message ParseMessage(string message)
        {
            return new Message
            {
                Direction = message.Split("-")[1],
                FloorNumber = int.Parse(message.Split("-")[0])
            };
        }
    }
}
