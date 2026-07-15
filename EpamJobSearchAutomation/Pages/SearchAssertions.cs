using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Pages
{
    public class SearchAssertions : SearchPage
    {
        public SearchAssertions(IWebDriver driver) : base(driver)
        {
        }

        public void ValidateNotAllResultsTitlesContain(string keyword)
        {
            Assert.That(GetResultsTitlesList().All(title => title.Contains(keyword, StringComparison.OrdinalIgnoreCase)),Is.False);
        }
    }
}
