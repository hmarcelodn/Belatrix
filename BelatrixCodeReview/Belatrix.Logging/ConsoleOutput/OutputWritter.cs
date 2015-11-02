using System;

namespace Belatrix.Logging.ConsoleOutput
{
    public class OutputWritter : IOutputWriter
    {
        public void WriteLine(string s)
        {
            Console.WriteLine(string.Format("{0}", s));
        }
    }
}
