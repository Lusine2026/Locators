using EpamJobSearchAutomation.Business.Pages;
using OpenQA.Selenium;
using EpamJobSearchAutomation.Framework;
using EpamJobSearchAutomation.Business.Enums;

namespace EpamJobSearchAutomation.Business.Steps
{
    public class AboutSteps
    {
        private readonly HomePage homePage;
        private readonly AboutPage aboutPage;

        public AboutSteps(IWebDriver driver)
        {
            homePage = new HomePage(driver);
            aboutPage = new AboutPage(driver);
        }

        public string DownloadPolicyDocument(Menu page, Policies policy)
        {
            Logger.Info($"Opening '{page}' page.");
            homePage.GoToPageFromMenu(page);

            Logger.Info($"Opening '{policy}' policy document.");
            aboutPage.ClickPolicyLink(policy);

            Logger.Info("Policy document opened.");

            return policy.ToString();
        }
    }
}
