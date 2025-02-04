namespace Weather.Api.Models.Response;

public sealed record WeatherForecastResponse
{
    public required Request.WeatherForecastRequest Request { get; init; }

    public required List<WeatherForecast> Data { get; init; } = new();
}
