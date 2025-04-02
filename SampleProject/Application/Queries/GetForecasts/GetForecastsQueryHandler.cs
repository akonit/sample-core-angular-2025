using MediatR;

namespace Application.Queries.GetForecasts
{
    public record GetForecastsQueryHandler : IRequestHandler<GetForecastsQuery, WeatherForecastDto[]>
    {
        public Task<WeatherForecastDto[]> Handle(GetForecastsQuery request, CancellationToken cancellationToken)
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecastDto
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();

            return Task.FromResult(forecast);
        }
    }
}