using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EPAM.BDD.Tests.Pages;

public class CookieBanner
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    private readonly By _acceptCookiesButton = By.CssSelector("button#onetrust-accept-btn-handler");

    public CookieBanner(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
    }

    public bool AcceptCookies()
    {
        try
        {
            var button = _wait.Until(driver =>
            {
                var element = driver.FindElements(_acceptCookiesButton)
                    .FirstOrDefault(e => e.Displayed && e.Enabled);

                return element;
            });

            if (button == null)
            {
                return false;
            }

            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].click();", button);

            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}