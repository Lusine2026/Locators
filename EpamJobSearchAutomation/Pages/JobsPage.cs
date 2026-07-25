using EpamJobSearchAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace EpamJobSearchAutomation.Pages
{
    public class JobsPage
    {
        public JobsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            helper = new Helper(driver);
            waitHelper = new WaitHelper(driver);
        }

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly Helper helper;
        private readonly WaitHelper waitHelper;
        private readonly By searchBox = By.Id("anchor-list");
        private readonly By searchByKeyword = By.XPath("//input[@aria-label='search']");
        private readonly By keyword = By.Name("keyword");
        private readonly By locationDropdown = By.CssSelector("#react-select-2-input");
        private readonly By remoteCheckbox = By.XPath("//div[contains(@class,'List_sideMenu')]//input[contains(@id,'checkbox-vacancy_type-Remote')]");
        private readonly By remoteCheckboxLabel = By.XPath("//label[contains(.,'Remote')]");
        private readonly By searchButton = By.CssSelector("button[name='submit_search_box_button']");
        private readonly By searchResults = By.XPath("//div[contains(@class,'AccordionSection_withDataAttributes')]");
        private readonly By searchInputXPathOperator = By.XPath("//input[@type='text' and @name='keyword']");
        private readonly By latestJobAxes = By.XPath("(//a[contains(text(),'View')])[last()]/ancestor::li");
        private readonly By jobCards = By.XPath("//div[@data-testid='accordion-section-container']//a[@data-testid='job-card-link']");
        private readonly By lastJobCard = By.XPath("(//div[@data-testid='accordion-section-container']//a[@data-testid='job-card-link'])[last()]");

        public IWebElement SearchBox => driver.FindElement(searchBox);
        public IWebElement SearchByKeyword => driver.FindElement(searchByKeyword);
        public IWebElement Keyword => driver.FindElement(keyword);
        public IWebElement LocationDropdown => driver.FindElement(locationDropdown);
        public IWebElement RemoteCheckbox => driver.FindElement(remoteCheckbox);
        public IWebElement RemoteCheckboxLabel => driver.FindElement(remoteCheckboxLabel);
        public IWebElement SearchButton => driver.FindElement(searchButton);
        public IWebElement SearchInputXPathOperator => driver.FindElement(searchInputXPathOperator);
        public IWebElement LatestJobAxes => driver.FindElement(latestJobAxes);
        public IWebElement JobTitle => driver.FindElement(latestJobAxes);
        public IWebElement LastJobCard => driver.FindElement(lastJobCard);
        public ReadOnlyCollection<IWebElement> SearchResults => driver.FindElements(searchResults);
        public ReadOnlyCollection<IWebElement> JobCards => driver.FindElements(jobCards);

        public void EnterKeyword(string keyword)
        {
            wait.Until(d => SearchByKeyword.Displayed && SearchByKeyword.Enabled);

            SearchByKeyword.Clear();
            SearchByKeyword.SendKeys(keyword);
        }

        public IWebElement KeywordFieldByName()
            => Keyword;

        public void SelectLocation(string location)
        {
            wait.Until(d => LocationDropdown.Displayed && LocationDropdown.Enabled);
            LocationDropdown.SendKeys(location);
        }

        public void SelectRemote()
        {
            wait.Until(d => RemoteCheckboxLabel.Displayed);
            RemoteCheckboxLabel.Click();
        }

        public void ClickSearch()
        {
            wait.Until(d => SearchButton.Displayed && SearchButton.Enabled);
            SearchButton.Click();
            waitHelper.WaitForJobResults();
            driver.Navigate().Refresh();
        }

        public IReadOnlyCollection<IWebElement> GetResults()
            => driver.FindElements(searchResults);

        public void OpenLastJob()
        {
            var jobs = driver.FindElements(jobCards);
            var lastJob = jobs.Last();
            helper.ScrollToElementAndClick(lastJobCard);
            waitHelper.WaitForPage("vacancy");
        }

        public IWebElement SearchInputUsingXPathOperator()
            => SearchInputXPathOperator;

        public String GetLatestJobUsingAxes()
            => LatestJobAxes.Text;
    }
}
