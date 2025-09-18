using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditProfile;

public class EditUserProfileCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<EditUserProfileCommand>
{
    public async Task<OperationResult> Handle(EditUserProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);
        if (user == null) return OperationResult.NotFound();
        user.EditProfile(request.Name, request.Family, request.Gender);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}