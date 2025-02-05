namespace Weather.Api.Services;

internal sealed class WeatherForecastService : IWeatherForecastService
{
    #region Fields
    private readonly Faker _faker;
    private readonly Faker<WeatherForecast> _weatherForecastBuilder;
    #endregion

    #region Constructors
    public WeatherForecastService()
    {
        _faker = new("en");
        _weatherForecastBuilder = new Faker<WeatherForecast>()
            .RuleFor(x => x.Date, (f) => DateTime.UtcNow)
            .RuleFor(x => x.City, (f => f.Address.City()))
            .RuleFor(x => x.TemperatureCelcius, (f) => f.Random.Int(0, 30))
            .RuleFor(x => x.Summary, (f, curr) => GetWeatherSummary(curr.TemperatureCelcius));
    }
    #endregion

    #region Public Methods
    public List<WeatherForecast> GetForecastPage(DateTime date, int pageSize)
    {
        return Enumerable.Range(1, pageSize)
            .Select(i => GetForecast(date, _faker.Address.City()))
            .ToList();
    }

    public WeatherForecast GetForecast(DateTime date, string city)
    {
        // simulate an heavy task processing
        Thread.Sleep(TimeSpan.FromSeconds(1));

        return _weatherForecastBuilder
            .RuleFor(x => x.Date, (f) => date)
            .RuleFor(x => x.City, (f) => city)
            .Generate();
    }
    #endregion

    #region Private Methods
    private static string GetWeatherSummary(int temperatureCelcius)
    {
        if (temperatureCelcius <= 0)
        {
            return "Freezing";
        }
        else if (temperatureCelcius <= 10)
        {
            return "Cold";
        }
        else if (temperatureCelcius <= 20)
        {
            return "Warm";
        }
        else
        {
            return "Hot";
        }
    }
    #endregion
}
