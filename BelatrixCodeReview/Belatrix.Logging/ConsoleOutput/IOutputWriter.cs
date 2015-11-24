namespace Belatrix.Logging.ConsoleOutput
{
    using Belatrix.Logging.Common;

    public interface IOutputWriter
    {
        void WriteLine(Message message);
    }
}
