using System;
using System.Configuration;
using System.IO;

namespace Belatrix.Logging.FileOutput
{
    public class FileWritter : IFileWritter
    {
        public void WriteFile(string s)
        {
            string l = string.Empty;
            string fileName = ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString();

            if (!File.Exists(fileName + ".txt"))
            {
                l = File.ReadAllText(fileName + ".txt");
            }

            l = l + DateTime.Now.ToShortDateString() + s;

            File.WriteAllText(fileName + ".txt", l);
        }
    }
}
