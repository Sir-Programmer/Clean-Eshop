using Common.Application.OperationResults;
using MediatR;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Delete;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Query.SiteEntities.DTOs;
using Shop.Query.SiteEntities.Sliders.GetById;
using Shop.Query.SiteEntities.Sliders.GetList;

namespace Shop.Presentation.Facade.SiteEntities.Sliders;

public class SliderFacade(IMediator mediator) : ISliderFacade
{
    public async Task<OperationResult<Guid>> Create(CreateSliderCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditSliderCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Delete(DeleteSliderCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<SliderDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetSliderByIdQuery(id));
    }

    public async Task<List<SliderDto>> GetList()
    {
        return await mediator.Send(new GetSliderListQuery());
    }
}