using Shop.Domain.UserAgg.Enums;

namespace Shop.Domain.UserAgg;

public class UserWallet
{
    public UserWallet(int price, WalletType type, string description, bool isFinally, DateTime finallyDate)
    {
        Price = price;
        Type = type;
        Description = description;
        IsFinally = isFinally;
        FinallyDate = finallyDate;
    }
    
    public Guid UserId { get; internal set; }
    public int Price { get; private set; }
    public WalletType Type { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public DateTime? FinallyDate { get; private set; }
    
}