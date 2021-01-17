using Elevato.Models;

namespace Elevato.Extand
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
