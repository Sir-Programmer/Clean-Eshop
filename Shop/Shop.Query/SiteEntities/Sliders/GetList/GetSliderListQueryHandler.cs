using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Sliders.GetList;

public class GetSliderListQueryHandler(ShopContext context) : IQueryHandler<GetSliderListQuery, List<SliderDto>>
{
    public async Task<List<SliderDto>> Handle(GetSliderListQuery request, CancellationToken cancellationToken)
    {
        return  await context.Sliders.Select(s => s.MapSlider()).ToListAsync(cancellationToken);
    }
}