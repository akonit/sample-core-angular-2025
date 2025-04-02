using MediatR;

namespace Application.Commands
{
    public record SaveTemperatureUnitCommandHandler(IWeatherDalService DalService)
        : IRequestHandler<SaveTemperatureUnitCommand>
    {
        public Task Handle(SaveTemperatureUnitCommand request, CancellationToken cancellationToken) =>
            this.DalService.SetTemperatureUnitAsync(request.Unit, cancellationToken);
    }
}