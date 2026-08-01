using EpamJobSearchAutomation.Utilities;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Pages
{
    public class AboutAssertions : AboutPage
    {
        private readonly WaitHelper waitHelper;
        
        public AboutAssertions(IWebDriver driver) : base(driver)
        {       
            waitHelper = new WaitHelper(driver);     
        }

        public void ValidateDownloadedFileName(string expectedFileName)
        {
            string downloadedFile = waitHelper.WaitForDownload(expectedFileName);
            Assert.That(Path.GetFileName(downloadedFile).ToLower(),Does.Contain(expectedFileName.ToLower()));
        }
    }
}
