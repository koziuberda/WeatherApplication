namespace WeatherApplication.Integration.WeatherApi.Models;

using System.Text.Json.Serialization;

public record Location([property: JsonPropertyName("name")] string Name);
