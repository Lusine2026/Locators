using EpamJobSearchAutomation.src.Framework.Enums;

namespace EpamJobSearchAutomation.src.Framework.Configuration
{
    public class BrowserSettings
    {
        public BrowserType Browser { get; set; }
        public bool Headless { get; set; }
        public int ImplicitWaitSeconds { get; set; }
        public int PageLoadTimeoutSeconds { get; set; }
    }
}
