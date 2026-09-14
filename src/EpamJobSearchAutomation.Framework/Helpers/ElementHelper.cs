using OpenQA.Selenium;
using EpamJobSearchAutomation.Framework.Logging;

namespace EpamJobSearchAutomation.Framework.Helpers
{
    public class ElementHelper
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper waitHelper;
        private readonly By preloader = By.CssSelector("[class*='Preloader_fullSize']");

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
                    waitHelper.WaitUntilNotVisible(preloader);
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
            Logger.Info($"Window count: {driver.WindowHandles.Count}");

            if (driver.WindowHandles.Count > 1)
            {
                Logger.Info("PDF opened in a new window/tab.");

                foreach (var window in driver.WindowHandles.ToList())
                {
                    if (window != originalWindow)
                    {
                        driver.SwitchTo().Window(window);
                        driver.Close();
                    }
                }

                driver.SwitchTo().Window(originalWindow);
            }
            else
            {
                Logger.Info("PDF opened in the same browser tab. Navigating back.");
                driver.Navigate().Back();
            }
        }
    }
}
