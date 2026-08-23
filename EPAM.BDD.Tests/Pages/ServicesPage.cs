using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EPAM.BDD.Tests.Pages;

public class ServicesPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private readonly By _pageTitle = By.XPath("(//main[@id='main']//div[@class='section'])[1]//span[contains(@class,'gradient-text')]");
    private readonly By _relatedExpertiseSection = By.XPath("//main[@id='main']//div[@class='section']//div[@class='text']//span/span[contains(normalize-space(), 'Our Related Expertise')]");

    public ServicesPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public void SelectServiceCategory(string category)
    {
        var categoryLink = By.XPath($"//a[contains(@href,'/services')]/..//following-sibling::div//a[normalize-space()='{category}']");

        var element = _wait.Until(driver => driver.FindElements(categoryLink).FirstOrDefault(e => e.Displayed && e.Enabled));
        var expectedUrl = element!.GetAttribute("href");

        element.Click();

        _wait.Until(driver => driver.Url.Contains(expectedUrl!, StringComparison.OrdinalIgnoreCase));
    }

    public bool HasCorrectPageTitle(string expectedTitle)
        => _wait.Until(driver => driver.FindElements(_pageTitle).Any(element => element.Displayed && element.Text.Trim().Equals(expectedTitle, StringComparison.OrdinalIgnoreCase)));

    public bool IsRelatedExpertiseDisplayed()
        => _wait.Until(driver => driver.FindElements(_relatedExpertiseSection).Any(e => e.Displayed));
}
