using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EpamJobSearchAutomation.Base
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();

            // Browser-specific capability
            options.AddArgument("--start-maximized");

            Driver = new ChromeDriver(options);

            // WebDriver browser interaction
            Driver.Manage().Window.Maximize();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}