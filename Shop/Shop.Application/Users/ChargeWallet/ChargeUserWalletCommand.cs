using Common.Application;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.ChargeWallet;

public record ChargeUserWalletCommand(Guid UserId, int Price, WalletType Type, string Description, bool IsFinally) : IBaseCommand;