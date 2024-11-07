namespace WeatherApplication.Integration.WeatherApi.Requests;

public record WeatherApiForecastRequest(string City, int DaysCount);