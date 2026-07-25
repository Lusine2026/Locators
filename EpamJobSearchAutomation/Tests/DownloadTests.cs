using EpamJobSearchAutomation.Base;
using EpamJobSearchAutomation.Enum;
using EpamJobSearchAutomation.Pages;

namespace EpamJobSearchAutomation.Tests
{
    public class DownloadTests : BaseTest
    {
        [TestCase("Code-Of-Conduct", Menu.About)]
        public void ValidateDownloadFunction(string fileName, Menu page)
        {
            var home = new HomePage(Driver);
            var cookies = new Utilities.Cookies(Driver);
            var searchAssertions = new SearchAssertions(Driver);
            var about = new AboutPage(Driver);
            var aboutAssertions = new AboutAssertions(Driver);
            var originalWindow = Driver.CurrentWindowHandle;
            var helpers = new Utilities.Helper(Driver);

            home.Open();
            cookies.AcceptCookies();
            home.GoToPageFromMenu(page);
            about.ClickPolicyLink(Policies.CodeOfEthicalConductPDF);

            aboutAssertions.ValidateDownloadedFileName(fileName);
            helpers.ClosePdfWindow(originalWindow);
        }
    }
}
