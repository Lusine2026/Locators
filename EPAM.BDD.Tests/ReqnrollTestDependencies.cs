using EPAM.BDD.Tests.Drivers;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace EPAM.BDD.Tests;

public static class ReqnrollTestDependencies
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<WebDriverManager>();

        return services;
    }
}