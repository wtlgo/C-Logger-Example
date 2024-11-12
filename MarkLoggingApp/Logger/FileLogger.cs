using Microsoft.Extensions.Logging;

namespace MarkLoggingApp.Logger;

public class FileLogger(string filePath) : ILogger
{
    private static readonly object Lock = new();

    public bool IsEnabled(LogLevel logLevel) => true;
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);
        lock (Lock)
        {
            File.AppendAllText(filePath, $"{DateTime.Now}: {logLevel}: {message}{Environment.NewLine}");
        }
    }
}
