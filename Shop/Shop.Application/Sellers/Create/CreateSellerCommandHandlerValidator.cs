using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Sellers.Create;

public class CreateSellerCommandHandlerValidator : AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandHandlerValidator()
    {
        RuleFor(command => command.NationalId)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("کد ملی"))
            .ValidNationalId();
        
        RuleFor(command => command.ShopName)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام فروشگاه"));
    }
}