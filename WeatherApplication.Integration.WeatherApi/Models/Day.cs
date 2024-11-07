namespace WeatherApplication.Integration.WeatherApi.Models;

using System.Text.Json.Serialization;

public class Day
{
    [JsonPropertyName("maxtemp_c")]
    public double MaxTempC { get; set; }
    
    [JsonPropertyName("mintemp_c")]
    public double MinTempC { get; set; }
    
    [JsonPropertyName("daily_will_it_rain")]
    public double DailyWillItRain { get; set; }
    
    [JsonPropertyName("condition")]
    public Condition Condition { get; set; } = new();
}
