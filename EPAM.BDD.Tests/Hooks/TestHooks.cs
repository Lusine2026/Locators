using Reqnroll;
using EPAM.BDD.Tests.Drivers;

namespace EPAM.BDD.Tests.Hooks;

[Binding]
public class TestHooks
{
    private readonly WebDriverManager _webDriverManager;

    public TestHooks(WebDriverManager webDriverManager)
    {
        this._webDriverManager = webDriverManager
            ?? throw new InvalidOperationException(
                "WebDriverManager was not injected by Reqnroll.");
    }

    [BeforeScenario]
    public void BeforeScenario()
        => _webDriverManager.Start();

    [AfterScenario]
    public void AfterScenario()
        => _webDriverManager.Stop();
}