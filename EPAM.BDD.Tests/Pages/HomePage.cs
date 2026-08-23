using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace EPAM.BDD.Tests.Pages;

public class HomePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    private readonly By _servicesMenu = By.XPath("//span[contains(@class,'top-navigation')]//a[contains(@href,'/services')]");
    private readonly By _searchIcon = By.XPath("//button[contains(@class,'header-search__button')]");
    private readonly By _searchBox = By.Id("new_form_search");
    private readonly By _findButton = By.CssSelector("button.custom-search-button");
    private readonly By _careersMenu = By.XPath("//span[contains(@class,'top-navigation')]//a[contains(@href,'/careers')]");
    
    public HomePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        _driver.Navigate().GoToUrl("https://www.epam.com/");
    }

    public void OpenServicesMenu()
    {
        var servicesMenu = _wait.Until(driver => driver.FindElements(_servicesMenu)
            .FirstOrDefault(element => element.Displayed && element.Enabled));

        new Actions(_driver)
            .MoveToElement(servicesMenu!)
            .Perform();
    }

    public void SearchByMagnifierIcon(string keyword)
    {
        _wait.Until(driver =>
        {
            var element = driver.FindElement(_searchIcon);
            return element.Displayed && element.Enabled ? element : null;
        })!.Click();

        _wait.Until(driver =>
        {
            var element = driver.FindElement(_searchBox);
            return element.Displayed && element.Enabled ? element : null;
        }).SendKeys(keyword);

        _wait.Until(driver =>
        {
            var element = driver.FindElement(_findButton);
            return element.Displayed && element.Enabled ? element : null;
        })!.Click();
    }

    public void OpenCareers()
    {
        var careersMenu = _wait.Until(driver =>
        {
            var element = driver.FindElement(_careersMenu);

            return element.Displayed && element.Enabled
                ? element
                : null;
        });

        careersMenu!.Click();

        _wait.Until(driver => driver.Url.Contains("/careers", StringComparison.OrdinalIgnoreCase));
    }
}
