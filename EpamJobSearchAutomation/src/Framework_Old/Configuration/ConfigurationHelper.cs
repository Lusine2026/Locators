using Microsoft.Extensions.Configuration;

namespace EpamJobSearchAutomation.src.Framework.Configuration
{
    public static class ConfigurationHelper
    {
        private static readonly IConfiguration Configuration =
                new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true)
                    .Build();

        private static string EnvironmentName =>
                Environment.GetEnvironmentVariable("ENVIRONMENT") ?? "Local";

        public static BrowserSettings BrowserSettings =>
            Configuration
                .GetSection("Browser")
                .Get<BrowserSettings>()!;

        public static LoggingSettings LoggingSettings =>
            Configuration
                .GetSection("Logging")
                .Get<LoggingSettings>()!;

        public static string ApplicationUrl =>
            Configuration["ApplicationUrl"]!;
    }
}