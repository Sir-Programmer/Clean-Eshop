using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Comments.Create;

internal class CreateCommentCommandHandler(ICommentRepository commentRepository, IProductRepository productRepository, IUserRepository userRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<CreateCommentCommand>
{
    public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.ExistsAsync(u => u.Id == request.UserId))
            return OperationResult.NotFound("کاربر مورد نظر یافت نشد");
        if (await productRepository.ExistsAsync(p => p.Id == request.ProductId))
            return OperationResult.NotFound("محصول مورد نظر یافت نشد");

        var comment = new Comment(request.UserId, request.Text, request.ProductId);
        await commentRepository.AddAsync(comment);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}