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
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--start-maximized");

            Driver = new ChromeDriver(options);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

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