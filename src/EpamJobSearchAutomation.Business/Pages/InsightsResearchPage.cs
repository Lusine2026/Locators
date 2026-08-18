using EpamJobSearchAutomation.Framework.Pages;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Business.Pages
{
    public class InsightsResearchPage : BasePage
    {
        private readonly By articleTitle = By.XPath("//h1//span/span");

        public InsightsResearchPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ArticleTitle => WaitHelper.WaitUntilVisible(articleTitle);

        public string GetArticleTitle()
            => ArticleTitle.Text;
    }
}
