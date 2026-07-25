using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.Utilities
{
    public class Helper
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly WaitHelper waitHelper;

        public Helper(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(driver,TimeSpan.FromSeconds(50));
            waitHelper = new WaitHelper(driver);
        }

        public void ScrollToElementAndClick(By locator)
        {
            int attempts = 0;

            while (attempts < 3)
            {
                try
                {
                    wait.Until(driver =>
                    {
                        try
                        {
                            return driver.FindElement(locator);
                        }
                        catch (NoSuchElementException)
                        {
                            return null;
                        }
                    });

                    IWebElement element = driver.FindElement(locator);

                    ((IJavaScriptExecutor)driver)
                        .ExecuteScript(
                            "arguments[0].scrollIntoView({block:'center', inline:'nearest'});",
                            element);

                    element = driver.FindElement(locator);

                    wait.Until(driver =>
                    {
                        try
                        {
                            return driver.FindElement(locator);
                        }
                        catch (NoSuchElementException)
                        {
                            return null;
                        }
                    });

                    element.Click();

                    waitHelper.WaitForPageLoad();

                    return;
                }
                catch (StaleElementReferenceException)
                {
                    attempts++;
                }
            }

            throw new Exception($"Unable to click element after retries: {locator}");
        }

        public void ClosePdfWindow(string originalWindow)
        {
            if (driver.WindowHandles.Count > 1)
            {
                foreach (string window in driver.WindowHandles)
                {
                    if (window != originalWindow)
                    {
                        driver.SwitchTo().Window(window);
                        driver.Close();
                        break;
                    }
                }
                driver.SwitchTo().Window(originalWindow);
            }
        }
    }
}
