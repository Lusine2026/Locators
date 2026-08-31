using RestSharp;

namespace EpamJobSearchAutomation.Framework.API.Builders;

public class ApiRequestBuilder
{
    private readonly RestRequest _request;

    public ApiRequestBuilder(string endpoint, Method method)
    {
        _request = new RestRequest(endpoint, method);
    }

    public ApiRequestBuilder WithHeader(string name, string value)
    {
        _request.AddHeader(name, value);
        return this;
    }

    public ApiRequestBuilder WithQueryParameter(string name, object value)
    {
        _request.AddQueryParameter(name, value.ToString());
        return this;
    }

    public ApiRequestBuilder WithBody(object body)
    {
        _request.AddJsonBody(body);
        return this;
    }

    public RestRequest Build()
    {
        return _request;
    }
}
