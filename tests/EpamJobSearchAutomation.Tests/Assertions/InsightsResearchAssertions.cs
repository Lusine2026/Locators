using EpamJobSearchAutomation.Business.Pages;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Tests.Assertions
{
    public class InsightsResearchAssertions
    {
        private readonly InsightsResearchPage insightsResearchPage;

        public InsightsResearchAssertions(IWebDriver driver)
        {
            insightsResearchPage = new InsightsResearchPage(driver);
        }

        public void ValidateArticleTitle(string actualTitle)
        {
            var expectedTitle = insightsResearchPage.GetArticleTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Expected title '{expectedTitle}' but found '{actualTitle}'.");
        }
    }
}
