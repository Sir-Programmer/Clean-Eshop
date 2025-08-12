using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Domain.SellerAgg;

public class Seller : AggregateRoot
{
    private Seller()
    {
        
    }
    public Seller(Guid userId, string shopName, string nationalId, ISellerDomainService sellerDomainService)
    {
        Guard(shopName, nationalId);
        NationalIdExistGuard(nationalId, sellerDomainService);
        UserIdExistGuard(userId, sellerDomainService);
        UserId = userId;
        ShopName = shopName;
        NationalId = nationalId;
        Status = SellerStatus.Pending;

        Inventories = [];
    }
    
    public Guid UserId { get; private set; }
    public string ShopName { get; private set; }
    public string NationalId { get; private set; }
    public List<SellerInventory> Inventories { get; private set; }
    public SellerStatus Status { get; private set; }
    public DateTime LastUpdate { get; private set; }

    public void ChangeStatus(SellerStatus status)
    {
        Status = status;
        LastUpdate = DateTime.Now;
    }

    public void Edit(string shopName, string nationalId, ISellerDomainService sellerDomainService)
    {
        Guard(shopName, nationalId);
        NationalIdExistGuard(nationalId, sellerDomainService);
        ShopName = shopName;
        NationalId = nationalId;
        Status = SellerStatus.Pending;
        LastUpdate = DateTime.Now;
    }

    public void AddInventory(Guid productId, int count, int price, int? discountPercentage)
    {
        if (Inventories.Any(p => p.ProductId == productId))
            throw new InvalidDomainDataException("این محصول قبلا ثبت شده است");
        Inventories.Add(new SellerInventory(productId, count, price, discountPercentage)
        {
            SellerId = UserId
        });
    }

    public void EditInventory(Guid inventoryId, int count, int price, bool isActive, int? discountPercentage)
    {
        var currentInventory = Inventories.FirstOrDefault(p => p.Id == inventoryId);
        if (currentInventory == null) throw new InvalidDomainDataException("محصول مورد نظر یافت نشد");
        currentInventory.Edit(count, price, isActive, discountPercentage);
    }

    public void ApplyDiscountPercentageToInventory(Guid inventoryId, int discountPercentage)
    {
        var currentInventory = Inventories.FirstOrDefault(p => p.Id == inventoryId);
        if (currentInventory == null) throw new InvalidDomainDataException("محصول مورد نظر یافت نشد");
        currentInventory.ApplyDiscountPercentage(discountPercentage);
    }

    public void ActiveInventory(Guid inventoryId)
    {
        var currentInventory = Inventories.FirstOrDefault(p => p.Id == inventoryId);
        if (currentInventory == null) throw new InvalidDomainDataException("محصول مورد نظر یافت نشد");
        currentInventory.Activate();
    }
    
    public void DeActiveInventory(Guid inventoryId)
    {
        var currentInventory = Inventories.FirstOrDefault(p => p.Id == inventoryId);
        if (currentInventory == null) throw new InvalidDomainDataException("محصول مورد نظر یافت نشد");
        currentInventory.DeActivate();
    }

    private void NationalIdExistGuard(string nationalId, ISellerDomainService sellerDomainService)
    {
        if (NationalId != nationalId)
            if (sellerDomainService.IsNationalIdExist(nationalId)) throw new InvalidDomainDataException("کد ملی قبلا ثبت شده است");
    }

    private void UserIdExistGuard(Guid userId, ISellerDomainService sellerDomainService)
    {
        if (sellerDomainService.IsUserIdExist(userId)) throw new InvalidDomainDataException("حساب کاربری شما در حال حاضر فروشنده است");
    }

    private void Guard(string shopName, string nationalId)
    {
        NullOrEmptyDomainException.CheckString(shopName, nameof(shopName));
        NullOrEmptyDomainException.CheckString(nationalId, nameof(nationalId));
        if (!nationalId.IsValidIranianNationalId())
            throw new InvalidDomainDataException("کد ملی نامعتبر است");
    }
}