using Application.Dal.Weather;
using MediatR;

namespace Application.Commands
{
    public record SaveTemperatureUnitCommand(TemperatureUnit Unit) : IRequest;
}