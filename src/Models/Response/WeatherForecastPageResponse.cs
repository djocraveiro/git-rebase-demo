namespace Weather.Api.Models.Response
{
    internal class WeatherForecastPageResponse
    {
        public required WeatherForecastPageRequest Request { get; init; }
        public required List<WeatherForecast> Data { get; init; } = new();
    }
}
