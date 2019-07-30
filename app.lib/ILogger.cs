using System.Collections.Generic;

namespace app.lib
{
    public interface ILogger
    {
        IList<string> Errors { get; }
        void LogError(string message);
    }
}