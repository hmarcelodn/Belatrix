using System.Collections;
using System.Collections.Generic;

namespace Belatrix.Logging.Factory
{
    using Belatrix.Logging.Common;
    using Belatrix.Logging.Enum;

    public class JobLoggerFactory
    {
        private IDictionary<EnumJobLoggerType, IJobLogger> loggersDic = 
            new Dictionary<EnumJobLoggerType, IJobLogger>();

        public JobLoggerFactory(IJobLogger consoleLogger, 
                                IJobLogger databaseLogger,
                                IJobLogger fileLogger)
        {
            this.loggersDic.Add(EnumJobLoggerType.CONSOLE, consoleLogger);
            this.loggersDic.Add(EnumJobLoggerType.DATABASE, databaseLogger);
            this.loggersDic.Add(EnumJobLoggerType.FILE, fileLogger);
        }

        public IJobLogger Create(EnumJobLoggerType enumJobLoggerType)
        {
            return this.loggersDic[enumJobLoggerType];
        }
    }
}
