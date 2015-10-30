using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Belatrix.Dependency.Installer
{
    using Belatrix.Logging.Common;
    using Belatrix.Logging.ConsoleOutput;
    using Belatrix.Logging.DataBaseOutput;
    using Belatrix.Logging.FileOutput;

    public class LogWritterInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                Component.For<IOutputWriter>()
                         .ImplementedBy<OutputWritter>()
                         .Named("outputWriter"),

                Component.For<IDataBaseWritter>()
                         .ImplementedBy<DataBaseWritter>()
                         .Named("dataBaseWritter"),

                Component.For<IFileWritter>()
                         .ImplementedBy<FileWritter>()
                         .Named("fileWritter"),

                Component.For<IJobLogger>()
                         .ImplementedBy<ConsoleJobLogger>()
                         .DependsOn(ServiceOverride.ForKey<IOutputWriter>().Eq("outputWriter"))
                         .Named("consoleJobLogger"),

                Component.For<IJobLogger>()
                         .ImplementedBy<DatabaseJobLogger>()
                         .DependsOn(ServiceOverride.ForKey<IDataBaseWritter>().Eq("dataBaseWritter"))
                         .Named("databaseJobLogger"),

                Component.For<IJobLogger>()
                         .ImplementedBy<FileJobLogger>()
                         .DependsOn(ServiceOverride.ForKey<IFileWritter>().Eq("fileWritter"))
                         .Named("fileJobLogger")

            );
        }
    }
}
