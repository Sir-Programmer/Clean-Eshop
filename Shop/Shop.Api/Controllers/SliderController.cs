using System.Net;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.SiteEntities.Slider;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Delete;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Presentation.Facade.SiteEntities.Sliders;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Api.Controllers;

public class SliderController(ISliderFacade sliderFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<List<SliderDto>>> GetList()
    {
        var result = await sliderFacade.GetList();
        return QueryResult(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ApiResult<SliderDto?>> GetById(Guid id)
    {
        var result = await sliderFacade.GetById(id);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult<Guid>> Create(CreateSliderCommand command)
    {
        var result = await sliderFacade.Create(command);
        var url = Url.Action("GetById", "Slider", new { id = result.Data }, Request.Scheme);
        return CommandResult(result, statusCode: HttpStatusCode.Created, locationUrl: url);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ApiResult> Edit(Guid id, [FromForm] EditSliderViewModel vm)
    {
        var result = await sliderFacade.Edit(new EditSliderCommand(id, vm.Title, vm.Url, vm.IsActive, vm.ImageFile));
        return CommandResult(result);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ApiResult> Delete(Guid id)
    {
        var result = await sliderFacade.Delete(new DeleteSliderCommand(id));
        return CommandResult(result);
    }
}