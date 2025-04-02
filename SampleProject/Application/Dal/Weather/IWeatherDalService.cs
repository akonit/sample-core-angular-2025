using Application.Dal.Weather;

public interface IWeatherDalService
{
    Task<WeatherSettings?> GetSettingsAsync(CancellationToken token);

    Task SetTemperatureUnitAsync(TemperatureUnit unit, CancellationToken token);
}