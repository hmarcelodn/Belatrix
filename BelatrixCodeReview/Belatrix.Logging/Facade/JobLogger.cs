using System.Collections.Generic;

namespace Belatrix.Logging.Facade
{
    using Belatrix.Logging.Common;
    using Belatrix.Logging.Exceptions;
    using Belatrix.Logging.Factory;
    using Belatrix.Logging.Messages;

    public class JobLogger
    {
        private IList<IJobLogger> jobLoggers;

        public bool LogErrors { get; internal set; }

        public bool LogWarnings { get; internal set; }

        public bool LogInfo { get; internal set; }

        public IList<IJobLogger> ActiveLoggers
        {
            get { return this.jobLoggers; }
        }

        public JobLogger()
        {
            this.jobLoggers = new List<IJobLogger>();
        }

        public void LogMessage(Message message)
        {
            if (string.IsNullOrEmpty(message.MessageText))
            {
                throw new JobLoggerConfigurationException("Message text was not specified.");
            }

            if (this.jobLoggers.Count == 0)
            {
                throw new JobLoggerConfigurationException("There are not loggers enabled to use.");
            }

            if (!this.LogErrors && !this.LogInfo && !this.LogWarnings)
            {
                throw new JobLoggerConfigurationException("Error or Warning or Message must be specified.");
            }

            if ((this.LogErrors && message is ErrorMessage) || (this.LogInfo && message is InfoMessage) || (this.LogWarnings && message is WarningMessage))
            {
                foreach (var logger in jobLoggers)
                {
                    logger.LogMessage(message);
                }
            }
        }

        public void SetJobLogger(IJobLogger jobLogger)
        {
            this.jobLoggers.Add(jobLogger);
        }

    }
}
