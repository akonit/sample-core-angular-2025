using FastEndpoints;

public class WeatherForecastGroup : Group
{
    public WeatherForecastGroup()
    {
        Configure("weatherforecast", ep => { ep.Description(x => x.WithTags("Weather")); });
    }
}