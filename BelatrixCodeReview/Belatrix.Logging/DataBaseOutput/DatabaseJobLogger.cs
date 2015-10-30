namespace Belatrix.Logging.DataBaseOutput
{
    using Belatrix.Logging.Common;
    using Belatrix.Logging.DataBaseOutput;

    public class DatabaseJobLogger : IJobLogger
    {
        private readonly IDataBaseWritter databaseWritter;

        public DatabaseJobLogger(IDataBaseWritter databaseWritter)
        {
            this.databaseWritter = databaseWritter;
        }

        public void LogMessage(string message)
        {
            this.databaseWritter.Save(message);
        }
    }
}