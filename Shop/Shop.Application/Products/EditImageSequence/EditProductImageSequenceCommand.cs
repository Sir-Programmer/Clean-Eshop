using Common.Application;

namespace Shop.Application.Products.EditImageSequence;

public record EditProductImageSequenceCommand(Guid ProductId, Guid ImageId, int Sequence) : IBaseCommand;