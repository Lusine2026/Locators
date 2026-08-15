using EpamJobSearchAutomation.Business.Pages;
using EpamJobSearchAutomation.Framework.Browser;
using EpamJobSearchAutomation.Framework.Logging;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Business.Steps
{
    public class HomeSteps
    {
        private readonly HomePage homePage;
        private readonly Cookies cookies;

        public HomeSteps(IWebDriver driver)
        {
            homePage = new HomePage(driver);
            cookies = new Cookies(driver);
        }

        public void SearchFromHomePageByMagnifierIcon(string keyword)
        {
            Logger.Info("Opening EPAM home page.");
            homePage.Open();

            Logger.Info("Accepting cookies.");
            cookies.AcceptCookies();

            Logger.Info($"Searching for '{keyword}' using the search icon.");
            homePage.SearchByMagnifierIcon(keyword);

            Logger.Info("Search completed.");
        }

        public void OpenHomePage()
        {
            Logger.Info("Opening EPAM home page.");
            homePage.Open();

            Logger.Info("Accepting cookies.");
            cookies.AcceptCookies();

            Logger.Info("Home page opened.");
        }
    }
}