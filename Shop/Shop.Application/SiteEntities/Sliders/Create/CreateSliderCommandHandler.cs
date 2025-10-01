using Common.Application;
using Common.Application.FileUtil;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Slider;
using Shop.Domain.SiteEntities.Slider.Repository;

namespace Shop.Application.SiteEntities.Sliders.Create;

public class CreateSliderCommandHandler(ISliderRepository sliderRepository, IUnitOfWork unitOfWork, IFileService fileService) : IBaseCommandHandler<CreateSliderCommand, Guid>
{
    public async Task<OperationResult<Guid>> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        var imageName = await fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
        var slider = new Slider(request.Title, request.Url, imageName);
        await sliderRepository.AddAsync(slider);
        await unitOfWork.SaveChangesAsync();
        return OperationResult<Guid>.Success(slider.Id);
    }
}