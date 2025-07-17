namespace Shop.Domain.OrderAgg.Enums;

public enum OrderStatus
{
    Created,
    WaitingForPayment,
    FailedPayment,
    SuccessPayment,
    WaitingForShipping,
    Shipping,
    Cancelled,
    Rejected,
}