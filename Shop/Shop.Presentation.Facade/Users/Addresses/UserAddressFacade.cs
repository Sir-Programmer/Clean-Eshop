using Common.Application.OperationResults;
using MediatR;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Application.Users.SetActiveAddress;
using Shop.Query.Users.Addresses.GetById;
using Shop.Query.Users.Addresses.GetList;
using Shop.Query.Users.DTOs;

namespace Shop.Presentation.Facade.Users.Addresses;

public class UserAddressFacade(IMediator mediator) : IUserAddressFacade
{
    public async Task<OperationResult> Add(AddUserAddressCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Delete(DeleteUserAddressCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditUserAddressCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> SetActive(SetUserActiveAddressCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<UserAddressDto?> GetById(Guid userId, Guid id)
    {
        return await mediator.Send(new GetUserAddressByIdQuery(userId, id));
    }

    public async Task<List<UserAddressDto>?> GetList(Guid userId)
    {
        return await mediator.Send(new GetUserAddressListQuery(userId));
    }
}