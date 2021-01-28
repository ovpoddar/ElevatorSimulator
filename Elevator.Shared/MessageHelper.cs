using Elevator.Extend.Model;

namespace Elevator.Extend
{
    public static class MessageHelper
    {
        public static Message ParseMessage(string message) =>
            new Message
            {
                Direction = message.Split((char)'-')[1],
                FloorNumber = int.Parse(message.Split((char)'-')[0])
            };

        public static string ComposeMessage(int floor, string direction) =>
            $"{floor}-{direction}";
    }
}
