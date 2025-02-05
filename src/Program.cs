namespace Weather;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var application = WebApplication.CreateBuilder(args)
            .ConfigureServices()
            .Build()
            .ConfigureApplication();

        await application.RunAsync();
    }

    private static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.SupportNonNullableReferenceTypes();
                options.SchemaFilter<Api.Swagger.SwaggerRequiredSchemaFilter>();

                // Load documentation;
                var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

        builder.Services.AddMemoryCache();
        builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();

        return builder;
    }

    private static WebApplication ConfigureApplication(this WebApplication application)
    {
        if (application.Environment.IsDevelopment())
        {
            application
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    // Disable swagger schemas at bottom
                    options.DefaultModelsExpandDepth(-1);
                });
        }

        application.UseAuthorization();

        application.MapControllers();

        return application;
    }
}
