using System.Collections.Generic;
using System.Linq;

namespace app.lib.Logging
{
    public class Logger : ILogger
    {
        private List<LogMessage> _messages = new List<LogMessage>();
        public IEnumerable<string> Errors =>
            _messages
                .Where(m => m.Type == LogMessageType.Error)
                .Select(m => m.Message)
                .ToList();

        public IEnumerable<string> Duplicates =>
            _messages
                .Where(m => m.Type == LogMessageType.Duplicate)
                .Select(m => m.Message)
                .ToList();

        public void LogError(string message)
        {
            _messages.Add(new LogMessage(LogMessageType.Error, message));
        }

        public void LogDuplicate(string message)
        {
            _messages.Add(new LogMessage(LogMessageType.Duplicate, message));
        }
    }
}