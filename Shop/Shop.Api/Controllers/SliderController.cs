using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
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
}