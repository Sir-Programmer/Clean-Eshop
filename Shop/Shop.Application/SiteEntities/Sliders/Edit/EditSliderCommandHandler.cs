using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Slider.Repository;

namespace Shop.Application.SiteEntities.Sliders.Edit;

public class EditSliderCommandHandler(ISliderRepository sliderRepository, IUnitOfWork unitOfWork, IFileService fileService) : IBaseCommandHandler<EditSliderCommand>
{
    public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = await sliderRepository.GetByIdTrackingAsync(request.SliderId);
        if (slider == null) return OperationResult.NotFound();
        
        var imageName = slider.ImageName;
        var oldImageName = slider.ImageName;
        
        if (request.ImageFile != null)
            imageName = await fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
        
        slider.Edit(request.Title, request.Url, imageName, request.IsActive);
        
        if (request.ImageFile != null)
            fileService.DeleteFile(Directories.SliderImages, oldImageName);
        
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}