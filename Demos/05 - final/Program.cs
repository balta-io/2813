using ResolvingDependencies.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var service = scope
        .ServiceProvider
        .GetRequiredService<IWeatherService>();
    service.Get();
}

app.UseAuthentication();
app.UseAuthorization();

app.Run();
