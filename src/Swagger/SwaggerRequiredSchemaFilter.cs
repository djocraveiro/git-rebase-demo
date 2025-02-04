namespace Weather.Api.Swagger;

public class SwaggerRequiredSchemaFilter : Swashbuckle.AspNetCore.SwaggerGen.ISchemaFilter
{
    public void Apply(
        Microsoft.OpenApi.Models.OpenApiSchema schema,
        Swashbuckle.AspNetCore.SwaggerGen.SchemaFilterContext context)
    {
        if (schema.Properties is null)
        {
            return;
        }

        foreach (var schemProperty in schema.Properties)
        {
            if (schemProperty.Value.Nullable)
            {
                continue;
            }

            if (!schema.Required.Contains(schemProperty.Key))
            {
                schema.Required.Add(schemProperty.Key);
            }
        }
    }
}
