using System.Collections.Generic;

namespace app.lib.tests
{
    public class FakeLogger : ILogger
    {
        public int ErrorCount { get; private set; }
        public IList<string> Errors { get; }

        public void LogError(string message)
        {
            ErrorCount++;
        }
    }
}