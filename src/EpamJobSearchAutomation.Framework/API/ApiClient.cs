using EpamJobSearchAutomation.Framework.API.Builders;
using EpamJobSearchAutomation.Framework.Configuration;
using RestSharp;

namespace EpamJobSearchAutomation.Framework.API;

public class ApiClient
{
    protected readonly RestClient Client;

    protected ApiClient()
    {
        Client = new RestClient(ConfigurationHelper.ApiBaseUrl);
    }

    protected async Task<RestResponse<T>> GetAsync<T>(string endpoint)
        where T : notnull
    {
        var request = new ApiRequestBuilder(endpoint, Method.Get)
            .Build();

        return await Client.ExecuteAsync<T>(request);
    }

    protected async Task<RestResponse<T>> PostAsync<T>(string endpoint, object body)
        where T : notnull
    {
        var request = new ApiRequestBuilder(endpoint, Method.Post)
            .WithBody(body)
            .Build();

        return await Client.ExecuteAsync<T>(request);
    }
}



