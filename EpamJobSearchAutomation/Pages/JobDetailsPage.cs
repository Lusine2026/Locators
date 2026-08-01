using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EpamJobSearchAutomation.Pages
{
    public class JobDetailsPage : HomePage
    {
        public JobDetailsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        protected internal By jobDetailInfo = By.XPath("//span[contains(@class,'JobDetails')]");

        public IWebElement JobDetailInfo => driver.FindElement(jobDetailInfo);

        public bool IsLanguagePresent(string language)
            => JobDetailInfo.Text.Contains(language, StringComparison.OrdinalIgnoreCase);

        public string GetJobTitle()
        {
            IWebElement title =
                wait.Until(d => d.FindElement(By.TagName("h1")));

            return title.Text;
        }
    }
}
