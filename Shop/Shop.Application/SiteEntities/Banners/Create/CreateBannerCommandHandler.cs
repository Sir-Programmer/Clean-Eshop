using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Banner;
using Shop.Domain.SiteEntities.Banner.Repository;

namespace Shop.Application.SiteEntities.Banners.Create;

public class CreateBannerCommandHandler(IBannerRepository bannerRepository, IUnitOfWork unitOfWork, IFileService fileService) : IBaseCommandHandler<CreateBannerCommand, Guid>
{
    public async Task<OperationResult<Guid>> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
    {
        var imageName = await fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
        var banner = new Banner(request.Url, imageName, request.Position);
        await bannerRepository.AddAsync(banner);
        await unitOfWork.SaveChangesAsync();
        return OperationResult<Guid>.Success(banner.Id);
    }
}