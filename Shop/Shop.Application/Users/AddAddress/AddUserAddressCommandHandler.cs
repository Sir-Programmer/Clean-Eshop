using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.AddAddress;

public class AddUserAddressCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<AddUserAddressCommand>
{
    public async Task<OperationResult> Handle(AddUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdTrackingAsync(request.UserId);
        if (user == null)
            return OperationResult.NotFound();
        
        var address = new UserAddress(request.Province, request.City, request.PostalCode, request.FullName, request.PostalAddress, request.PhoneNumber, request.NationalId);
        user.AddAddress(address);

        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}