using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Edit;

public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
{
    public EditCommentCommandValidator()
    {
        RuleFor(command => command.Text)
            .NotEmpty().WithMessage(ValidationMessages.Required("متن نظر"))
            .MinimumLength(5).WithMessage(ValidationMessages.MinLength("متن نظر", 5))
            .MaximumLength(200).WithMessage(ValidationMessages.MaxLength("متن نظر", 200));
    }
}