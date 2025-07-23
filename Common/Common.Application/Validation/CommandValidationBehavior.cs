using System.Text;
using Common.Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Common.Application.Validation
{
    public class CommandValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var errors = validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (errors.Count != 0)
            {
                var errorBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    errorBuilder.AppendLine(error.ErrorMessage);
                }
                throw new InvalidCommandException(errorBuilder.ToString());
            }
            var response = await next(cancellationToken);
            return response;
        }
    }
}