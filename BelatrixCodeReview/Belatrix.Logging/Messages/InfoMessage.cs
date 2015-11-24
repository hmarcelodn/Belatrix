using Belatrix.Logging.Common;

namespace Belatrix.Logging.Messages
{
    public class InfoMessage : Message
    {
        public InfoMessage(string message)
            : base(message)
        { }

        public override Enum.EnumMessageType MessageType
        {
            get { return Enum.EnumMessageType.INFO; }
        }
    }
}
