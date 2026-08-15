using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.src.Framework.Helpers
{
    public class WaitHelper
    {
        private readonly WebDriverWait wait;

        public WaitHelper(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public IWebElement WaitUntilVisible(By locator)
        {
            return wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }

        public IWebElement WaitUntilClickable(By locator)
        {
            return wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);

                    return element.Displayed && element.Enabled
                        ? element
                        : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }

        public void WaitUntilPageContains(string text)
        {
            wait.Until(driver =>
                driver.PageSource.Contains(text));
        }

        public void WaitForPage(string urlText)
        {
            wait.Until(driver =>
                driver.Url.Contains(urlText, StringComparison.OrdinalIgnoreCase));
        }

        public void WaitForPageLoad()
        {
            wait.Until(d =>
            {
                if (d is IJavaScriptExecutor jsExecutor)
                {
                    return jsExecutor.ExecuteScript("return document.readyState")?.Equals("complete") == true;
                }
                return false;
            });
        }

        public string WaitForDownload(string expectedFileName)
        {
            string downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"Downloads");

            wait.Until(_ => Directory.GetFiles(downloadFolder).Any(f => Path.GetFileName(f).Contains(expectedFileName) &&
                !f.EndsWith(".crdownload", StringComparison.OrdinalIgnoreCase)));

            return Directory.GetFiles(downloadFolder).First(f => Path.GetFileName(f).Contains(expectedFileName) &&
            !f.EndsWith(".crdownload", StringComparison.OrdinalIgnoreCase));
        }

        public bool Until(Func<IWebDriver, bool> condition)
        {
            return wait.Until(condition);
        }
    }
}
