using EpamJobSearchAutomation.Framework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.Business.Pages
{
    public class ServicesPage : BasePage
    {
        private readonly WebDriverWait _wait;

        private readonly By pageTitle = By.XPath("(//main[@id='main']//div[@class='section'])[1]//span[contains(@class,'gradient-text')]");

        private readonly By relatedExpertiseSection = By.XPath("//main[@id='main']//div[@class='section']//div[@class='text']//span/span[contains(normalize-space(), 'Our Related Expertise')]");

        public ServicesPage(IWebDriver driver) : base(driver)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public void SelectServiceCategory(string category)
        {
            var categoryLink = By.XPath($"//a[contains(@href,'/services')]/..//following-sibling::div//a[normalize-space()='{category}']");

            var element = _wait.Until(driver => driver.FindElements(categoryLink).FirstOrDefault(e => e.Displayed && e.Enabled));

            element!.Click();
        }

        public bool HasCorrectPageTitle(string expectedTitle)
        {
            return _wait.Until(driver => driver.FindElements(pageTitle)
                    .Any(element => element.Displayed && element.Text.Trim().Equals(expectedTitle, StringComparison.OrdinalIgnoreCase)));
        }

        public bool IsRelatedExpertiseDisplayed()
        {
            return _wait.Until(driver => driver.FindElements(relatedExpertiseSection).Any(element => element.Displayed));
        }
    }
}