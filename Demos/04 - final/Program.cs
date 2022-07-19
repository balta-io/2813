using DependencyInjectionLifetimeSample.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IService, PrimaryService>();
// builder.Services.AddTransient<IService, PrimaryService>();
// builder.Services.AddTransient<IService, PrimaryService>();
// builder.Services.AddTransient<IService, SecondaryService>();
// builder.Services.AddTransient<IService, SecondaryService>();
// builder.Services.AddTransient<IService, TertiaryService>();

// var descriptor = new ServiceDescriptor(
//     typeof(IService),
//     typeof(PrimaryService),
//     ServiceLifetime.Transient);
// builder.Services.Add(descriptor);

// builder.Services.TryAddTransient<IService, PrimaryService>();
// builder.Services.TryAddTransient<IService, PrimaryService>();
// builder.Services.TryAddTransient<IService, PrimaryService>();

// builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, PrimaryService>());
// builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, PrimaryService>()); // Permite
// builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, SecondaryService>()); // Não permite

var app = builder.Build();

// app.MapGet("/", (IService primaryService) => Results.Ok(primaryService.GetType().Name));
app.MapGet("/", (IEnumerable<IService> services) => Results.Ok(services.Select(x=>x.GetType().Name)));

app.Run();

public interface IService
{
}