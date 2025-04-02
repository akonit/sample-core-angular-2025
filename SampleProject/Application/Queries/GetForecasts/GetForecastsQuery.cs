using MediatR;

namespace Application.Queries.GetForecasts
{
    public record GetForecastsQuery() : IRequest<WeatherForecastDto[]>;
}