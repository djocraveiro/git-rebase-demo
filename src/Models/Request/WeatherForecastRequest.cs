namespace Weather.Api.Models.Request
{
    public sealed record WeatherForecastRequest
    {
        public required DateTime Date { get; init; }

        public required string City { get; init; }
    }
}
