using OpenQA.Selenium;

namespace EpamJobSearchAutomation.src.Framework.Helpers
{
    public class ElementHelper
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper waitHelper;

        public ElementHelper(IWebDriver driver)
        {
            this.driver = driver;
            waitHelper = new WaitHelper(driver);
        }

        public void ScrollToElementAndClick(By locator)
        {
            int attempts = 0;

            while (attempts < 3)
            {
                try
                {
                    var element = waitHelper.WaitUntilClickable(locator);

                    ((IJavaScriptExecutor)driver).ExecuteScript(
                        "arguments[0].scrollIntoView({block:'center', inline:'nearest'});",
                        element);

                    element = waitHelper.WaitUntilClickable(locator);
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
                foreach (var window in driver.WindowHandles)
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
