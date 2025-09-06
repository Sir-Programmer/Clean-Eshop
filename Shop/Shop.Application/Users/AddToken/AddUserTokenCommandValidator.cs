using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.AddToken;

public class AddUserTokenCommandValidator : AbstractValidator<AddUserTokenCommand>
{
    public AddUserTokenCommandValidator()
    {
        RuleFor(x => x.TokenHash)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("توکن"));
        
        RuleFor(x => x.RefreshTokenHash)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("رفرش توکن"));
        
        RuleFor(x => x.Device)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("اطلاعات دستگاه"));
    }
}