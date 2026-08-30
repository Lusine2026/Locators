using EpamJobSearchAutomation.Framework.Logging;

namespace EpamJobSearchAutomation.API.Tests.Tests;

public abstract class ApiTestBase
{
    [SetUp]
    public void Setup()
    {
        Logger.Configure();

        Logger.Info($"Starting API test: {TestContext.CurrentContext.Test.Name}");
    }

    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;

        Logger.Info($"API test finished: {TestContext.CurrentContext.Test.Name}");
        Logger.Info($"Test result status: {status}");
    }
}

