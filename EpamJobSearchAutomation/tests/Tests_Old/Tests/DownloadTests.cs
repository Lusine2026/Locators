using EpamJobSearchAutomation.Business.Steps;
using EpamJobSearchAutomation.Framework;
using EpamJobSearchAutomation.src.Business.Enums;
using EpamJobSearchAutomation.Tests.Assertions;

namespace EpamJobSearchAutomation.tests.Tests.Tests
{
    public class DownloadTests : BaseTest
    {
        [TestCase("Code-Of-Conduct", Menu.About)]
        public void ValidateDownloadFunction(string fileName, Menu page)
        {
            var homeSteps = new HomeSteps(Driver);
            var aboutSteps = new AboutSteps(Driver);
            var aboutAssertions = new AboutAssertions(Driver);
            var elementHelper = new ElementHelper(Driver);

            var originalWindow = Driver.CurrentWindowHandle;

            homeSteps.OpenHomePage();
            aboutSteps.DownloadPolicyDocument(page, Policies.CodeOfEthicalConductPDF);

            aboutAssertions.ValidateDownloadedFileName(fileName);

            elementHelper.ClosePdfWindow(originalWindow);
        }
    }
}