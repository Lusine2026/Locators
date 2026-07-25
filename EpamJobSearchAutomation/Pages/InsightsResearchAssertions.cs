using EpamJobSearchAutomation.Utilities;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Pages
{
    internal class InsightsResearchAssertions : InsightsResearchPage
    {
        private readonly WaitHelper waitHelper;

        public InsightsResearchAssertions(IWebDriver driver) : base(driver)
        {
            waitHelper = new WaitHelper(driver);
        }

        public void ValidateArticleTitle(string actualTitle)
        {
            waitHelper.WaitForElement(articleTitle);
            var expectedTitle = GetArticleTitle();
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Expected title '{expectedTitle}' but found '{actualTitle}'.");
        }
    }
}
