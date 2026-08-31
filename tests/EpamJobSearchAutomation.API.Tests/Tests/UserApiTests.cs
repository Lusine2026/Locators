using EpamJobSearchAutomation.Business.API.Clients;
using EpamJobSearchAutomation.Business.API.Models;
using EpamJobSearchAutomation.Framework.Logging;
using System.Net;

namespace EpamJobSearchAutomation.API.Tests.Tests;

[Parallelizable(ParallelScope.All)]
[TestFixture]
public class UserApiTests
{
    private readonly UsersClient _usersClient = new();

    [Test]
    [Category("API")]
    public async Task ValidateUsersCanBeReceivedSuccessfully()
    {
        Logger.Info("Validating that the response is successful");

        var response = await _usersClient.GetUsersAsync();

        Assert.That(response.IsSuccessful, Is.True);

        Logger.Info("Validating that the response status code is 200 OK");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        Logger.Info("Validating that the response contains users");

        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data, Is.Not.Empty);

        Logger.Info("Validating required user fields");

        foreach (var user in response.Data)
        {
            Assert.Multiple((Action)(() =>
            {
                Assert.That(user.Id, Is.GreaterThan(0),
                    "User id should be greater than 0");

                Assert.That(user.Name, Is.Not.Null.And.Not.Empty,
                    "User name should not be empty");

                Assert.That(user.Username, Is.Not.Null.And.Not.Empty,
                    "Username should not be empty");

                Assert.That(user.Email, Is.Not.Null.And.Not.Empty,
                    "Email should not be empty");

                Assert.That(user.Address, Is.Not.Null,
                    "Address should not be null");

                Assert.That(user.Phone, Is.Not.Null.And.Not.Empty,
                    "Phone should not be empty");

                Assert.That(user.Website, Is.Not.Null.And.Not.Empty,
                    "Website should not be empty");

                Assert.That(user.Company, Is.Not.Null,
                    "Company should not be null");
            }));
        }
    }

    [Test]
    [Category("API")]
    public async Task ValidateUsersResponseContentType()
    {
        Logger.Info("Validating users response Content-Type header");

        var response = await _usersClient.GetUsersAsync();

        Logger.Info($"Received response with status code: {(int)response.StatusCode}");

        Logger.Info("Validating that the Content-Type header exists");

        Assert.That(response.ContentType, Is.Not.Null.And.Not.Empty,
            "Content-Type header should exist");

        Logger.Info($"Content-Type: {response.ContentType}");

        Logger.Info("Validating that the response status code is 200 OK");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.IsSuccessful, Is.True);
    }

    [Test]
    [Category("API")]
    public async Task ValidateUsersResponseBody()
    {
        Logger.Info("Validating users response body");

        var response = await _usersClient.GetUsersAsync();

        Logger.Info("Validating that the response status code is 200 OK");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.IsSuccessful, Is.True);

        Logger.Info("Validating that the response contains exactly 10 users");

        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data, Has.Count.EqualTo(10));

        Logger.Info("Validating that each user has a unique ID");

        var userIds = response.Data!.Select(user => user.Id).ToList();

        Assert.That(userIds.Distinct().Count(), Is.EqualTo(userIds.Count),
            "Each user should have a different ID");

        Logger.Info("Validating user names, usernames and company names");

        foreach (var user in response.Data)
        {
            Assert.Multiple((Action)(() =>
            {
                Assert.That(user.Name, Is.Not.Null.And.Not.Empty,
                    "User Name should not be empty");

                Assert.That(user.Username, Is.Not.Null.And.Not.Empty,
                    "Username should not be empty");

                Assert.That(user.Company, Is.Not.Null,
                    "Company should not be null");

                Assert.That(user.Company.Name, Is.Not.Null.And.Not.Empty,
                    "Company Name should not be empty");
            }));
        }

        Logger.Info("Users response body validation completed successfully");
    }

    [Test]
    [Category("API")]
    public async Task ValidateUserCanBeCreated()
    {
        Logger.Info("Preparing user data for creation");

        var user = new User
        {
            Name = "Test User",
            Username = "testuser"
        };

        Logger.Info("Creating a new user");

        var response = await _usersClient.CreateUserAsync(user);

        Logger.Info("Validating that the response status code is 201 Created");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(response.IsSuccessful, Is.True);

        Logger.Info("Validating that the response contains created user data");

        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data!.Id, Is.GreaterThan(0));

        Logger.Info($"Created user ID: {response.Data.Id}");
    }

    [Test]
    [Category("API")]
    public async Task ValidateInvalidEndpointReturnsNotFound()
    {
        Logger.Info("Preparing request for invalid endpoint");

        var client = new InvalidEndpointClient();

        Logger.Info("Sending request to invalid endpoint");

        var response = await client.GetInvalidEndpointAsync();

        Logger.Info("Validating that the response status code is 404 Not Found");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }
}
