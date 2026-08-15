using OpenQA.Selenium;
using EpamJobSearchAutomation.src.Framework.Browser;
using EpamJobSearchAutomation.src.Framework.Logging;
using EpamJobSearchAutomation.src.Business.Enums;
using EpamJobSearchAutomation.src.Business.Pages;

namespace EpamJobSearchAutomation.src.Business.Steps
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
