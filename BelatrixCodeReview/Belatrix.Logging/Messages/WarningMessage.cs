using Belatrix.Logging.Common;

namespace Belatrix.Logging.Messages
{
    public class WarningMessage : Message
    {
        public WarningMessage(string message)
            : base(message)
        { }


        public override Enum.EnumMessageType MessageType
        {
            get { return Enum.EnumMessageType.WARNING; }
        }
    }
}
