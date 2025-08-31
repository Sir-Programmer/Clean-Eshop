using System.Windows.Input;
using Common.Application;

namespace Shop.Application.Verifications.RequestCode;

public record RequestCodeCommand(string PhoneNumber) : IBaseCommand;