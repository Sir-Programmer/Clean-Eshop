using Common.Application.OperationResults;
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

namespace Shop.Presentation.Facade.Users;

public interface IUserFacade
{
    Task<OperationResult<Guid>> Create(CreateUserCommand command);
    Task<OperationResult> Edit(EditUserCommand command);
    Task<OperationResult> EditProfile(EditUserProfileCommand command);
    Task<OperationResult> ChargeWallet(ChargeUserWalletCommand command);
    Task<OperationResult> AddToken(AddUserTokenCommand command);
    Task<OperationResult> DeleteToken(DeleteUserTokenCommand command);
    Task<OperationResult> Register(RegisterUserCommand command);
    Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command);
    
    
    Task<UserDto?> GetById(Guid id);
    Task<UserDto?> GetByPhoneNumber(string phoneNumber);
    Task<UserTokenDto?> GetByRefreshToken(string refreshToken);
    Task<UserTokenDto?> GetByJwtToken(string jwtToken);
    Task<UserFilterResult> GetByFilter(UserFilterParams filters);
}