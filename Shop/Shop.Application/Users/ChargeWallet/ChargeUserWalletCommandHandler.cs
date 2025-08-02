using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.ChargeWallet;

public class ChargeUserWalletCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<ChargeUserWalletCommand>
{
    public async Task<OperationResult> Handle(ChargeUserWalletCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdTrackingAsync(request.UserId);
        if (user == null) return OperationResult.NotFound();
        var wallet = new UserWallet(request.Price, request.Type, request.Description, request.IsFinally);
        user.ChargeWallet(wallet);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}