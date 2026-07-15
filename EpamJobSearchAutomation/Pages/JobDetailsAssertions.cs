using EpamJobSearchAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamJobSearchAutomation.Pages
{
    public class JobDetailsAssertions : JobDetailsPage
    {
        private readonly WaitHelper waitHelper;

        public JobDetailsAssertions(IWebDriver driver) : base(driver)
        {
            waitHelper = new WaitHelper(driver);
        }

        public void ValidateJobTitleContains(string keyword)
        {
            waitHelper.WaitForElement(jobDetailInfo);
            Assert.That(IsLanguagePresent(keyword), Is.True, $"Language '{keyword}' was NOT found on job details page.");
        }

        public void ValidateJobTitleIsNotEmpty()
        {
            Assert.That(!string.IsNullOrEmpty(GetJobTitle()), "Job title is empty.");
        }
    }
}
