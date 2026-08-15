using EpamJobSearchAutomation.src.Framework.Pages;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.src.Business.Pages
{
    public class JobDetailsPage : BasePage
    {
        private readonly By jobDetailInfo =By.XPath("//span[contains(@class,'JobDetails')]");
        private readonly By jobTitle =By.TagName("h1");

        public JobDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement JobDetailInfo =>WaitHelper.WaitUntilVisible(jobDetailInfo);

        public bool IsLanguagePresent(string language)
        {
            return JobDetailInfo.Text.Contains(language,StringComparison.OrdinalIgnoreCase);
        }

        public string GetJobTitle()
            => WaitHelper.WaitUntilVisible(jobTitle).Text;
    }
}
