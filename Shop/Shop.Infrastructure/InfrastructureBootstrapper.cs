using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CommentAgg.Repository;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SiteEntities.Banner.Repository;
using Shop.Domain.SiteEntities.ShippingMethod.Repository;
using Shop.Domain.SiteEntities.Slider.Repository;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.CommentAgg;
using Shop.Infrastructure.Persistent.Ef.OrderAgg;
using Shop.Infrastructure.Persistent.Ef.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.SellerAgg;
using Shop.Infrastructure.Persistent.Ef.SiteEntities.Banners;
using Shop.Infrastructure.Persistent.Ef.SiteEntities.ShippingMethods;
using Shop.Infrastructure.Persistent.Ef.SiteEntities.Sliders;
using Shop.Infrastructure.Persistent.Ef.UserAgg;

namespace Shop.Infrastructure;

public class InfrastructureBootstrapper
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();
        services.AddScoped<IBannerRepository, BannerRepository>();
        services.AddScoped<IShippingMethodRepository, ShippingMethodRepository>();
        services.AddScoped<ISliderRepository, SliderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}