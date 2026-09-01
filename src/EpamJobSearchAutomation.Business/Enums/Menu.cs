namespace EpamJobSearchAutomation.Business.Enums
{
    public enum Menu
    {
        Services,
        Industries,
        Insights,
        Careers,
        About
    }

    public static class MenuExtensions
    {
        public static string GetValue(this Menu locator)
        {
            return locator switch
            {
                Menu.Services => "//span[contains(@class,'top-navigation')]//a[text()='Services']",
                Menu.Industries => "//span[contains(@class,'top-navigation')]//a[text()='Industries']",
                Menu.Insights => "//span[contains(@class,'top-navigation')]//a[text()='Insights']",
                Menu.Careers => "//span[contains(@class,'top-navigation')]//a[text()='Careers']",
                Menu.About => "//span[contains(@class,'top-navigation')]//a[text()='About']",
                _ => throw new ArgumentOutOfRangeException(nameof(locator))
            };
        }
    }
}
