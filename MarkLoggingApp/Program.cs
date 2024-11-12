using MarkLoggingApp.Logger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var serviceProvider = new ServiceCollection()
    .AddLogging(builder =>
    {
        builder.AddProvider(new FileLoggerProvider("log.txt"));
        builder.AddConsole();
    })
    .BuildServiceProvider();

var logger = serviceProvider.GetService<ILogger<Program>>();

logger?.LogInformation("Hello world!");
logger?.LogCritical("Oh no, error!");
