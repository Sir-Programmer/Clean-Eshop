using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SiteEntities.ShippingMethod;

public class ShippingMethod : BaseEntity
{
    public ShippingMethod(string title, int cost)
    {
        Guard(title, cost);
        Title = title;
        Cost = cost;
    }
    public string Title { get; private set; }
    public int Cost { get; private set; }

    public void Eidt(string title, int cost)
    {
        Guard(title, cost);
        Title = title;
        Cost = cost;
    }

    private void Guard(string title, int cost)
    {
        NullOrEmptyDomainException.CheckString(title, nameof(title));
        if (cost < 0) throw new InvalidDomainDataException("هزینه ارسال پستی نمیتواند کمتر از صفر باشد");
    }
}