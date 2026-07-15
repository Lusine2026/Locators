using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace EpamJobSearchAutomation.Pages
{
    public class CareersPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly By startYourSearchHere = By.XPath("//div[@class='pinned-button']//div[@data-gtm-category='job_search_redirect']");

        public IWebElement StartYourSearchHere => driver.FindElement(startYourSearchHere);

        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public void ClickStartYourSearchHereButton()
        {
            wait.Until(d => StartYourSearchHere.Displayed && StartYourSearchHere.Enabled);
            StartYourSearchHere.Click();
        }

        public void WaitForPage()
        {
            wait.Until(d => d.Url.Contains("careers"));
        }
    }
}