using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ChargeWallet;

public class ChargeUserWalletCommandValidator : AbstractValidator<ChargeUserWalletCommand>
{
    public ChargeUserWalletCommandValidator()
    {
        RuleFor(command => command.Price)
            .GreaterThanOrEqualTo(1000)
            .WithMessage(ValidationMessages.MinLength("مبلغ", 1000));
        
        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("توضیحات"));
    }
}