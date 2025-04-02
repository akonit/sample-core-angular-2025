using MediatR;

public record GetForecastsQuery() : IRequest<WeatherForecastDto[]>;