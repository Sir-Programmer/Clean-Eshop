using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.ResetPassword;

public class ResetUserPasswordCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<ResetUserPasswordCommand>
{
    public async Task<OperationResult> Handle(ResetUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);
        if (user == null) return OperationResult.NotFound();
        user.ChangePassword(request.NewPassword);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}