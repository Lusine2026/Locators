using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using EpamJobSearchAutomation.Framework.Pages;

namespace EpamJobSearchAutomation.Business.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly By resultsTitles = By.CssSelector(".search-results__item a");

        public ReadOnlyCollection<IWebElement> ResultsTitles => driver.FindElements(resultsTitles);

        public List<string> GetResultsTitlesList()
        {
            wait.Until(d => d.FindElements(resultsTitles).Count > 0);
            var list = ResultsTitles.Select(title => title.Text).ToList();
            return list;
        }
    }
}
