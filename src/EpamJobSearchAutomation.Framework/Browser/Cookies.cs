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
                var button = waitHelper.Until(
                    driver =>
                    {
                        try
                        {
                            var element = driver.FindElement(acceptCookiesButton);

                            return element.Displayed && element.Enabled;
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

                if (!button)
                {
                    Logger.Info("Cookie banner not displayed. Continuing without accepting cookies.");
                    return;
                }

                var cookieButton = driver.FindElement(acceptCookiesButton);

                ((IJavaScriptExecutor)driver)
                    .ExecuteScript("arguments[0].click();", cookieButton);

                Logger.Info("Cookies accepted");
            }
            catch (Exception ex)
            {
                Logger.Info("Cookies button was not found. Continuing without accepting cookies.");
            }
        }

    }
}