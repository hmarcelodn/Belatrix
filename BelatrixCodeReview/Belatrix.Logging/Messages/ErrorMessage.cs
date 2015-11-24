using Belatrix.Logging.Common;

namespace Belatrix.Logging.Messages
{
    public class ErrorMessage : Message
    {
        public ErrorMessage(string message)
            : base(message)
        { }

        public override Enum.EnumMessageType MessageType
        {
            get { return Enum.EnumMessageType.ERROR; }
        }
    }
}
