using EpamJobSearchAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.Pages
{
    public class JobDetailsAssertions : JobDetailsPage
    {
        private readonly WaitHelper waitHelper;
        private readonly IWebDriver driver;

        public JobDetailsAssertions(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            waitHelper = new WaitHelper(driver);
        }

        public void ValidateJobTitleContains(string keyword)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => IsLanguagePresent(keyword));
            Assert.That(IsLanguagePresent(keyword), Is.True, $"Language '{keyword}' was NOT found on job details page.");
        }

        public void ValidateJobTitleIsNotEmpty()
        {
            waitHelper.WaitForElement(jobDetailInfo);
            Assert.That(!string.IsNullOrEmpty(GetJobTitle()), "Job title is empty.");
        }
    }
}
