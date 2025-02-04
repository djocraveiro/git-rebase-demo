namespace Weather.Api.Services.Interfaces;

public interface IWeatherForecastService
{
    WeatherForecast GetForecast(DateTime date, string city);
}
