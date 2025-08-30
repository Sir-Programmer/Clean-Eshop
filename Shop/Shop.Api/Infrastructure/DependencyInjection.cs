using System.Text.Json.Serialization;

namespace Shop.Api.Infrastructure;

public static class DependencyInjection
{
    public static void RegisterApiDependencies(this IServiceCollection services)
    {
        // Json Config
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
    }
}