namespace WeatherApplication.Integration.WeatherApi.Models;

using System.Text.Json.Serialization;

public class ForecastDay
{
    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;
    
    [JsonPropertyName("date_epoch")]
    public int DateEpoch { get; set; }
    
    [JsonPropertyName("day")]
    public Day Day { get; set; } = new();
}
