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
                var button = waitHelper.WaitUntilClickable(acceptCookiesButton);

                ((IJavaScriptExecutor)driver)
                    .ExecuteScript("arguments[0].click();", button);

                Logger.Info("Cookies accepted");
            }
            catch (Exception ex)
            {
                Logger.Error($"Accept cookies failed: {ex.Message}");
                throw;
            }
        }
    }
}