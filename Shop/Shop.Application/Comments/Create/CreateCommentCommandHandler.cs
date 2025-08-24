using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Comments.Create;

internal class CreateCommentCommandHandler(ICommentRepository commentRepository, IProductRepository productRepository, IUserRepository userRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<CreateCommentCommand, Guid>
{
    public async Task<OperationResult<Guid>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.ExistsAsync(u => u.Id == request.UserId) || await productRepository.ExistsAsync(p => p.Id == request.ProductId))
            return OperationResult<Guid>.NotFound();

        var comment = new Comment(request.UserId, request.Text, request.ProductId);
        await commentRepository.AddAsync(comment);
        await unitOfWork.SaveChangesAsync();
        return OperationResult<Guid>.Success(comment.Id);
    }
}