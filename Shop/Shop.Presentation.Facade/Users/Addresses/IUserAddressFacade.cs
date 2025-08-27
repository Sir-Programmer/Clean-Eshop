using Common.Application.OperationResults;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Application.Users.SetActiveAddress;
using Shop.Query.Users.DTOs;

namespace Shop.Presentation.Facade.Users.Addresses;

public interface IUserAddressFacade
{
    Task<OperationResult> AddAddress(AddUserAddressCommand command);
    Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);
    Task<OperationResult> EditAddress(EditUserAddressCommand command);
    Task<OperationResult> SetActiveAddress(SetUserActiveAddressCommand command);
    
    Task<UserAddressDto?> GetById(Guid id);
    Task<List<UserAddressDto>?> GetList(Guid userId);
}