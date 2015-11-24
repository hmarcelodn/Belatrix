using System;

namespace Belatrix.Logging.ConsoleOutput
{
    using Belatrix.Logging.Common;

    public class OutputWritter : IOutputWriter
    {
        public void WriteLine(Message message)
        {
            Console.WriteLine(string.Format("{0}", message.MessageText));
        }
    }
}
