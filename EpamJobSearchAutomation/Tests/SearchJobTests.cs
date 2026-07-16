using EpamJobSearchAutomation.Base;
using EpamJobSearchAutomation.Pages;
using EpamJobSearchAutomation.Utilities;

namespace EpamJobSearchAutomation.Tests
{
    public class SearchJobTests : BaseTest
    {
        [TestCase("Java", "All available countries")]
        [TestCase("Python", "All available countries")]

        public void ValidateJobSearch(string language, string location)
        {

            var home = new HomePage(Driver);
            var careers = new CareersPage(Driver);
            var jobs = new JobsPage(Driver);
            var jobDetailsPage = new JobDetailsPage(Driver);
            var cookies = new Cookies(Driver);
            var jobDetailsAssertions = new JobDetailsAssertions(Driver);
            var waitHelper = new WaitHelper(Driver);

            home.Open();
            cookies.AcceptCookies();
            home.GoToCareers();
            waitHelper.WaitForPage("careers");

            careers.ClickStartYourSearchHereButton();

            cookies.AcceptCookies();
            jobs.EnterKeyword(language);
            jobs.SelectLocation(location);
            jobs.SelectRemote();
            jobs.ClickSearch();
            jobs.OpenLastJob();

            jobDetailsAssertions.ValidateJobTitleIsNotEmpty();
            jobDetailsAssertions.ValidateJobTitleContains(language);           
        }
    }
}
