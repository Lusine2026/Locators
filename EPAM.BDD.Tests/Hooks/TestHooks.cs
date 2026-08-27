using OpenQA.Selenium;
using Reqnroll;

namespace EPAM.BDD.Tests.Hooks;

[Binding]
public class TestHooks
{
    private readonly IWebDriver _driver;

    public TestHooks(IWebDriver driver)
    {
        _driver = driver;
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}