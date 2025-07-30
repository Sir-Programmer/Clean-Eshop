using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities.Banner.Enums;

namespace Shop.Application.SiteEntities.Banners.Edit;

public record EditBannerCommand(Guid BannerId, string Url, IFormFile? ImageFile, BannerPosition Position) : IBaseCommand;