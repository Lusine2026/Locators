using EpamJobSearchAutomation.Framework.Enums;

namespace EpamJobSearchAutomation.Configuration
{
    public class BrowserSettings
    {
        public BrowserType Browser { get; set; }
        public bool Headless { get; set; }
        public int ImplicitWaitSeconds { get; set; }
        public int PageLoadTimeoutSeconds { get; set; }
    }
}
