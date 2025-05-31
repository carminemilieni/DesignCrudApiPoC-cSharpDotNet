using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DesignCrudApiPoC.API.Config;

public class GenericTypeSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsGenericType)
        {
            var genericType = context.Type.GetGenericTypeDefinition();
            var genericArguments = context.Type.GetGenericArguments();
            var genericTypeName = genericType.Name.Contains('`')
                ? genericType.Name.Substring(0, genericType.Name.IndexOf('`'))
                : genericType.Name;
            schema.Title = $"{genericTypeName}<{string.Join(", ", genericArguments.Select(t => t.Name))}>";
        }
    }
}