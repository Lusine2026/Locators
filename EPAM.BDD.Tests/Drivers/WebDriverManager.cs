using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EPAM.BDD.Tests.Drivers;

public class WebDriverManager
{
    public IWebDriver Driver { get; private set; } = null!;

    public void Start()
    {
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
    }

    public void Stop()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}
