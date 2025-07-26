using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.Checkout;

public class CheckoutOrderCommandHandlerValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandHandlerValidator()
    {
        RuleFor(command => command.FullName)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام"));

        RuleFor(command => command.City)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("شهر"));

        RuleFor(command => command.Province)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("استان"));

        RuleFor(command => command.PostalAddress)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("ادرس کامل"));

        RuleFor(command => command.PostalCode)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("کد پستی"))
            .Length(10).WithMessage("کد پستی نامعبتر است");

        RuleFor(command => command.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("شماره موبایل"))
            .ValidPhoneNumber();

        RuleFor(command => command.NationalId)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("کد ملی"))
            .ValidNationalId();
    }
}