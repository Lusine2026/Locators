using EpamJobSearchAutomation.Framework.API;
using EpamJobSearchAutomation.Framework.API.Builders;
using EpamJobSearchAutomation.Framework.Logging;
using RestSharp;

namespace EpamJobSearchAutomation.Business.API.Clients;

public class InvalidEndpointClient : ApiClient
{
    public async Task<RestResponse> GetInvalidEndpointAsync()
    {
        Logger.Info("Sending GET request to /invalidendpoint");

        var request = new ApiRequestBuilder("invalidendpoint", Method.Get)
            .Build();

        var response = await Client.ExecuteAsync(request);

        Logger.Info($"Received response with status code: {(int)response.StatusCode}");

        return response;
    }
}

