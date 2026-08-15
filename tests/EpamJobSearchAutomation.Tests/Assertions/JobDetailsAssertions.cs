using EpamJobSearchAutomation.Business.Pages;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Tests.Assertions
{
    public class JobDetailsAssertions
    {
        private readonly JobDetailsPage jobDetailsPage;

        public JobDetailsAssertions(IWebDriver driver)
        {
            jobDetailsPage = new JobDetailsPage(driver);
        }

        public void ValidateJobTitleContains(string keyword)
        {
            Assert.That(jobDetailsPage.IsLanguagePresent(keyword), Is.True, $"Language '{keyword}' was NOT found on job details page.");
        }

        public void ValidateJobTitleIsNotEmpty()
        {
            Assert.That(string.IsNullOrEmpty(jobDetailsPage.GetJobTitle()), Is.False, "Job title is empty.");
        }
    }
}