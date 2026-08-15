using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.Framework.Helpers
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
                catch (StaleElementReferenceException)
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
                catch (StaleElementReferenceException)
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

        public void WaitUntilNotVisible(By locator)
        {
            wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            });
        }

        public bool WaitUntilValue(By locator, string expectedValue)
        {
            return wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);

                    return element.Displayed &&
                           element.GetAttribute("value")
                               .Equals(expectedValue, StringComparison.OrdinalIgnoreCase);
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });
        }

        public void Click(By locator)
        {
            wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);

                    if (!element.Displayed || !element.Enabled)
                        return false;

                    element.Click();
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (ElementClickInterceptedException)
                {
                    return false;
                }
            });
        }

        public void EnterText(By locator, string text)
        {
            wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);

                    if (!element.Displayed || !element.Enabled)
                        return false;

                    element.Click();
                    element.Clear();
                    element.SendKeys(text);

                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (ElementClickInterceptedException)
                {
                    return false;
                }
            });
        }
    }
}
