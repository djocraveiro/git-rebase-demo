namespace Weather.Api.Services.Interfaces;

public interface IWeatherForecastService
{
    List<WeatherForecast> GetForecastPage(DateTime date, int pageSize);
    WeatherForecast GetForecast(DateTime date, string city);
}
