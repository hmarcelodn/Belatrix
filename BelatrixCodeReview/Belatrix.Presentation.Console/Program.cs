using System.Collections.Generic;
using Castle.Windsor;

namespace Belatrix.Presentation.Console
{
    using Belatrix.Logging.Common;
    using Belatrix.Logging.Enum;
    using Belatrix.Logging.Factory;
    using Belatrix.Dependency.Bootstrapper;
    using Belatrix.Logging.Messages;
    using Belatrix.Logging.Facade;
    using Belatrix.Logging.Builder;
    using Belatrix.Logging.Exceptions;

    class Program
    {
        private static IWindsorContainer container;

        static void Main(string[] args)
        {
            /*
             * Setting up Dependency Injection
             */
            ConfigureInstallers();
            ConfigureConsole();

            /*
             * Building Logger Manager Class, Creating Message And Logging it.
             */
            try
            {
                var messageFactory = container.Resolve<MessageFactory>();
                var builder = container.Resolve<JobLoggerBuilder>();
                JobLogger logger = builder.EnableConsoleLog()
                                          .EnableDatabaseLog()
                                          .EnableFileLog()
                                          .EnableInfoMessage()
                                          .EnableErrorMessage()
                                          .EnableWarningMessage()
                                          .Build();

                Message message1 = messageFactory.Create("Test Info Message", EnumMessageType.INFO);
                Message message2 = messageFactory.Create("Test Warn Message", EnumMessageType.WARNING);
                Message message3 = messageFactory.Create("Test Error Message", EnumMessageType.ERROR);

                logger.LogMessage(message1);
                logger.LogMessage(message2);
                logger.LogMessage(message3);
            }
            catch (JobLoggerConfigurationException ex)
            {
                System.Console.WriteLine(string.Format("Error Ocurred: {0}", ex.Message));
            }
            catch (System.Exception ex2)
            {
                System.Console.WriteLine(string.Format("System Error: {0}", ex2.Message));
            }

            System.Console.WriteLine("Closing Belatrix Console...");
            System.Console.ReadKey();
        }

        #region [ Private Methods ]

        /// <summary>
        /// Configure Castle Windsor
        /// </summary>
        private static void ConfigureInstallers()
        {
            container = new WindsorContainer();            
            Bootstrapper.ConfigureWindsorCastle(container);
        }

        private static void ConfigureConsole()
        {
            System.Console.Title = "Belatrix Job Logger Console";
            System.Console.WriteLine("Starting Belatrix Console...");
        }

        #endregion

    }
}
