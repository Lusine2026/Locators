using EpamJobSearchAutomation.Business.Steps;
using EpamJobSearchAutomation.Business.Enums;
using EpamJobSearchAutomation.Tests.Assertions;

namespace EpamJobSearchAutomation.Tests.Tests
{
    public class InsightsTests : BaseTest
    {
        [TestCase(Menu.Insights)]
        public void ValidateArticleTitleOnInsightsResearchPage(Menu page)
        {
            var homeSteps = new HomeSteps(Driver);
            var insightsSteps = new InsightsSteps(Driver);
            var insightsAssertions = new InsightsResearchAssertions(Driver);

            homeSteps.OpenHomePage();

            string actualArticleTitle = insightsSteps.OpenInsightsArticle(page, 2);

            insightsAssertions.ValidateArticleTitle(actualArticleTitle);
        }
    }
}