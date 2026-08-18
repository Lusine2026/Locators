using OpenQA.Selenium;
using EpamJobSearchAutomation.Framework.Browser;
using EpamJobSearchAutomation.Framework.Logging;
using EpamJobSearchAutomation.Business.Enums;
using EpamJobSearchAutomation.Business.Pages;

namespace EpamJobSearchAutomation.Business.Steps
{
    public class CareersSteps
    {
        private readonly CareersPage careersPage;
        private readonly HomePage homePage;
        private readonly Cookies cookies;

        public CareersSteps(IWebDriver driver)
        {
            careersPage = new CareersPage(driver);
            homePage = new HomePage(driver);
            cookies = new Cookies(driver);
        }

        public void OpenJobSearch(Menu page)
        {
            Logger.Info($"Navigating to '{page}' page.");
            homePage.GoToPageFromMenu(page);

            Logger.Info("Opening job search page.");
            careersPage.ClickStartYourSearchHereButton();

            Logger.Info("Accepting cookies.");
            cookies.AcceptCookies();

            Logger.Info("Job search page opened.");
        }
    }
}
