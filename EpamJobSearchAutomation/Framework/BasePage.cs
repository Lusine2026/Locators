using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Framework
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WaitHelper WaitHelper;
        protected readonly ElementHelper ElementHelper;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            WaitHelper = new WaitHelper(driver);
            ElementHelper = new ElementHelper(driver);
        }

        protected void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}