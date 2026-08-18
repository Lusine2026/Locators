using OpenQA.Selenium;
using EpamJobSearchAutomation.Framework.Logging;
using EpamJobSearchAutomation.Business.Enums;
using EpamJobSearchAutomation.Business.Pages;

namespace EpamJobSearchAutomation.Business.Steps
{
    public class InsightsSteps
    {
        private readonly HomePage homePage;
        private readonly InsightsPage insightsPage;

        public InsightsSteps(IWebDriver driver)
        {
            homePage = new HomePage(driver);
            insightsPage = new InsightsPage(driver);
        }

        public string OpenInsightsArticle(Menu page, int carouselPosition)
        {
            Logger.Info($"Navigating to '{page}' page.");
            homePage.GoToPageFromMenu(page);

            Logger.Info($"Moving Insights carousel to position {carouselPosition}.");
            insightsPage.SwipeCarousel(carouselPosition);

            string articleTitle = insightsPage.GetArticleTitle();

            Logger.Info($"Opening article '{articleTitle}'.");
            insightsPage.ClickReadMore();

            Logger.Info("Insights article opened.");

            return articleTitle;
        }
    }
}