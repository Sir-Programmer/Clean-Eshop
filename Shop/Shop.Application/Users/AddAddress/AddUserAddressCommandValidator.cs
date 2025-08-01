using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.AddAddress;

public class AddUserAddressCommandValidator : AbstractValidator<AddUserAddressCommand>
{
    public AddUserAddressCommandValidator()
    {
        RuleFor(command => command.Province)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("استان"));
        
        RuleFor(command => command.City)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("شهر"));

        RuleFor(command => command.PostalCode)
            .Length(10)
            .WithMessage("کد پستی نادرست است");
        
        RuleFor(command => command.FullName)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام و نام خانوادگی"));
        
        RuleFor(command => command.PostalAddress)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("آدرس پستی"));

        RuleFor(command => command.PhoneNumber)
            .ValidPhoneNumber();

        RuleFor(command => command.NationalId)
            .ValidNationalId();
    }
}