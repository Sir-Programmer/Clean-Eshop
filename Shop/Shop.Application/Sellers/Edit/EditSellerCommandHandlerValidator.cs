using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Sellers.Edit;

public class EditSellerCommandHandlerValidator : AbstractValidator<EditSellerCommand>
{
    public EditSellerCommandHandlerValidator()
    {
        RuleFor(command => command.NationalId)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("کد ملی"))
            .ValidNationalId();
        
        RuleFor(command => command.ShopName)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام فروشگاه"));
    }
}