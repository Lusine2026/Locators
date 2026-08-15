using EpamJobSearchAutomation.src.Framework.Pages;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace EpamJobSearchAutomation.src.Business.Pages
{
    public class InsightsPage : BasePage
    {
        private readonly By carouselNextButton = By.XPath("(//div[contains(@class,'slider')])[1]//button[contains(@class,'right-arrow')]");
        private readonly By articleTitle = By.XPath("(//div[contains(@class,'owl-item active')]//div[contains(@class,'content')])[1]//span[contains(@class,'museo')]");
        private readonly By readMoreButton = By.XPath("(//div[contains(@class,'owl-item active')]//div[contains(@class,'content')])[1]//a[contains(text(),'Read More')]");


        public InsightsPage(IWebDriver driver) : base(driver)
        {
        }

        public ReadOnlyCollection<IWebElement> ArticleTitle => Driver.FindElements(articleTitle);


        public void SwipeCarousel(int times)
        {
            for (int i = 0; i < times; i++)
            {
                WaitHelper.WaitUntilClickable(carouselNextButton).Click();
            }
        }


        public string GetArticleTitle()
        {
            WaitHelper.WaitUntilVisible(articleTitle);

            return string.Join(" ", ArticleTitle
                    .Select(e => e.Text.Trim())
                    .Where(text => !string.IsNullOrWhiteSpace(text)));
        }

        public void ClickReadMore()
            => WaitHelper.WaitUntilClickable(readMoreButton).Click();
    }
}
