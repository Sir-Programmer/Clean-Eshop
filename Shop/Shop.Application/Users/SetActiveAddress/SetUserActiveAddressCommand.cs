using Common.Application;

namespace Shop.Application.Users.SetActiveAddress;

public record SetUserActiveAddressCommand(Guid UserId, Guid AddressId) : IBaseCommand;