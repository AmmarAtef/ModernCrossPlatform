using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace WorkingWithEFCore
{
    public class ConsoleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                case LogLevel.Debug:
                case LogLevel.Error:
                case LogLevel.Critical:
                default:
                    return true;
            };

        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (eventId.Id == 20100)
            {
                WriteLine($"Level: {logLevel}, Event Id: {eventId.Id}");

                if (state != null)
                {
                    WriteLine($"State: {state}");
                }


                if (exception != null)
                {
                    WriteLine($"Exception: {exception.Message}");
                }
            }
            WriteLine();

        }
    }
}
