using EpamJobSearchAutomation.Business.API.Models;
using EpamJobSearchAutomation.Framework.API;
using EpamJobSearchAutomation.Framework.Logging;
using RestSharp;

namespace EpamJobSearchAutomation.Business.API.Clients;

public class UsersClient : ApiClient
{
    public async Task<RestResponse<List<User>>> GetUsersAsync()
    {
        Logger.Info("Sending GET request to /users");

        var response = await GetAsync<List<User>>("users");

        Logger.Info($"Received response with status code: {(int)response.StatusCode}");

        return response;
    }

    public async Task<RestResponse<User>> CreateUserAsync(User user)
    {
        Logger.Info("Sending POST request to /users");

        var response = await PostAsync<User>("users", user);

        Logger.Info($"Received response with status code: {(int)response.StatusCode}");

        return response;
    }
}


