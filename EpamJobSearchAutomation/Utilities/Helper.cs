using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            wait = new WebDriverWait(driver,
                TimeSpan.FromSeconds(30));
            waitHelper = new WaitHelper(driver);
        }

        public void ScrollToElementAndClick(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
            wait.Until(d => element.Displayed && element.Enabled);
            element.Click();
            waitHelper.WaitForPageLoad();
        }
    }
}
