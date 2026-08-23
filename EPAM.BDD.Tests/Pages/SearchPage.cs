using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EPAM.BDD.Tests.Pages;

public class SearchPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    private readonly By _resultsTitles = By.CssSelector(".search-results__item a");

    public SearchPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
    }

    public List<string> GetResultsTitles()
    {
        _wait.Until(driver => driver.FindElements(_resultsTitles).Count > 0);

        return _driver
            .FindElements(_resultsTitles)
            .Select(element => element.Text)
            .ToList();
    }
}
