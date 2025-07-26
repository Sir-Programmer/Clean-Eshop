using Common.Application;

namespace Shop.Application.Orders.Checkout;

public record CheckoutOrderCommand(Guid UserId, string Province, string City, string PostalCode, string FullName, string PostalAddress, string PhoneNumber, string NationalId, Guid ShippingMethodId) : IBaseCommand;