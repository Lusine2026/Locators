using EpamJobSearchAutomation.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.Utilities
{
    public class Cookies : BaseTest
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly By acceptCookiesButton = By.CssSelector("button#onetrust-accept-btn-handler");

        public IWebElement AcceptCookiesButton => driver.FindElement(acceptCookiesButton);

        public Cookies(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        public void AcceptCookies()
        {
            try
            {
                wait.Until(d => AcceptCookiesButton.Displayed && AcceptCookiesButton.Enabled);
                AcceptCookiesButton.Click();
                wait.Until(d =>
                {
                    try
                    {
                        return !AcceptCookiesButton.Displayed;
                    }
                    catch (NoSuchElementException)
                    {
                        return true;
                    }
                });
                wait.Until(d => driver.FindElements(By.CssSelector("[class*='cookie'], [class*='Cookie']")).Count == 0);
            }
            catch
            {
                return;
            }
        }
    }
}
