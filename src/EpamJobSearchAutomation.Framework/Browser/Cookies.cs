using EpamJobSearchAutomation.Framework.Helpers;
using EpamJobSearchAutomation.Framework.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.Framework.Browser
{
    public class Cookies
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper waitHelper;

        private readonly By acceptCookiesButton = By.CssSelector("button#onetrust-accept-btn-handler");
        private readonly By preloader = By.CssSelector("[class*='Preloader_fullSize']");

        public Cookies(IWebDriver driver)
        {
            this.driver = driver;
            waitHelper = new WaitHelper(driver);
        }

        public void AcceptCookies()
        {
            Logger.Info("Accepting cookies");

            try
            {
                waitHelper.Until(
                    d =>
                    {
                        try
                        {
                            var element = d.FindElement(acceptCookiesButton);

                            if (!element.Displayed || !element.Enabled)
                                return false;

                            ((IJavaScriptExecutor)d)
                                .ExecuteScript("arguments[0].click();", element);

                            return true;
                        }
                        catch (NoSuchElementException)
                        {
                            return false;
                        }
                        catch (StaleElementReferenceException)
                        {
                            return false;
                        }
                    },
                    TimeSpan.FromSeconds(5));

                Logger.Info("Cookies accepted");
            }
            catch (WebDriverTimeoutException)
            {
                Logger.Info("Cookies button was not found. Continuing without accepting cookies.");
            }
        }
    }
}