using DependencyInjectionLifetimeSample.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PrimaryService>();
builder.Services.AddScoped<SecondaryService>();
builder.Services.AddTransient<TertiaryService>();

var app = builder.Build();

app.MapGet("/", (
        PrimaryService primaryService,
        SecondaryService secondaryService,
        TertiaryService tertiaryService) =>
    new
    {
        Id = Guid.NewGuid(),
        PrimaryServiceId = primaryService.Id,
        SecondaryService = new
        {
            Id = secondaryService.Id,
            PrimaryServiceId = secondaryService.PrimaryServiceId
        },
        TertiaryService = new
        {
            Id = tertiaryService.Id,
            PrimaryServiceId = tertiaryService.PrimaryServiceId,
            SecondaryServiceId = tertiaryService.SecondaryServiceId,
            SecondaryServiceNewInstanceId = tertiaryService.SecondaryServiceNewInstanceId,
        }
    });

app.Run();