using System.Collections.Generic;
using Castle.Windsor;

namespace Belatrix.Presentation.Console
{
    using Belatrix.Logging.Common;
    using Belatrix.Logging.Enum;
    using Belatrix.Logging.Factory;
    using Belatrix.Dependency.Bootstrapper;

    class Program
    {
        private static IWindsorContainer container;

        static void Main(string[] args)
        {
            ConfigureInstallers();

            var jobLoggingFactory = container.Resolve<JobLoggerFactory>();

            IList<IJobLogger> jobLoggers = new List<IJobLogger>();
            jobLoggers.Add(jobLoggingFactory.Create(EnumJobLoggerType.CONSOLE));
            jobLoggers.Add(jobLoggingFactory.Create(EnumJobLoggerType.DATABASE));
            jobLoggers.Add(jobLoggingFactory.Create(EnumJobLoggerType.FILE));

            foreach (var logger in jobLoggers)
            {
                logger.LogMessage("Test");
            }            
        }

        private static void ConfigureInstallers()
        {
            container = new WindsorContainer();            
            Bootstrapper.ConfigureWindsorCastle(container);  
        }

    }
}
