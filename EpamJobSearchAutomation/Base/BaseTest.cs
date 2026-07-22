using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using EpamJobSearchAutomation.Configuration;

namespace EpamJobSearchAutomation.Base
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            var browserSettings = ConfigurationHelper.BrowserSettings;

            var options = new ChromeOptions();

            if (browserSettings.Headless)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1920,1080");
            }

            Driver = new ChromeDriver(options);

            if (!browserSettings.Headless)
            {
                Driver.Manage().Window.Maximize();
            }

            Driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(browserSettings.ImplicitWaitSeconds);

            Driver.Manage().Timeouts().PageLoad =
                TimeSpan.FromSeconds(browserSettings.PageLoadTimeoutSeconds);
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

                screenshot.SaveAsFile(
                    "headless-failure.png"
                );

                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}