using EpamJobSearchAutomation.Framework.API.Builders;
using EpamJobSearchAutomation.Framework.Configuration;
using RestSharp;

namespace EpamJobSearchAutomation.Framework.API;

public class ApiClient : IDisposable
{
    protected readonly RestClient Client;

    protected ApiClient()
    {
        Client = new RestClient(ConfigurationHelper.ApiBaseUrl);
    }

    protected Task<RestResponse> GetAsync(
        string endpoint,
        CancellationToken cancellationToken = default)
    {
        var request = new ApiRequestBuilder(endpoint, Method.Get)
            .Build();

        return Client.ExecuteAsync(request, cancellationToken);
    }

    protected Task<RestResponse<T>> GetAsync<T>(
        string endpoint,
        CancellationToken cancellationToken = default)
        where T : notnull
    {
        var request = new ApiRequestBuilder(endpoint, Method.Get)
            .Build();

        return Client.ExecuteAsync<T>(request, cancellationToken);
    }

    protected Task<RestResponse<T>> PostAsync<T>(
        string endpoint,
        object body,
        CancellationToken cancellationToken = default)
        where T : notnull
    {
        var request = new ApiRequestBuilder(endpoint, Method.Post)
            .WithBody(body)
            .Build();

        return Client.ExecuteAsync<T>(request, cancellationToken);
    }

    public void Dispose()
    {
        Client.Dispose();
        GC.SuppressFinalize(this);
    }
}




