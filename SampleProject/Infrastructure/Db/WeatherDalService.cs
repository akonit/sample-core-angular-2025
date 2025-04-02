using Application.Dal.Weather;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Db
{
    public record WeatherDalService(SampleDbContext Context, ILogger<WeatherDalService> Logger) : IWeatherDalService
    {
        public Task<WeatherSettings?> GetSettingsAsync(CancellationToken token)
            => this.Context.WeatherSettings.FirstOrDefaultAsync(token);

        public async Task SetTemperatureUnitAsync(TemperatureUnit unit, CancellationToken token)
        {
            var settings = await GetSettingsAsync(token) ?? new WeatherSettings();
            settings.TemperatureUnit = unit;

            if (settings.Id == default)
            {
                settings.Id = Guid.NewGuid();
                this.Context.WeatherSettings.Add(settings);
            }

            await this.Context.SaveChangesAsync(token);

            this.Logger.LogInformation("Changed temperature unit to {unit}", unit);
        }
    }
}