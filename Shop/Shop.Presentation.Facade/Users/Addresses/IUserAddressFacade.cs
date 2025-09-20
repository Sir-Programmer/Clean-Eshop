using Common.Application.OperationResults;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Application.Users.SetActiveAddress;
using Shop.Query.Users.DTOs;

namespace Shop.Presentation.Facade.Users.Addresses;

public interface IUserAddressFacade
{
    Task<OperationResult> Add(AddUserAddressCommand command);
    Task<OperationResult> Delete(DeleteUserAddressCommand command);
    Task<OperationResult> Edit(EditUserAddressCommand command);
    Task<OperationResult> SetActive(SetUserActiveAddressCommand command);
    
    Task<UserAddressDto?> GetById(Guid userId, Guid id);
    Task<List<UserAddressDto>?> GetList(Guid userId);
}