namespace Shop.Api.ViewModels.Order;

public class CheckoutOrderViewModel
{
    public string Province { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string FullName { get; set; }
    public string PostalAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalId { get; set; }
    public Guid ShippingMethodId { get; set; }
}