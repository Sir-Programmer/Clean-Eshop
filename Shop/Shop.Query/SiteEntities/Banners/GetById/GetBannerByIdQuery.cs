using Common.Query;
using Shop.Domain.SiteEntities.Banner;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Banners.GetById;

public record GetBannerByIdQuery(Guid BannerId) : IQuery<BannerDto?>;