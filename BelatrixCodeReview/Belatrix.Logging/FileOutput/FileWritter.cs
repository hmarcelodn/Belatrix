using System;
using System.Configuration;
using System.IO;

namespace Belatrix.Logging.FileOutput
{
    using Belatrix.Logging.Common;

    public class FileWritter : IFileWritter
    {
        public void WriteFile(Message message)
        {
            string l = string.Empty;
            string fileName = ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + "-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;

            if (File.Exists(fileName + ".txt"))
            {
                l = File.ReadAllText(fileName + ".txt");
            }

            l = l + DateTime.Now.ToShortDateString() + message.MessageText;

            File.WriteAllText(fileName + ".txt", l);
        }
    }
}
