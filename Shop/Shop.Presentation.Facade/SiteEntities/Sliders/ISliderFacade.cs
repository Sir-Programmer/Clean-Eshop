using Common.Application.OperationResults;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Delete;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Presentation.Facade.SiteEntities.Sliders;

public interface ISliderFacade
{
    Task<OperationResult<Guid>> Create(CreateSliderCommand command);
    Task<OperationResult> Edit(EditSliderCommand command);
    Task<OperationResult> Delete(DeleteSliderCommand command);
    
    Task<SliderDto?> GetById(Guid id);
    Task<List<SliderDto>> GetList();
}