using EpamJobSearchAutomation.Enum;
using EpamJobSearchAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamJobSearchAutomation.Pages
{
    public class InsightsPage
    {
        public InsightsPage(IWebDriver driver)
        {
            this.driver = driver;
            helper = new Helper(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            waitHelper = new WaitHelper(driver);
        }

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly Helper helper;
        private readonly WaitHelper waitHelper;
        private readonly By carouselNextButton = By.XPath("(//div[contains(@class,'slider')])[1]//button[contains(@class,'right-arrow')]");
        private readonly By articleTitle = By.XPath("(//div[contains(@class,'owl-item active')]//div[contains(@class,'content')])[1]//span[contains(@class,'museo')]");
        private readonly By readMoreButton = By.XPath("(//div[contains(@class,'owl-item active')]//div[contains(@class,'content')])[1]//a[contains(text(),'Read More')]");

        public ReadOnlyCollection<IWebElement> ArticleTitle => driver.FindElements(articleTitle);

        public void SwipeCarousel(int times)
        {
            for (int i = 0; i < times; i++)
            {
                waitHelper.WaitUntilClickable(carouselNextButton).Click();
            }
        }

        public string GetArticleTitle()
        {
            waitHelper.WaitUntilVisible(articleTitle);

            return string.Join(" ", ArticleTitle.Select(e => e.Text.Trim()).Where(text => !string.IsNullOrWhiteSpace(text)));
        }

        public void ClickReadMore()
            => waitHelper.WaitUntilClickable(readMoreButton).Click();
    }
}
