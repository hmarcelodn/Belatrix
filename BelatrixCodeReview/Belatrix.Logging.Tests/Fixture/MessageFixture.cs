
using Belatrix.Logging.Common;
using Belatrix.Logging.Messages;

namespace Belatrix.Logging.Tests
{
    public class MessageFixture
    {
        public static Message CreateError()
        {
            return new ErrorMessage("Error Message");
        }

        public static Message CreateWarning()
        {
            return new WarningMessage("Warning Messages");
        }

        public static Message CreateNullMessageText()
        {
            return new InfoMessage("");
        }
    }
}
