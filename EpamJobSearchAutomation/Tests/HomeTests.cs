using EpamJobSearchAutomation.Business.Steps;
using EpamJobSearchAutomation.Tests.Assertions;

namespace EpamJobSearchAutomation.Tests
{
    public class HomeTests : BaseTest
    {
        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void ValidateSearchResultsUsingMagnifierIcon(string searchItem)
        {
            var homeSteps = new HomeSteps(Driver);
            var searchAssertions = new SearchAssertions(Driver);

            homeSteps.SearchFromHomePageByMagnifierIcon(searchItem);

            searchAssertions.ValidateNotAllResultsTitlesContain(searchItem);
        }
    }
}
