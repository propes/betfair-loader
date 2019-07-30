using System.Collections.Generic;

namespace app.lib
{
    public class Logger : ILogger
    {
        public IList<string> Errors { get; private set; }

        public Logger()
        {
            Errors = new List<string>();
        }

        public void LogError(string message)
        {
            Errors.Add(message);
        }
    }
}