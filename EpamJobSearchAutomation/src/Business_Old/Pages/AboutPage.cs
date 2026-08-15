using EpamJobSearchAutomation.src.Business.Enums;
using EpamJobSearchAutomation.src.Framework.Pages;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.src.Business.Pages
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
