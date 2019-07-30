using app.lib.Logging;

namespace app.lib.tests
{
    public class FakeLogger : ILogger
    {
        public int ErrorCount { get; private set; }
        public int DuplicateCount { get; private set; }
        public int RecordCount { get; private set; }
        public int SuccessCount { get; internal set; }

        public void LogDuplicate(string message)
        {
            DuplicateCount++;
        }

        public void LogError(string message)
        {
            ErrorCount++;
        }

        public void LogRecord()
        {
            RecordCount++;
        }

        public void LogSuccess()
        {
            SuccessCount++;
        }
    }
}