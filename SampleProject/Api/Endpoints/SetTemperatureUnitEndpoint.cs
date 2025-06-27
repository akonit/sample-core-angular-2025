using Application.Commands;
using Application.Dal.Weather;
using FastEndpoints;
using MediatR;

namespace Api.Endpoints;

public class SetTemperatureUnitEndpoint(IMediator mediator) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/temperatureUnit");
        AllowAnonymous();
        Group<WeatherForecastGroup>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var unit = Query<TemperatureUnit>("temperatureUnit");
        await mediator.Send(new SaveTemperatureUnitCommand(unit), ct);
        await SendOkAsync(ct);
    }
}
