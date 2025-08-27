using Common.Application.OperationResults;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Delete;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Presentation.Facade.SiteEntities.Banners;

public interface IBannerFacade
{
    Task<OperationResult<Guid>> Create(CreateBannerCommand command);
    Task<OperationResult> Edit(EditBannerCommand command);
    Task<OperationResult> Delete(DeleteBannerCommand command);
    
    Task<BannerDto?> GetById(Guid id);
    Task<List<BannerDto>> GetList();
}