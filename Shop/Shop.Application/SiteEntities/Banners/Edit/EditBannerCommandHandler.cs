using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Banner.Repository;

namespace Shop.Application.SiteEntities.Banners.Edit;

public class EditBannerCommandHandler(IBannerRepository bannerRepository, IUnitOfWork unitOfWork, IFileService fileService) : IBaseCommandHandler<EditBannerCommand>
{
    public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await bannerRepository.GetByIdTrackingAsync(request.BannerId);
        if (banner == null) return OperationResult.NotFound();
        
        var imageName = banner.ImageName;
        var oldImageName = banner.ImageName;

        if (request.ImageFile != null)
            imageName = await fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
        
        banner.Edit(request.Url, imageName, request.Position);
        
        await unitOfWork.SaveChangesAsync();
        
        if (request.ImageFile != null)
            fileService.DeleteFile(Directories.BannerImages, oldImageName);
        
        return OperationResult.Success();
    }
}