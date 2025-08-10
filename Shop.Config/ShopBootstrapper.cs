using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Categories.Create;
using Shop.Infrastructure;
using Shop.Query.Categories.GetById;

namespace Shop.Config;

public static class ShopBootstrapper
{
    public static void Initialize(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Initialize(services, connectionString);
        
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly);
            option.RegisterServicesFromAssembly(typeof(GetCategoryByIdQuery).Assembly);
        });
    }
}