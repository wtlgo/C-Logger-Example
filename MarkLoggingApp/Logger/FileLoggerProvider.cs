using Microsoft.Extensions.Logging;

namespace MarkLoggingApp.Logger;

public class FileLoggerProvider(string filePath) : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName) => new FileLogger(filePath);
    public void Dispose() => GC.SuppressFinalize(this);
}
