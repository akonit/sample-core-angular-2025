using Application.Dal.Weather;

namespace Application.Queries.GetForecasts
{
    public record WeatherForecastDto(DateOnly Date, int Temperature, TemperatureUnit TemperatureUnit, string? Summary);
}