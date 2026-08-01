using EpamJobSearchAutomation.Base;
using EpamJobSearchAutomation.Enum;
using EpamJobSearchAutomation.Pages;
using EpamJobSearchAutomation.Utilities;

namespace EpamJobSearchAutomation.Tests
{
    public class SearchJobTests : BaseTest
    {
        [TestCase("Java", "All available countries", Menu.Careers)]
        [TestCase("Python", "All available countries",Menu.Careers)]
        public void ValidateJobSearch(string language, string location, Menu page)
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
            home.GoToPageFromMenu(page);

            careers.ClickStartYourSearchHereButton();

            cookies.AcceptCookies();
            jobs.EnterKeyword(language);
            jobs.SelectLocation(location: location);
            jobs.SelectRemote();
            jobs.ClickSearch();
            jobs.OpenLastJob();

            jobDetailsAssertions.ValidateJobTitleIsNotEmpty();
            jobDetailsAssertions.ValidateJobTitleContains(language);           
        }
    }
}
