namespace WeatherApplication.Logic.Mappers;

using Integration.WeatherApi.Responses;
using Models;

public static class WeatherMapper
{
    public static WeatherForecast Map(WeatherApiForecastResponse mapFrom)
    {
        var day = mapFrom.Forecast.ForecastDays.First();
        
        var city = mapFrom.Location.Name;
        var precipitation = day.Day.Condition.Text;
        var tempMax = day.Day.MaxTempC;
        var tempMin = day.Day.MinTempC;
        var willBeRain = (day.Day.DailyWillItRain == 1);
        
        return new WeatherForecast(city, precipitation, tempMax, tempMin, willBeRain);
    }
}
