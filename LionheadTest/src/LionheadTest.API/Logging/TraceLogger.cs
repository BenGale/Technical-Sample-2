using System.Diagnostics;
using LionheadTest.Domain.Logging;

namespace LionheadTest.API.Logging
{
    public class TraceLogger : ILogger
    {
        public void Log(string message)
        {
            Trace.WriteLine(message);
        }
    }
}