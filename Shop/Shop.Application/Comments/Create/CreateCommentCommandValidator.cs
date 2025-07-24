using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Create;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty().WithMessage(ValidationMessages.Required("UserId"));
        RuleFor(command => command.ProductId)
            .NotEmpty().WithMessage(ValidationMessages.Required("ProductId"));
        RuleFor(command => command.Text)
            .NotEmpty().WithMessage(ValidationMessages.Required("متن نظر"))
            .MinimumLength(5).WithMessage(ValidationMessages.MinLength("متن نظر", 5))
            .MaximumLength(200).WithMessage(ValidationMessages.MaxLength("متن نظر", 200));
    }
}