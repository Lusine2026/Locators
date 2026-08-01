namespace EpamJobSearchAutomation.Business.Enums
{
    public enum Policies
    {
        CodeOfEthicalConductPDF,
        ApplicantPrivacyNotice,
        CookiePolicy,
        WebAccessibility
    }
    public static class PoliciesExtensions
    {
        public static string GetValue(this Policies locator)
        {
            return locator switch
            {
                Policies.CodeOfEthicalConductPDF => "//div[@class='policies']//ul//a[contains(@href,'Code-Of-Conduct')]",
                Policies.ApplicantPrivacyNotice => "//div[@class='policies']//ul//a[contains(@href,'Privacy-Notice')]",
                Policies.CookiePolicy => "//div[@class='policies']//ul//a[contains(@href,'Cookie-Policy')]",
                Policies.WebAccessibility => "//div[@class='policies']//ul//a[contains(@href,'Web-Accessibility')]",
                _ => throw new ArgumentOutOfRangeException(nameof(locator))
            };
        }
    }
}
