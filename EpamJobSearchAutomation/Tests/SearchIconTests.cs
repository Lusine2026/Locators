using EpamJobSearchAutomation.Base;
using EpamJobSearchAutomation.Pages;

namespace EpamJobSearchAutomation.Tests
{
    public class SearchIconTests : BaseTest
    {
        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]

        public void ValidateSearchResults(string searchTerm)
        {
            var home = new Pages.HomePage(Driver);
            var cookies = new Utilities.Cookies(Driver);
            var searchAssertions = new SearchAssertions(Driver);

            home.Open();
            cookies.AcceptCookies();
            home.SearchByMagnifierIcon(searchTerm);
            searchAssertions.ValidateNotAllResultsTitlesContain(searchTerm);
        }
    }
}
