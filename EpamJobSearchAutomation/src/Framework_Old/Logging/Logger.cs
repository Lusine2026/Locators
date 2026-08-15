using EpamJobSearchAutomation.src.Framework.Configuration;
using NLog;

namespace EpamJobSearchAutomation.src.Framework.Logging
{
    public static class Logger
    {
        private static readonly ILogger logger =
            LogManager.GetCurrentClassLogger();

        public static void Configure()
        {
            var minimumLevel = ConfigurationHelper.LoggingSettings.MinimumLevel;

            var logLevel = LogLevel.FromString(minimumLevel);

            foreach (var rule in LogManager.Configuration.LoggingRules)
            {
                rule.SetLoggingLevels(logLevel, LogLevel.Fatal);
            }

            LogManager.ReconfigExistingLoggers();
        }

        public static void Info(string message)
        {
            logger.Info(message);
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }

        public static void Debug(string message)
        {
            logger.Debug(message);
        }
    }
}