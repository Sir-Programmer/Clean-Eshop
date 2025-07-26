using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.Checkout;

public class CheckoutOrderCommandHandlerValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandHandlerValidator()
    {
        RuleFor(f => f.FullName)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام"));

        RuleFor(f => f.City)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("شهر"));

        RuleFor(f => f.Province)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("استان"));

        RuleFor(f => f.PostalAddress)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("ادرس کامل"));

        RuleFor(f => f.PostalCode)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("کد پستی"))
            .Length(10).WithMessage("کد پستی نامعبتر است");

        RuleFor(f => f.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("شماره موبایل"))
            .ValidPhoneNumber();

        RuleFor(f => f.NationalId)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("کد ملی"))
            .ValidNationalId();
    }
}