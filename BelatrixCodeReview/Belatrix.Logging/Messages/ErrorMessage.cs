using Belatrix.Logging.Common;

namespace Belatrix.Logging.Messages
{
    public class ErrorMessage : Message
    {
        public ErrorMessage(string message)
            : base(message)
        { }
    }
}
