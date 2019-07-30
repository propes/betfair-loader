using System.Collections.Generic;

namespace app.lib.Logging
{
    public interface ILogger
    {
        void LogError(string message);

        void LogDuplicate(string message);
    }
}