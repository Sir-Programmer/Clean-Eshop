using Common.Application.OperationResults;
using Common.Application.SecurityUtil;
using MediatR;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.ChangePassword;
using Shop.Application.Users.ChargeWallet;
using Shop.Application.Users.Create;
using Shop.Application.Users.DeleteToken;
using Shop.Application.Users.Edit;
using Shop.Application.Users.EditProfile;
using Shop.Application.Users.Register;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.DTOs.Filter;
using Shop.Query.Users.GetByFilter;
using Shop.Query.Users.GetById;
using Shop.Query.Users.GetByPhoneNumber;
using Shop.Query.Users.UserTokens.GetByJwtToken;
using Shop.Query.Users.UserTokens.GetByRefreshToken;

namespace Shop.Presentation.Facade.Users;

public class UserFacade(IMediator mediator) : IUserFacade
{
    public async Task<OperationResult<Guid>> Create(CreateUserCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditUserCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> EditProfile(EditUserProfileCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> ChargeWallet(ChargeUserWalletCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> AddToken(AddUserTokenCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> DeleteToken(DeleteUserTokenCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Register(RegisterUserCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<UserDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetUserByIdQuery(id));
    }

    public async Task<UserDto?> GetByPhoneNumber(string phoneNumber)
    {
        return await mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }

    public async Task<UserTokenDto?> GetByRefreshToken(string refreshToken)
    {
        return await mediator.Send(new GetUserTokenByRefreshTokenQuery(refreshToken.ToSha256()));
    }

    public async Task<UserTokenDto?> GetByJwtToken(string jwtToken)
    {
        return await mediator.Send(new GetUserTokenByJwtTokenQuery(jwtToken.ToSha256()));
    }

    public async Task<UserFilterResult> GetByFilter(UserFilterParams filters)
    {
        return await mediator.Send(new GetUserByFilterQuery(filters));
    }
}