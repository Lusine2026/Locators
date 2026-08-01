using EpamJobSearchAutomation.Enum;
using EpamJobSearchAutomation.Utilities;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Pages
{
    public class AboutPage
    {
        public AboutPage(IWebDriver driver)
        {     
            helper = new Helper(driver);          
        }

        private readonly Helper helper;

        public void ClickPolicyLink(Policies policy)
        {
            string locator = policy.GetValue();
            helper.ScrollToElementAndClick(By.XPath(locator));
        }
    }
}
