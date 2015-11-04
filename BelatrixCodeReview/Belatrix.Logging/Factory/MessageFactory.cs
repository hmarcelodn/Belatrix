using Belatrix.Logging.Common;
using Belatrix.Logging.Enum;
using Belatrix.Logging.Messages;

namespace Belatrix.Logging.Factory
{
    public class MessageFactory
    {
        public Message Create(string s, EnumMessageType type)
        {
            Message message = null;

            switch (type)
            { 
                case EnumMessageType.INFO:
                    message =  new InfoMessage(s);
                    break;
                case EnumMessageType.WARNING:
                    message = new WarningMessage(s);
                    break;
                case EnumMessageType.ERROR:
                    message = new ErrorMessage(s);
                    break;
            }

            return message;
        }
    }
}
