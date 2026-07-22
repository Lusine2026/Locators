using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.Utilities
{
    public class WaitHelper
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(driver,
                TimeSpan.FromSeconds(50));
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

        public void WaitForPage(string menuTab)
        {
            wait.Until(driver =>
                driver.Url.ToLower().Contains(menuTab));
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

            wait.Until(d =>
            {
                try
                {
                    return d.FindElement(locator).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public IWebElement WaitForFirstElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            return wait.Until(d =>
            {
                var elements = d.FindElements(locator);
                return elements.FirstOrDefault();
            });
        }
    }
}
