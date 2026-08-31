using EpamJobSearchAutomation.Business.Enums;
using EpamJobSearchAutomation.Framework.Configuration;
using EpamJobSearchAutomation.Framework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using EpamJobSearchAutomation.Framework.Logging;

namespace EpamJobSearchAutomation.Business.Pages
{
    public class HomePage : BasePage
    {
        private readonly By searchIcon =
            By.XPath("//button[contains(@class,'header-search__button')]");

        private readonly By searchBox =
            By.Id("new_form_search");

        private readonly By findButton =
            By.CssSelector("button.custom-search-button");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            NavigateTo(ConfigurationHelper.ApplicationUrl);

            WaitHelper.WaitForPageLoad();
        }

        public void GoToPageFromMenu(Menu page)
        {
            var locator = By.XPath(page.GetValue());

            Logger.Info($"Opening '{page}' page.");

            WaitHelper.WaitUntilClickable(locator).Click();
            WaitHelper.WaitForPage(page.ToString());
        }


        public void SearchByMagnifierIcon(string keyword)
        {
            var searchButton = WaitHelper.WaitUntilClickable(searchIcon);

            ((IJavaScriptExecutor)Driver).ExecuteScript(
                "arguments[0].click();",
                searchButton);

            WaitHelper.WaitUntilVisible(searchBox).SendKeys(keyword);

            WaitHelper.WaitUntilClickable(findButton).Click();
        }

        public void HoverOverMenu(Menu page)
        {
            var menuLocator = By.XPath(page.GetValue());

            var menuElement = WaitHelper.WaitUntilVisible(menuLocator);

            new Actions(Driver)
                .MoveToElement(menuElement)
                .Perform();
        }
    }
}