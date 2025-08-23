using Common.Application;
using Common.Application.FileUtil.Implementation;
using Common.Application.FileUtil.Interfaces;
using Common.Application.UnitOfWork;
using FluentValidation;
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
using Shop.Infrastructure._Utilities;
using Shop.Query.Categories.GetById;
using Shop.Query.Orders.Services;
using Shop.Query.Products.Services;
using Shop.Query.Users.Services;

namespace Shop.Config;

public static class ShopBootstrapper
{
    public static void InitializeShopDependencies(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Initialize(services, connectionString);
        CommonBootstrapper.Initialize(services);
        
        // MediatR
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly);
            option.RegisterServicesFromAssembly(typeof(GetCategoryByIdQuery).Assembly);
        });
        
        // Fluent Validation
        services.AddValidatorsFromAssembly(typeof(CreateCategoryCommandValidator).Assembly);
        
        // UnitOfWork And Utilities
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IFileService, FileService>();
        
        // Domain Services
        services.AddScoped<ICategoryDomainService, CategoryDomainService>();
        services.AddScoped<IProductDomainService, ProductDomainService>();
        services.AddScoped<ISellerDomainService, SellerDomainService>();
        services.AddScoped<IUserDomainService, UserDomainService>();
        
        // Query
        services.AddScoped<IOrderQueryService, OrderQueryService>();
        services.AddScoped<IProductQueryService, ProductQueryService>();
        services.AddScoped<IUserQueryService, UserQueryService>();
        
    }
}