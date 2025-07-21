using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Domain.SellerAgg;

public class Seller : AggregateRoot
{
    public Seller(Guid userId, string shopName, string nationalId, ISellerDomainService sellerDomainService)
    {
        Guard(shopName, nationalId);
        if (sellerDomainService.IsNationalIdExistInDb(nationalId)) throw new InvalidDomainDataException("کد ملی قبلا ثبت شده است");
        UserId = userId;
        ShopName = shopName;
        NationalId = nationalId;
        Status = SellerStatus.Pending;
    }

    public void ChangeStatus(SellerStatus status)
    {
        Status = status;
        LastUpdate = DateTime.Now;
    }

    public void Edit(string shopName, string nationalId, ISellerDomainService sellerDomainService)
    {
        Guard(shopName, nationalId);
        if (NationalId != nationalId)
            if (sellerDomainService.IsNationalIdExistInDb(nationalId)) throw new InvalidDomainDataException("کد ملی قبلا ثبت شده است");
        ShopName = shopName;
        NationalId = nationalId;
        Status = SellerStatus.Pending;
        LastUpdate = DateTime.Now;
    }

    public void AddInventory(SellerInventory inventory)
    {
        if (Inventories.Any(p => p.ProductId == inventory.ProductId))
            throw new InvalidDomainDataException("این محصول قبلا ثبت شده است");
        Inventories.Add(inventory);
    }

    public void EditInventory(Guid inventoryId, int count, int price, bool isActive, int? discountPercentage)
    {
        var currentInventory = Inventories.FirstOrDefault(p => p.Id == inventoryId);
        if (currentInventory == null) throw new InvalidDomainDataException("محصول مورد نظر یافت نشد");
        currentInventory.Edit(count, price, isActive, discountPercentage);
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

    public Guid UserId { get; private set; }
    public string ShopName { get; private set; }
    public string NationalId { get; private set; }
    public List<SellerInventory> Inventories { get; private set; }
    public SellerStatus Status { get; private set; }
    public DateTime LastUpdate { get; private set; }

    private void Guard(string shopName, string nationalId)
    {
        NullOrEmptyDomainException.CheckString(shopName, nameof(shopName));
        NullOrEmptyDomainException.CheckString(nationalId, nameof(nationalId));
        if (!nationalId.IsValidIranianNationalId())
            throw new InvalidDomainDataException("کد ملی نامعتبر است");
    }
}