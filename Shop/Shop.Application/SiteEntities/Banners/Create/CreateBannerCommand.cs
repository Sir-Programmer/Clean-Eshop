using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities.Banner.Enums;

namespace Shop.Application.SiteEntities.Banners.Create;

public record CreateBannerCommand(string Url, IFormFile ImageFile, BannerPosition Position) : IBaseCommand;