using System;

namespace Belatrix.Logging.ConsoleOutput
{
    using Belatrix.Logging.Common;

    public class ConsoleJobLogger : IJobLogger
    {
        private readonly IOutputWriter outputWriter;

        public ConsoleJobLogger(IOutputWriter outputWriter)
        {
            this.outputWriter = outputWriter;
        }

        public void LogMessage(Message message)
        {
            this.outputWriter.WriteLine(message);
        }
    }
}
