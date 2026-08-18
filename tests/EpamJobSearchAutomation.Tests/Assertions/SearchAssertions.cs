using EpamJobSearchAutomation.Business.Pages;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Tests.Assertions
{
    public class SearchAssertions
    {
        private readonly SearchPage searchPage;
        public SearchAssertions(IWebDriver driver)
        {
            searchPage = new SearchPage(driver);
        }

        public void ValidateNotAllResultsTitlesContain(string keyword)
            => Assert.That(searchPage.GetResultsTitlesList().All(title => title.Contains(keyword, StringComparison.OrdinalIgnoreCase)),Is.False);
    }
}
