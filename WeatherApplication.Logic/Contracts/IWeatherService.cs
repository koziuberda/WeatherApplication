namespace WeatherApplication.Logic.Contracts;

using Models;

public interface IWeatherService
{
    Task<WeatherForecast?> GetWeatherAsync(string city);
}
