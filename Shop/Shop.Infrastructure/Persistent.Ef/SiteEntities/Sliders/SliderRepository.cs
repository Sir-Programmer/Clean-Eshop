using Shop.Domain.SiteEntities.Slider;
using Shop.Domain.SiteEntities.Slider.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Sliders;

public class SliderRepository(ShopContext context) : BaseRepository<Slider>(context), ISliderRepository
{
    public void Delete(Slider slider)
    {
        Context.Remove(slider);
    }
}