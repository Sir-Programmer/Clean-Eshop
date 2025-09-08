using System.Text.Json.Serialization;
using Shop.Api.Infrastructure.JwtUtils;

namespace Shop.Api.Infrastructure;

public static class DependencyInjection
{
    public static void RegisterApiDependencies(this IServiceCollection services,  IConfiguration configuration)
    {
        // Json Config
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
        // Jwt Config
        services.AddTransient<CustomJwtValidation>();
        services.AddJwtAuthentication(configuration);
    }
}