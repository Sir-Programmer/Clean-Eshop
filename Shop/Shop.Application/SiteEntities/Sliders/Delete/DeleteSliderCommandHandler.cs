using Common.Application;
using Common.Application.FileUtil;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Slider.Repository;

namespace Shop.Application.SiteEntities.Sliders.Delete;

public class DeleteSliderCommandHandler(ISliderRepository sliderRepository, IUnitOfWork unitOfWork, IFileService fileService) : IBaseCommandHandler<DeleteSliderCommand>
{
    public async Task<OperationResult> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = await sliderRepository.GetByIdAsync(request.SliderId);
        if (slider == null) return OperationResult.NotFound();
        sliderRepository.Delete(slider);
        await unitOfWork.SaveChangesAsync();
        fileService.DeleteFile(Directories.SliderImages, slider.ImageName);
        return OperationResult.Success();
    }
}