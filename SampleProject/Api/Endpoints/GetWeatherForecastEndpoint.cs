using Application.Queries.GetForecasts;
using FastEndpoints;
using MediatR;

namespace Api.Endpoints;

public class GetWeatherForecastEndpoint(IMediator mediator) : EndpointWithoutRequest<WeatherForecastDto[]>
{
    public override void Configure()
    {
        Get("/");
        AllowAnonymous();
        Group<WeatherForecastGroup>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await mediator.Send(new GetForecastsQuery(), ct);
        await SendOkAsync(result, ct);
    }
}