using Common.Application;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Categories;
using Shop.Application.Categories.Create;
using Shop.Application.Products;
using Shop.Application.Sellers;
using Shop.Application.Users;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure;
using Shop.Query.Categories.GetById;

namespace Shop.Config;

public static class ShopBootstrapper
{
    public static void InitializeShopDependencies(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Initialize(services, connectionString);
        CommonBootstrapper.Initialize(services);
        
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly);
            option.RegisterServicesFromAssembly(typeof(GetCategoryByIdQuery).Assembly);
        });

        services.AddScoped<ICategoryDomainService, CategoryDomainService>();
        services.AddScoped<IProductDomainService, ProductDomainService>();
        services.AddScoped<ISellerDomainService, SellerDomainService>();
        services.AddScoped<IUserDomainService, UserDomainService>();
    }
}