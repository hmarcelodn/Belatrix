using Castle.Windsor;

namespace Belatrix.Dependency.Bootstrapper
{
    using Belatrix.Dependency.Installer;

    public static class Bootstrapper
    {
        public static void ConfigureWindsorCastle(IWindsorContainer container)
        {
            container.Install(new LogWritterInstaller());
        }
    }
}
