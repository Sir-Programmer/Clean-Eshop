using Common.Application;

namespace Shop.Application.SiteEntities.Banners.Delete;

public record DeleteBannerCommand(Guid BannerId) : IBaseCommand;