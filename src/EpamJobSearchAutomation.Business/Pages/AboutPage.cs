using EpamJobSearchAutomation.Business.Enums;
using EpamJobSearchAutomation.Framework.Pages;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Business.Pages
{
    public class AboutPage : BasePage
    {
        public AboutPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickPolicyLink(Policies policy)
        {
            string locator = policy.GetValue();
            ElementHelper.ScrollToElementAndClick(By.XPath(locator));
        }
    }
}
