using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.SiteEntities.Banner;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Delete;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Presentation.Facade.SiteEntities.Banners;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Api.Controllers;

public class BannerController(IBannerFacade bannerFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<List<BannerDto>>> GetList()
    {
        var result = await bannerFacade.GetList();
        return QueryResult(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ApiResult<BannerDto?>> GetById(Guid id)
    {
        var result = await bannerFacade.GetById(id);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult<Guid>> Create(CreateBannerCommand command)
    {
        var result = await bannerFacade.Create(command);
        return CommandResult(result);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ApiResult> Create(Guid id, [FromForm] EditBannerViewModel vm)
    {
        var result = await bannerFacade.Edit(new EditBannerCommand(id, vm.Url, vm.ImageFile, vm.Position));
        return CommandResult(result);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ApiResult> Delete(Guid id)
    {
        var result = await bannerFacade.Delete(new DeleteBannerCommand(id));
        return CommandResult(result);
    }
}