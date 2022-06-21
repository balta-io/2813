using System.Reflection;
using Blog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<BlogDataContext>(x =>
{
    x.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        options =>
        {
            options.MigrationsAssembly("Blog.Api");
            options.MigrationsHistoryTable("__BlogMigrationsHistory", "Blog");
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Blog API",
        Description = "API do curso 2814 do balta.io",
        TermsOfService = new Uri("https://blogdobaltinha.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Equipe balta.io",
            Url = new Uri("https://balta.io/.ajuda")
        },
        License = new OpenApiLicense
        {
            Name = "Licença",
            Url = new Uri("https://balta.io/termos")
        }
    });
    
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        x.RoutePrefix = string.Empty;
    });
}

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();