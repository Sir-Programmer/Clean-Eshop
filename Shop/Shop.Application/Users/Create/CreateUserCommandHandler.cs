using Common.Application;
using Common.Application.OperationResults;
using Common.Application.SecurityUtil;
using Common.Application.UnitOfWork;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Create;

public class CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IUserDomainService userDomainService) : IBaseCommandHandler<CreateUserCommand>
{
    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Family, request.PhoneNumber, request.Email, request.Password.ToMd5(), request.Gender, userDomainService);
        await userRepository.AddAsync(user);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}