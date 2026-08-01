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
                Menu.Insights => "//span[contains(@class,'top-navigation')]//a[contains(@href,'/insights')]",
                Menu.Services => "//span[contains(@class,'top-navigation')]//a[contains(@href,'/services')]",
                Menu.Industries => "//span[contains(@class,'top-navigation')]//a[contains(@href,'/industries')]",
                Menu.Careers => "//span[contains(@class,'top-navigation')]//a[contains(@href,'/careers')]",
                Menu.About => "//span[contains(@class,'top-navigation')]//a[contains(@href,'/about')]",
                _ => throw new ArgumentOutOfRangeException(nameof(locator))
            };
        }
    }
}
