using EpamJobSearchAutomation.Business.Pages;
using EpamJobSearchAutomation.Framework.Helpers;
using EpamJobSearchAutomation.Framework.Logging;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Business.Steps
{
    public class JobsSteps
    {
        private readonly JobsPage jobsPage;

        public JobsSteps(IWebDriver driver)
        {
            jobsPage = new JobsPage(driver);
        }

        public void SearchForJob(string keyword, string location)
        {
            Logger.Info($"Selecting location '{location}'.");
            jobsPage.SetLocation(location);

            Logger.Info($"Entering job keyword '{keyword}'.");
            jobsPage.EnterKeyword(keyword);

            Logger.Info("Selecting Remote work option.");
            jobsPage.SelectRemote();

            Logger.Info("Starting job search.");
            jobsPage.ClickSearch();

            Logger.Info("Job search completed successfully.");
        }

        public void OpenLatestJob()
        {
            Logger.Info("Opening the latest job from search results.");
            jobsPage.OpenLastJob();

            Logger.Info("Latest job opened successfully.");
        }

        public void SearchAndOpenLatestJob(string keyword, string location)
        {
            Logger.Info("Starting job search workflow.");

            SearchForJob(keyword, location);
            OpenLatestJob();

            Logger.Info("Job search workflow completed.");
        }
    }
}