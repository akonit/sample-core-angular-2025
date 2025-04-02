using Application.Commands;
using Application.Dal.Weather;
using Application.Queries.GetForecasts;
using Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.MapGet(
        "/weatherforecast",
        async (IMediator mediator, CancellationToken ct) => await mediator.Send(new GetForecastsQuery(), ct))
    .WithName("GetWeatherForecast");

app.MapPost(
        "/weatherforecast/temperatureUnit",
        async (TemperatureUnit temperatureUnit, IMediator mediator, CancellationToken ct)
            => await mediator.Send(new SaveTemperatureUnitCommand(temperatureUnit), ct))
    .WithName("SetTemperatureUnit");

app.Run();
