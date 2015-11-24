namespace Belatrix.Logging.Builder
{
    using Belatrix.Logging.Facade;
    using Belatrix.Logging.Factory;

    public class JobLoggerBuilder
    {
        private bool logInfo = false;
        private bool logWarning = false;
        private bool logError = false;
        private readonly IJobLoggerFactory loggerFactory;
        private readonly JobLogger jobLogger;

        public JobLoggerBuilder EnableDatabaseLog()
        {
            this.jobLogger.SetJobLogger(this.loggerFactory.Create(Enum.EnumJobLoggerType.DATABASE));
            return this;
        }

        public JobLoggerBuilder EnableFileLog()
        {
            this.jobLogger.SetJobLogger(this.loggerFactory.Create(Enum.EnumJobLoggerType.FILE));
            return this;
        }

        public JobLoggerBuilder EnableConsoleLog()
        {
            this.jobLogger.SetJobLogger(this.loggerFactory.Create(Enum.EnumJobLoggerType.CONSOLE));
            return this;
        }

        public JobLoggerBuilder EnableInfoMessage()
        {
            this.logInfo = true;
            return this;
        }

        public JobLoggerBuilder EnableWarningMessage()
        {
            this.logWarning = true;
            return this;
        }

        public JobLoggerBuilder EnableErrorMessage()
        {
            this.logError = true;
            return this;
        }

        public JobLoggerBuilder(JobLogger jobLogger, IJobLoggerFactory loggerFactory)
        {
            this.jobLogger = jobLogger;
            this.loggerFactory = loggerFactory;
        }

        public JobLogger Build()
        {
            this.jobLogger.LogErrors = this.logError;
            this.jobLogger.LogWarnings = this.logWarning;
            this.jobLogger.LogInfo = this.logInfo;
            return this.jobLogger;
        }
    }
}
