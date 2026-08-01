using EpamJobSearchAutomation.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.Business.Pages
{
    public class JobsPage : BasePage
    {
        public JobsPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly By searchByKeyword = By.XPath("//input[@aria-label='search']");
        private readonly By keyword = By.Name("keyword");
        private readonly By locationDropdown = By.CssSelector("#react-select-2-input");
        private readonly By remoteCheckboxLabel = By.XPath("//label[contains(.,'Remote')]");
        private readonly By searchButton = By.CssSelector("button[name='submit_search_box_button']");
        private readonly By searchInputXPathOperator = By.XPath("//input[@type='text' and @name='keyword']");
        private readonly By latestJobAxes = By.XPath("(//a[contains(text(),'View')])[last()]/ancestor::li");
        private readonly By jobCards = By.XPath("//div[@data-testid='accordion-section-container']//a[@data-testid='job-card-link']");
        private readonly By lastJobCard = By.XPath("(//div[@data-testid='accordion-section-container']//a[@data-testid='job-card-link'])[last()]");
        private readonly By jobResults = By.XPath("//a[@data-testid='job-card-link']");

        public IWebElement Keyword => Driver.FindElement(keyword);
        public IWebElement RemoteCheckboxLabel => Driver.FindElement(remoteCheckboxLabel);
        public IWebElement SearchInputXPathOperator => Driver.FindElement(searchInputXPathOperator);
        public IWebElement LatestJobAxes => Driver.FindElement(latestJobAxes);

        public void EnterKeyword(string keyword)
        {
            var element = WaitHelper.WaitUntilClickable(searchByKeyword);

            element.Clear();
            element.SendKeys(keyword);
        }

        public void SelectLocation(string location)
        {
            var element = WaitHelper.WaitUntilClickable(locationDropdown);
            element.SendKeys(location);
        }

        public void SelectRemote()
        {
            WaitHelper.WaitUntilVisible(remoteCheckboxLabel);
            ElementHelper.ScrollToElementAndClick(remoteCheckboxLabel);
        }

        public void ClickSearch()
        {
            var element = WaitHelper.WaitUntilClickable(searchButton);
            element.Click();
            WaitForJobResults();
            Driver.Navigate().Refresh();
        }

        public void OpenLastJob()
        {
            var jobs = Driver.FindElements(jobCards);

            if (!jobs.Any())
            {
                throw new Exception("No job cards found");
            }

            ElementHelper.ScrollToElementAndClick(lastJobCard);
            WaitHelper.WaitForPage("vacancy");
        }

        public void WaitForJobResults()
        {
            WaitHelper.Until(driver => driver.FindElements(jobResults).Count > 0);
        }
    }
}
