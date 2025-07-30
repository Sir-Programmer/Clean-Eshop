using Common.Application;

namespace Shop.Application.SiteEntities.Sliders.Delete;

public record DeleteSliderCommand(Guid SliderId) : IBaseCommand;