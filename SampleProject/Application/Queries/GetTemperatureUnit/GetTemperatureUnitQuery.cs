using Application.Dal.Weather;
using MediatR;

namespace Application.Queries.GetTemperatureUnit
{
    public record GetTemperatureUnitQuery() : IRequest<TemperatureUnit>;
}