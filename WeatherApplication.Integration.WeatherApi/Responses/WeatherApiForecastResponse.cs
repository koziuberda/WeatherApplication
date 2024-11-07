namespace WeatherApplication.Integration.WeatherApi.Responses;

using System.Text.Json.Serialization;
using Models;

public record WeatherApiForecastResponse(
    [property: JsonPropertyName("location")] Location Location, 
    [property: JsonPropertyName("forecast")] Forecast Forecast);
