namespace WeatherApplication.MVC.Controllers;

using System.Diagnostics;
using Logic.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;

public class WeatherController : Controller
{
    private readonly IWeatherService _weatherService;
    private readonly ILogger<WeatherController> _logger;

    public WeatherController(IWeatherService weatherService, ILogger<WeatherController> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var lastCity = HttpContext.Session.GetString("LastCity");
        if (!string.IsNullOrWhiteSpace(lastCity))
        {
            TempData["LastCity"] = lastCity;
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetLastWeather()
    {
        return await GetWeather(HttpContext.Session.GetString("LastCity") ?? string.Empty);
    }

    [HttpPost]
    public async Task<IActionResult> GetWeather(string city)
    {
        var weather = await _weatherService.GetWeatherAsync(city);

        if (weather == null)
            return View("Weather", weather);
            
        if (weather.WillBeRain && HasDayPassedSinceLastWarning(weather.City))
        {
            ViewBag.Warning = "According to the forecast, there will be rain";
            HttpContext.Session.Set(city, BitConverter.GetBytes(DateTime.Now.Ticks));
        }

        TempData["LastCity"] = weather.City;
        HttpContext.Session.SetString("LastCity", weather.City);

        return View("Weather", weather);
    }
    
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private bool HasDayPassedSinceLastWarning(string city)
    {
        DateTime? warningInfo = null;
        if (HttpContext.Session.TryGetValue(city, out byte[]? dateBytes))
        {
            warningInfo = new DateTime(BitConverter.ToInt64(dateBytes, 0));
        }

        if (warningInfo != null)
        {
            return (DateTime.Now - warningInfo.Value).TotalDays >= 1;
        }

        return true;
    }
}
