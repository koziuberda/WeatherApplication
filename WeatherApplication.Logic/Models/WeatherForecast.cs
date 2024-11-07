namespace WeatherApplication.Logic.Models;

public record WeatherForecast(
    string City,
    string Precipitation,
    double TempMin, 
    double TempMax, 
    bool WillBeRain);
