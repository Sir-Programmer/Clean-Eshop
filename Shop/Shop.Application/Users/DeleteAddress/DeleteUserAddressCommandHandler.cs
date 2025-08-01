using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.DeleteAddress;

public class DeleteUserAddressCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<DeleteUserAddressCommand>
{
    public async Task<OperationResult> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdTrackingAsync(request.UserId);
        if (user == null)
            return OperationResult.NotFound();
        user.RemoveAddress(request.AddressId);

        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}