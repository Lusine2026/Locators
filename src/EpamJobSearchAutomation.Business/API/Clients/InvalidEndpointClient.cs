using EpamJobSearchAutomation.Framework.API;
using EpamJobSearchAutomation.Framework.Logging;
using RestSharp;

namespace EpamJobSearchAutomation.Business.API.Clients;

public class InvalidEndpointClient : ApiClient
{
    public async Task<RestResponse> GetInvalidEndpointAsync()
    {
        Logger.Info("Sending GET request to /invalidendpoint");

        var response = await GetAsync("invalidendpoint");

        Logger.Info($"Received response with status code: {(int)response.StatusCode}");

        return response;
    }
}


