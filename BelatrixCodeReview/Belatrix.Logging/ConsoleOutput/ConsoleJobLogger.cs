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

        public void LogMessage(string message)
        {            
            this.outputWriter.WriteLine(string.Format("{0} - {1}", DateTime.Now.ToShortDateString(), message));
        }
    }
}
