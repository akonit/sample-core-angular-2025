using Application.Commands;
using Application.Dal.Weather;
using Application.Queries.GetForecasts;
using FastEndpoints;
using FastEndpoints.Swagger;
using Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints()
                .AddSwaggerDocument();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetForecastsQuery).Assembly));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost", "http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<SampleDbContext>(options => options.UseSqlite());

builder.Services.AddScoped<IWeatherDalService, WeatherDalService>();

var app = builder.Build();

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseFastEndpoints()
   .UseSwaggerGen();

app.Run();
