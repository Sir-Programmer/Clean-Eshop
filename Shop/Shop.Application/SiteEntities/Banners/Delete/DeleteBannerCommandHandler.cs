using Common.Application;
using Common.Application.FileUtil;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Banner.Repository;

namespace Shop.Application.SiteEntities.Banners.Delete;

public class DeleteBannerCommandHandler(IBannerRepository bannerRepository, IUnitOfWork unitOfWork, IFileService fileService) : IBaseCommandHandler<DeleteBannerCommand>
{
    public async Task<OperationResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await bannerRepository.GetByIdAsync(request.BannerId);
        if (banner == null) return OperationResult.NotFound();
        bannerRepository.Delete(banner);
        await unitOfWork.SaveChangesAsync();
        fileService.DeleteFile(Directories.BannerImages, banner.ImageName);
        return OperationResult.Success();
    }
}