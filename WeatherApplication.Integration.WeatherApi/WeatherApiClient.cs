namespace WeatherApplication.Integration.WeatherApi;

using Requests;
using Responses;

public class WeatherApiClient : ApiClientBase
{
    private readonly WeatherApiSettings _settings;
    
    public WeatherApiClient(HttpClient httpClient, WeatherApiSettings settings) 
        : base(httpClient)
    {
        _settings = settings;
    }
    
    public async Task<WeatherApiForecastResponse?> GetWeatherAsync(WeatherApiForecastRequest request)
    {
        var requestUrl = $"{_settings.ApiBaseUrl}?key={_settings.ApiKey}&q={request.City}&days={request.DaysCount}&aqi=no&alerts=no";
        var response = await GetAsync<WeatherApiForecastResponse>(requestUrl);
        return response.Result;
    }
}
