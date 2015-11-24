
using Belatrix.Logging.Enum;
namespace Belatrix.Logging.Common
{
    public abstract class Message
    {
        protected string message;

        protected Message()
        { }

        public Message(string message)
        {
            this.message = message;
        }

        public string MessageText
        {
            get { return this.message; }
        }

        public abstract EnumMessageType MessageType { get; }
    }
}
