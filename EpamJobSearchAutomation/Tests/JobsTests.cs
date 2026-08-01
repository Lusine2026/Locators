using EpamJobSearchAutomation.Business.Enums;
using EpamJobSearchAutomation.Business.Steps;
using EpamJobSearchAutomation.Tests.Assertions;

namespace EpamJobSearchAutomation.Tests
{
    public class JobsTests : BaseTest
    {
        [TestCase("Java", "All available countries", Menu.Careers)]
        [TestCase("Python", "All available countries", Menu.Careers)]
        public void ValidateJobSearch(string language, string location, Menu page)
        {
            var homeSteps = new HomeSteps(Driver);
            var careersSteps = new CareersSteps(Driver);
            var jobsSteps = new JobsSteps(Driver);

            var jobDetailsAssertions = new JobDetailsAssertions(Driver);

            homeSteps.OpenHomePage();
            careersSteps.OpenJobSearch(page);

            jobsSteps.SearchAndOpenLatestJob(language, location);

            jobDetailsAssertions.ValidateJobTitleIsNotEmpty();
            jobDetailsAssertions.ValidateJobTitleContains(language);
        }
    }
}
