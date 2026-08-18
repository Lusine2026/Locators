using EpamJobSearchAutomation.Framework.Helpers;
using OpenQA.Selenium;

namespace EpamJobSearchAutomation.Tests.Assertions
{
    public class AboutAssertions
    {
        private readonly WaitHelper waitHelper;

        public AboutAssertions(IWebDriver driver)
        {
            waitHelper = new WaitHelper(driver);
        }

        public void ValidateDownloadedFileName(string expectedFileName)
        {
            string downloadedFile = waitHelper.WaitForDownload(expectedFileName);

            Assert.That(Path.GetFileName(downloadedFile).ToLower(), Does.Contain(expectedFileName.ToLower()));
        }
    }
}
