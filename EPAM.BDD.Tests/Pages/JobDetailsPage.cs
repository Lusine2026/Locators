using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EPAM.BDD.Tests.Pages;

public class JobDetailsPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    private readonly By _jobDetailInfo = By.XPath("//span[contains(@class,'JobDetails')]");

    private readonly By _jobTitle = By.TagName("h1");

    public JobDetailsPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
    }

    public string GetJobTitle()
    {
        return _wait.Until(driver =>
        {
            var element = driver.FindElement(_jobTitle);

            return element.Displayed
                ? element.Text
                : null;
        })!;
    }

    public bool IsLanguagePresent(string language)
    {
        var details = _wait.Until(driver =>
        {
            var element = driver.FindElement(_jobDetailInfo);

            return element.Displayed
                ? element
                : null;
        });

        return details!.Text.Contains(language, StringComparison.OrdinalIgnoreCase);
    }
}
