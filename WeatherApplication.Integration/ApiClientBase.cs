namespace WeatherApplication.Integration;

using System.Text.Json;

public class ApiClientBase
{
    private readonly HttpClient _httpClient;

    public ApiClientBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected async Task<ResponseBase<TResponse?>> GetAsync<TResponse>(string requestUri)
    {
        var apiResponse = await _httpClient.GetAsync(requestUri);
        if (!apiResponse.IsSuccessStatusCode)
        {
            return ResponseHelper.CreateError<TResponse?>(default);
        }
        var content = await apiResponse.Content.ReadAsStringAsync();
        var response = ResponseHelper.CreateSuccess(JsonSerializer.Deserialize<TResponse>(content));
        return response;
    }
}
