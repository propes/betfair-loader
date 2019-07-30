namespace app.lib.Logging
{
    public class LogMessage
    {
        public LogMessageType Type { get; private set; }
        public string Message { get; private set; }

        public LogMessage(LogMessageType type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}