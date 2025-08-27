using Common.Application.OperationResults;
using MediatR;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Delete;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.SiteEntities.Banners.GetById;
using Shop.Query.SiteEntities.Banners.GetList;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Presentation.Facade.SiteEntities.Banners;

public class BannerFacade(IMediator mediator) : IBannerFacade
{
    public async Task<OperationResult<Guid>> Create(CreateBannerCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditBannerCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Delete(DeleteBannerCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<BannerDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetBannerByIdQuery(id));
    }

    public async Task<List<BannerDto>> GetList()
    {
        return await mediator.Send(new GetBannerListQuery());
    }
}