using OpenQA.Selenium;
using EpamJobSearchAutomation.src.Framework.Pages;

namespace EpamJobSearchAutomation.src.Business.Pages
{
    public class CareersPage : BasePage
    {
        private readonly By startYourSearchHere = By.XPath("//div[@class='pinned-button']//div[@data-gtm-category='job_search_redirect']");

        public CareersPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickStartYourSearchHereButton()
            => WaitHelper.WaitUntilClickable(startYourSearchHere).Click();
    }
}