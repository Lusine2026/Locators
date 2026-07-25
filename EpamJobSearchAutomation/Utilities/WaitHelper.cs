using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.Utilities
{
    public class WaitHelper
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly By jobResults = By.XPath("//a[@data-testid='job-card-link']");
        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public IWebElement WaitUntilVisible(By locator)
        {
            return wait.Until(d =>
            {
                IWebElement element = d.FindElement(locator);

                return element.Displayed
                    ? element
                    : null;
            });
        }

        public IWebElement WaitUntilClickable(By locator)
        {
            return wait.Until(d =>
            {
                IWebElement element = d.FindElement(locator);

                return (element.Displayed && element.Enabled)
                    ? element
                    : null;
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
                driver.Url.ToLower().Contains(urlText));
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

        public void WaitForElement(By locator)
        {
            wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return element.Displayed && element.Enabled;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return element.Size.Height > 0 && element.Size.Width > 0;
                }
                catch
                {
                    return false;
                }
            });
        }

        public IWebElement WaitForFirstElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));

            return wait.Until(d =>
            {
                var elements = d.FindElements(locator);
                return elements.FirstOrDefault();
            });
        }

        public string WaitForDownload(string expectedFileName)
        {
            string downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"Downloads");
            wait.Until(_ => Directory.GetFiles(downloadFolder).Any(f => Path.GetFileName(f).Contains(expectedFileName)));
            return Directory.GetFiles(downloadFolder).First(f => Path.GetFileName(f).Contains(expectedFileName));
        }

        public void WaitForJobResults()
        {
            wait.Until(d => d.FindElements(jobResults).Count > 0);
        }
    }
}
