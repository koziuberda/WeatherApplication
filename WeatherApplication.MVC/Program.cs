using Microsoft.Extensions.Options;
using WeatherApplication.Integration.WeatherApi;
using WeatherApplication.Logic.Contracts;
using WeatherApplication.Logic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<WeatherApiSettings>(builder.Configuration.GetSection("WeatherApiSettings"));
builder.Services.AddSingleton(resolver =>
    resolver.GetRequiredService<IOptions<WeatherApiSettings>>().Value);
builder.Services.AddHttpClient();
builder.Services.AddScoped<WeatherApiClient>();
builder.Services.AddScoped<IWeatherService, WeatherService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();  

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Weather}/{action=Index}/{id?}");

app.Run();
