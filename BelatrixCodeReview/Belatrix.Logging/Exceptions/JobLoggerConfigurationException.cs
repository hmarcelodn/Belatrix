using System;

namespace Belatrix.Logging.Exceptions
{
    public class JobLoggerConfigurationException : Exception
    {
        public JobLoggerConfigurationException(string exceptionMessage)
            : base(exceptionMessage)
        { }
    }
}
