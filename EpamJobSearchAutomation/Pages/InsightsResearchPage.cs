using EpamJobSearchAutomation.Utilities;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Pages
{
    public class InsightsResearchPage
    {
        public InsightsResearchPage(IWebDriver driver)
        {
            this.driver = driver;
            waitHelper = new WaitHelper(driver);
        }

        private readonly IWebDriver driver;
        private readonly WaitHelper waitHelper;
        protected readonly By articleTitle = By.XPath("//h1//span/span");

        public IWebElement ArticleTitle => driver.FindElement(articleTitle);

        public string GetArticleTitle()
        {
            waitHelper.WaitUntilVisible(articleTitle);

            return ArticleTitle.Text;
        }
    }
}
