using System;

namespace Belatrix.Logging.Factory
{
    using Belatrix.Logging.Common;

    public interface IJobLoggerFactory
    {
        IJobLogger Create(Belatrix.Logging.Enum.EnumJobLoggerType enumJobLoggerType);
    }
}
