using Application.Dal.Weather;
using MediatR;

namespace Application.Queries.GetTemperatureUnit
{
    public record GetTemperatureUnitQueryHandler(IWeatherDalService DalService) : IRequestHandler<GetTemperatureUnitQuery, TemperatureUnit>
    {
        public async Task<TemperatureUnit> Handle(GetTemperatureUnitQuery request, CancellationToken cancellationToken)
        {
            var settings = await this.DalService.GetSettingsAsync(cancellationToken);
            return settings?.TemperatureUnit ?? TemperatureUnit.Celsius;
        }
    }
}