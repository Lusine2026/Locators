using Microsoft.Extensions.Configuration;

namespace EpamJobSearchAutomation.Configuration
{
    public static class ConfigurationHelper
    {
        private static readonly IConfiguration Configuration =
            new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

        public static BrowserSettings BrowserSettings =>
            Configuration.GetSection("Browser").Get<BrowserSettings>()!;
    }
}