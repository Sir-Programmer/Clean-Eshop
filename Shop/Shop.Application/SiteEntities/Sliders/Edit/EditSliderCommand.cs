using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntities.Sliders.Edit;

public record EditSliderCommand(Guid SliderId, string Title, string Url, bool IsActive, IFormFile? ImageFile) : IBaseCommand;