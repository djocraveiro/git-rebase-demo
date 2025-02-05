namespace Weather.Api.Models.Request
{
    public sealed record WeatherForecastPageRequest
    {
        public required DateTime Date { get; init; }

        public required int PageSize { get; init; }
    }
}
