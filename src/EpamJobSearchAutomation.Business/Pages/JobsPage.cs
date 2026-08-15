using EpamJobSearchAutomation.Framework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace EpamJobSearchAutomation.Business.Pages
{
    public class JobsPage : BasePage
    {
        public JobsPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly By searchByKeyword = By.XPath("//input[@aria-label='search']");
        private readonly By keyword = By.Name("keyword");
        private readonly By locationDropdown = By.XPath("//div[@data-testid='country-dropdown']//input");
        private readonly By remoteCheckboxLabel = By.XPath("//label[contains(.,'Remote')]");
        private readonly By searchButton = By.CssSelector("button[name='submit_search_box_button']");
        private readonly By searchInputXPathOperator = By.XPath("//input[@type='text' and @name='keyword']");
        private readonly By latestJobAxes = By.XPath("(//a[contains(text(),'View')])[last()]/ancestor::li");
        private readonly By jobCards = By.XPath("//div[@data-testid='accordion-section-container']//a[@data-testid='job-card-link']");
        private readonly By lastJobCard = By.XPath("(//div[@data-testid='accordion-section-container']//a[@data-testid='job-card-link'])[last()]");
        private readonly By jobResults = By.XPath("//a[@data-testid='job-card-link']");
        private readonly By preloader = By.CssSelector("[class*='Preloader_fullSize']");
        private readonly By allCountriesSelected = By.XPath("//div[@data-testid='dropdown-option'][@aria-selected='true'][.//span[normalize-space()='All available countries']]");
        private readonly By clearLocationButton = By.XPath("//div[@data-testid='country-dropdown']//div[contains(@class,'Dropdown_clearIcon')]");

        public IWebElement Keyword => Driver.FindElement(keyword);
        public IWebElement RemoteCheckboxLabel => Driver.FindElement(remoteCheckboxLabel);
        public IWebElement SearchInputXPathOperator => Driver.FindElement(searchInputXPathOperator);
        public IWebElement LatestJobAxes => Driver.FindElement(latestJobAxes);

        public void EnterKeyword(string keyword)
        {
            WaitHelper.EnterText(searchByKeyword, keyword);

            WaitHelper.WaitUntilValue(searchByKeyword, keyword);
        }

        public void SetLocation(string location)
        {
            if (location.Equals(
                "All available countries",
                StringComparison.OrdinalIgnoreCase))
            {
                ClearSelectedLocation();
                return;
            }

            ClearSelectedLocation();

            var input = WaitHelper.WaitUntilClickable(locationDropdown);
            input.Click();
            input.SendKeys(location);

            var option = WaitHelper.WaitUntilVisible(
                By.XPath(
                    $"//div[@data-testid='dropdown-option']" +
                    $"[.//span[normalize-space()='{location}']]"
                )
            );

            option.Click();
            WaitHelper.WaitUntilNotVisible(preloader);
        }

        public void SelectRemote()
        {
            WaitHelper.WaitUntilVisible(remoteCheckboxLabel);
            ElementHelper.ScrollToElementAndClick(remoteCheckboxLabel);
        }

        public void ClickSearch()
        {
            WaitHelper.WaitUntilNotVisible(preloader);
            WaitHelper.WaitUntilClickable(searchButton).Click();
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
            WaitHelper.WaitUntilNotVisible(preloader);
            WaitHelper.WaitForPage("vacancy");
        }

        public void WaitForJobResults()
        {
            WaitHelper.WaitUntilNotVisible(preloader);
            WaitHelper.WaitUntilVisible(jobResults);
        }

        private void ClearSelectedLocation()
        {
            var clearButtons = Driver.FindElements(clearLocationButton);

            if (clearButtons.Any(b => b.Displayed))
            {
                clearButtons.First(b => b.Displayed).Click();
            }
        }
    }
}
