using EpamJobSearchAutomation.Framework.Enums;
using Microsoft.Extensions.Configuration;

namespace EpamJobSearchAutomation.Framework.Configuration
{
    public static class ConfigurationHelper
    {
        private static readonly IConfiguration Configuration =
                new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("AppSettings/appsettings.json", optional: false)
                    .AddJsonFile($"AppSettings/appsettings.{EnvironmentName}.json", optional: true)
                    .Build();

        private static string EnvironmentName =>
                Environment.GetEnvironmentVariable("ENVIRONMENT") ?? "Local";

        public static BrowserSettings BrowserSettings
        {
            get
            {
                var settings = Configuration
                    .GetSection("Browser")
                    .Get<BrowserSettings>()!;

                var browser = Environment.GetEnvironmentVariable("BROWSER");

                if (!string.IsNullOrWhiteSpace(browser) &&
                    Enum.TryParse<BrowserType>(browser, true, out var browserType))
                {
                    settings.Browser = browserType;
                }

                return settings;
            }
        }

        public static LoggingSettings LoggingSettings =>
            Configuration
                .GetSection("Logging")
                .Get<LoggingSettings>()!;

        public static string ApplicationUrl =>
             Configuration["ApplicationUrl"]!;

        public static string ApiBaseUrl =>
            Configuration["ApiBaseUrl"]!;

    }
}