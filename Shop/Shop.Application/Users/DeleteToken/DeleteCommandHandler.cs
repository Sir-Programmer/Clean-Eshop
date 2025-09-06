using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.DeleteToken;

public class DeleteCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<DeleteTokenCommand>
{
    public async Task<OperationResult> Handle(DeleteTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);
        if (user == null)
            return OperationResult.NotFound();
        user.RemoveToken(request.TokenId);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}