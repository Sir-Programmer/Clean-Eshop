using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.SetActiveAddress;

public class SetUserActiveAddressCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<SetUserActiveAddressCommand>
{
    public async Task<OperationResult> Handle(SetUserActiveAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdTrackingAsync(request.UserId);
        if (user == null)
            return OperationResult.NotFound();
        user.SetActiveAddress(request.AddressId);
        
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}