namespace WeatherApplication.Logic.Services;

using Contracts;
using Integration.WeatherApi;
using Integration.WeatherApi.Requests;
using Mappers;
using Models;

public class WeatherService : IWeatherService
{
    private readonly WeatherApiClient _weatherApiClient;
    
    public WeatherService(WeatherApiClient weatherApiClient)
    {
        _weatherApiClient = weatherApiClient;
    }

    public async Task<WeatherForecast?> GetWeatherAsync(string city)
    {
        var request = GetRequest(city);
        var apiResponse = await _weatherApiClient.GetWeatherAsync(request);
        if (apiResponse is null) { return null; }
        return WeatherMapper.Map(apiResponse);
    }

    private WeatherApiForecastRequest GetRequest(string city) => new(city, 1);
}
