using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Verifications.RequestCode;

public class RequestCodeCommandValidator : AbstractValidator<RequestCodeCommand>
{
    public RequestCodeCommandValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .ValidPhoneNumber();
    }
}