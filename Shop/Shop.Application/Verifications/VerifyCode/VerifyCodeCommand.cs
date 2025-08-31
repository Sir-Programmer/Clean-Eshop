using Common.Application;

namespace Shop.Application.Verifications.VerifyCode;

public record VerifyCodeCommand(string PhoneNumber, string Code) : IBaseCommand;