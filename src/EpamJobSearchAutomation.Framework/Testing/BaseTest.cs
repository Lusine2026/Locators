using EpamJobSearchAutomation.Framework.Browser;
using EpamJobSearchAutomation.Framework.Logging;
using OpenQA.Selenium;
using NUnit.Framework;

public abstract class BaseTest
{
    protected IWebDriver Driver;
    protected Cookies Cookies;

    [SetUp]
    public void Setup()
    {
        Logger.Info($"Starting test: {TestContext.CurrentContext.Test.Name}");

        Driver = BrowserFactory.CreateDriver();
        Cookies = new Cookies(Driver);

        Logger.Info("Browser initialized");
    }

    [TearDown]
    public void TearDown()
    {
        Logger.Info("TearDown started");

        try
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            Logger.Info($"Test result status: {status}");

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Logger.Error($"Test failed: {TestContext.CurrentContext.Test.Name}");

                try
                {
                    TakeScreenshot();
                }
                catch (Exception ex)
                {
                    Logger.Error($"Screenshot error: {ex.Message}");
                }
            }
        }
        finally
        {
            try
            {
                if (Driver != null)
                {
                    Logger.Info("Closing browser...");
                    Driver.Quit();
                    Driver.Dispose();
                    Logger.Info("Browser closed");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Browser closing error: {ex.Message}");
            }
        }
    }

    private void TakeScreenshot()
    {
        if (Driver is ITakesScreenshot screenshotDriver)
        {
            string folder = "Screenshots";

            Directory.CreateDirectory(folder);

            string testName = TestContext.CurrentContext.Test.Name;

            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                testName = testName.Replace(invalidChar, '_');
            }

            string fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string path = Path.Combine(folder, fileName);

            screenshotDriver
                .GetScreenshot()
                .SaveAsFile(path);

            Logger.Error($"Screenshot saved: {path}");
        }
    }
}