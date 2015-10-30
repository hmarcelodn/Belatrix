namespace Belatrix.Logging.FileOutput
{
    using Belatrix.Logging.Common;

    public class FileJobLogger : IJobLogger
    {
        private readonly IFileWritter fileWritter;

        public FileJobLogger(IFileWritter fileWritter)
        {
            this.fileWritter = fileWritter;
        }

        public void LogMessage(string message)
        {
            this.fileWritter.WriteFile(message);      
        }
    }
}
