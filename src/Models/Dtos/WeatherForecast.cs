namespace Weather.Api.Models.Dtos;

public sealed record WeatherForecast
{
    public required DateTime Date { get; init; }

    public required string City { get; init; }

    public required int TemperatureCelcius { get; init; }

    public int TemperatureFahrenheit => 32 + (int)(TemperatureCelcius / 0.5556);

    public required string Summary { get; init; }
}
