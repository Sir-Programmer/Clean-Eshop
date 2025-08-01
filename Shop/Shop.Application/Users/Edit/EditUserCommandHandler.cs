using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit;

public class EditUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IUserDomainService userDomainService) : IBaseCommandHandler<EditUserCommand>
{
    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdTrackingAsync(request.UserId);
        if (user == null)
            return OperationResult.NotFound();
        user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender, userDomainService);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}