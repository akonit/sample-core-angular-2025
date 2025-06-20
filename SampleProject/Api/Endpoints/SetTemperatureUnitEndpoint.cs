using Application.Commands;
using Application.Dal.Weather;
using FastEndpoints;
using MediatR;

namespace Api.Endpoints;

public class SetTemperatureUnitEndpoint(IMediator mediator) : Endpoint<TemperatureUnit>
{
    public override void Configure()
    {
        Post("/temperatureUnit");
        AllowAnonymous();
        Group<WeatherForecastGroup>();
    }

    public override Task HandleAsync(TemperatureUnit temperatureUnit, CancellationToken ct) =>
        mediator.Send(new SaveTemperatureUnitCommand(temperatureUnit), ct);
}
