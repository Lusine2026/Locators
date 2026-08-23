using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EPAM.BDD.Tests.Pages;

public class CareersPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    private readonly By _startYourSearchHere = By.XPath("//div[@class='pinned-button']//div[@data-gtm-category='job_search_redirect']");

    public CareersPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public void ClickStartYourSearchHereButton()
    {
        _wait.Until(driver =>
        {
            var element = driver.FindElement(_startYourSearchHere);

            return element.Displayed && element.Enabled
                ? element
                : null;
        })!.Click();
    }
}
