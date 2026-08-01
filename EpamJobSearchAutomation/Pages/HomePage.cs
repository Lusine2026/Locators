using EpamJobSearchAutomation.Enum;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly By careersLink = By.LinkText("Careers");
        private readonly By careerLink = By.PartialLinkText("Career");
        private readonly By searchIcon = By.XPath("//button[contains(@class,'header-search__button')]");
        private readonly By searchBox = By.Id("new_form_search");
        private readonly By findButton = By.CssSelector("button.custom-search-button");

        public IWebElement CareersLink => driver.FindElement(careersLink);
        public IWebElement CareerLink => driver.FindElement(careerLink);
        public IWebElement SearchIcon => driver.FindElement(searchIcon);
        public IWebElement SearchBox => driver.FindElement(searchBox);
        public IWebElement FindButton => driver.FindElement(findButton);

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");
        }

        public void GoToPageFromMenu(Menu page)
        {
            driver.FindElement(By.XPath(page.GetValue())).Click();
            wait.Until(d => d.Url.Contains(page.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        public void GoToCareersUsingPartialText()
        {
            wait.Until(d => CareerLink.Displayed && CareerLink.Enabled);
            CareerLink.Click();
        }

        public void SearchByMagnifierIcon(string keyword)
        {
            wait.Until(d => SearchIcon.Displayed && SearchIcon.Enabled);
            SearchIcon.Click();
            wait.Until(d => SearchBox.Displayed && SearchIcon.Enabled);
            SearchBox.SendKeys(keyword);
            FindButton.Click();
        }
    }
}
