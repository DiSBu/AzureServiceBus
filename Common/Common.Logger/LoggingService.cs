using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace Common.Logger
{
    public class LoggingService : ILoggingService
    {
        public LoggingService(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

            Log.Logger.Information($"{this.GetType().Name}: service is started. CurrentDirectory: {Directory.GetCurrentDirectory()} - appsettings.{Environment.GetEnvironmentVariable("RUNTIME_ENVIRONMENT") ?? "PROD"}.json");
        }
        public void LogDebug(string message)
        {
            Log.Logger.Debug(message);
        }
        public void LogError(Exception ex, string message)
        {
            Log.Logger.Error(ex, message);
        }
        public void LogWarning(string message)
        {
            Log.Logger.Warning(message);
        }
        public void LogInformation(string message)
        {
            Log.Logger.Information(message);
        }
    }
}