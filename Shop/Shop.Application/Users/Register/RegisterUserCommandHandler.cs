using Common.Application;
using Common.Application.OperationResults;
using Common.Application.SecurityUtil;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Register;

public class RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IUserDomainService userDomainService) : IBaseCommandHandler<RegisterUserCommand>
{
    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Register(request.PhoneNumber, request.Password.ToSha256(), userDomainService);
        await userRepository.AddAsync(user);
        
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}