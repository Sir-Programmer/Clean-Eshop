using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Sliders.GetById;

public class GetSliderByIdQueryHandler(ShopContext context) : IQueryHandler<GetSliderByIdQuery, SliderDto?>
{
    public async Task<SliderDto?> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var slider =  await context.Sliders.FirstOrDefaultAsync(s => s.Id == request.SliderId, cancellationToken);
        return slider.MapSliderOrNull();
    }
}