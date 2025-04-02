using MediatR;

namespace Application.Queries.GetForecasts
{
    public record GetForecastsQueryHandler(IWeatherDalService WeatherDalService) : IRequestHandler<GetForecastsQuery, WeatherForecastDto[]>
    {
        public async Task<WeatherForecastDto[]> Handle(GetForecastsQuery request, CancellationToken cancellationToken)
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var settings = await this.WeatherDalService.GetSettingsAsync(cancellationToken);

            var forecast = Enumerable.Range(1, 5).Select(index =>
            {
                var unit = settings?.TemperatureUnit ?? Dal.Weather.TemperatureUnit.Celsius;
                var temperature = Random.Shared.Next(-20, 55);
                if (unit == Dal.Weather.TemperatureUnit.Fahrenheit)
                {
                    temperature = 32 + (int)(temperature / 0.5556);
                }

                return new WeatherForecastDto
                                (
                                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                                    temperature,
                                    unit,
                                    summaries[Random.Shared.Next(summaries.Length)]
                                );
            }).ToArray();

            return forecast;
        }
    }
}