using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.Checkout;

public class CheckoutOrderCommandHandlerValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandHandlerValidator()
    {
        RuleFor(command => command.FullName)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام"));

        RuleFor(command => command.City)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("شهر"));

        RuleFor(command => command.Province)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("استان"));

        RuleFor(command => command.PostalAddress)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("ادرس کامل"));

        RuleFor(command => command.PostalCode)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("کد پستی"))
            .Length(10).WithMessage("کد پستی نامعبتر است");

        RuleFor(command => command.PhoneNumber)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("شماره موبایل"))
            .ValidPhoneNumber();

        RuleFor(command => command.NationalId)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("کد ملی"))
            .ValidNationalId();
    }
}