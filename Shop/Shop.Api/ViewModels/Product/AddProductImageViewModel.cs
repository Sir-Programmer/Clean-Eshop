namespace Shop.Api.ViewModels.Product;

public class AddProductImageViewModel
{
    public IFormFile ImageFile { get; set; }
    public int Sequence { get; set; }
}