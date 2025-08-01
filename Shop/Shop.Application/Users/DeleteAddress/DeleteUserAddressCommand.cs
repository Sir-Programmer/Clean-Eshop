using Common.Application;

namespace Shop.Application.Users.DeleteAddress;

public record DeleteUserAddressCommand(Guid UserId, Guid AddressId) : IBaseCommand;