using EpamJobSearchAutomation.Business.Enums;
using EpamJobSearchAutomation.Configuration;
using EpamJobSearchAutomation.Framework;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Business.Pages
{
    public class HomePage : BasePage
    {
        private readonly By searchIcon = By.XPath("//button[contains(@class,'header-search__button')]");
        private readonly By searchBox = By.Id("new_form_search");
        private readonly By findButton = By.CssSelector("button.custom-search-button");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            NavigateTo(ConfigurationHelper.ApplicationUrl);
        }

        public void GoToPageFromMenu(Menu page)
        {
            WaitHelper.WaitUntilClickable(By.XPath(page.GetValue())).Click();
            WaitHelper.WaitForPage(page.ToString());
        }

        public void SearchByMagnifierIcon(string keyword)
        {
            WaitHelper.WaitUntilClickable(searchIcon).Click();
            WaitHelper.WaitUntilVisible(searchBox).SendKeys(keyword);
            WaitHelper.WaitUntilClickable(findButton).Click();
        }
    }
}
