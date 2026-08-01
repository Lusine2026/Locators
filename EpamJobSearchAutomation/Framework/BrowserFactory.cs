using EpamJobSearchAutomation.Configuration;
using EpamJobSearchAutomation.Framework.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace EpamJobSearchAutomation.Framework
{
    public static class BrowserFactory
    {
        public static IWebDriver CreateDriver()
        {
            var browserSettings = ConfigurationHelper.BrowserSettings;

            IWebDriver driver = browserSettings.Browser switch
            {
                BrowserType.Chrome => CreateChromeDriver(browserSettings),
                BrowserType.Firefox => CreateFirefoxDriver(browserSettings),
                BrowserType.Edge => CreateEdgeDriver(browserSettings),
                _ => throw new ArgumentException(
                    $"Browser '{browserSettings.Browser}' is not supported")
            };

            SetupDriver(driver, browserSettings);

            return driver;
        }

        private static IWebDriver CreateChromeDriver(BrowserSettings settings)
        {
            var options = new ChromeOptions();

            if (settings.Headless)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1920,1080");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--no-sandbox");
            }

            return new ChromeDriver(options);
        }

        private static IWebDriver CreateFirefoxDriver(BrowserSettings settings)
        {
            var options = new FirefoxOptions();

            if (settings.Headless)
            {
                options.AddArgument("--headless");
            }

            return new FirefoxDriver(options);
        }

        private static IWebDriver CreateEdgeDriver(BrowserSettings settings)
        {
            var options = new EdgeOptions();

            if (settings.Headless)
            {
                options.AddArgument("--headless");
            }

            return new EdgeDriver(options);
        }

        private static void SetupDriver(IWebDriver driver,BrowserSettings settings)
        {
            if (!settings.Headless)
            {
                driver.Manage().Window.Maximize();
            }

            driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(settings.ImplicitWaitSeconds);

            driver.Manage().Timeouts().PageLoad =
                TimeSpan.FromSeconds(settings.PageLoadTimeoutSeconds);
        }
    }
}
