using EpamJobSearchAutomation.Framework.Pages;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Business.Pages
{
    public class CookieBanner : BasePage
    {
        private readonly By _acceptCookiesButton =
            By.CssSelector("button#onetrust-accept-btn-handler");

        public CookieBanner(IWebDriver driver) : base(driver)
        {
        }

        public bool AcceptCookies()
        {
            try
            {
                var button = Driver.FindElements(_acceptCookiesButton)
                    .FirstOrDefault(element => element.Displayed && element.Enabled);

                if (button == null)
                {
                    return false;
                }

                ((IJavaScriptExecutor)Driver)
                    .ExecuteScript("arguments[0].click();", button);

                return true;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }
    }
}
