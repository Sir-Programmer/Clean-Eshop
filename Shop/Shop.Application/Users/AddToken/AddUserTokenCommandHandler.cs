using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.AddToken;

public class AddUserTokenCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<AddUserTokenCommand>
{
    public async Task<OperationResult> Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);
        if  (user == null)
            return OperationResult.NotFound();
        user.AddToken(request.TokenHash, request.RefreshTokenHash, request.TokenExpireDate, request.RefreshTokenExpireDate, request.Device);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}