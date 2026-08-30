using EpamJobSearchAutomation.Framework.Browser;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace EPAM.BDD.Tests;

public static class ReqnrollTestDependencies
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<IWebDriver>(_ =>
            BrowserFactory.CreateDriver());

        return services;
    }
}