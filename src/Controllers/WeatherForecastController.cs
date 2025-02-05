namespace Weather.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class WeatherForecastController : ControllerBase
{
    #region Fields
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;
    #endregion

    #region Constructors
    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }
    #endregion

    #region Public Methods
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WeatherForecastResponse))]
    public IActionResult Get([FromQuery] WeatherForecastRequest request)
    {
        var data = _weatherForecastService.GetForecast(request.Date, request.City);

        return Ok(new WeatherForecastResponse
        {
            Request = request,
            Data = data
        });
    }
    #endregion
}
