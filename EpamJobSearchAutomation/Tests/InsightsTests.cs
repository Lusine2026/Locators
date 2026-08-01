using EpamJobSearchAutomation.Base;
using EpamJobSearchAutomation.Enum;
using EpamJobSearchAutomation.Pages;
using EpamJobSearchAutomation.Utilities;

namespace EpamJobSearchAutomation.Tests
{
    public class InsightsTests : BaseTest
    {
        [TestCase(Menu.Insights)]
        public void ValidateArticleTitleOnInsightsResearchPage(Menu page)
        {
            HomePage home = new HomePage(Driver);
            InsightsPage insights = new InsightsPage(Driver);
            InsightsResearchAssertions insightsResearchAssertions = new InsightsResearchAssertions(Driver);
            var cookies = new Cookies(Driver);

            home.Open();
            cookies.AcceptCookies();
            home.GoToPageFromMenu(page);
            insights.SwipeCarousel(2);
            var actualArticleName = insights.GetArticleTitle();
            insights.ClickReadMore();

            insightsResearchAssertions.ValidateArticleTitle(actualArticleName);
        }

       
    }
}
