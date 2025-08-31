using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Auth;

public class LoginViewModel
{
    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [Length(11, 11, ErrorMessage = "{0} نا معتبر است")]
    public required string PhoneNumber { get; set; }
    
    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MinLength(6, ErrorMessage = "{0} نمیتواند کمتر از {1} کارکتر داشته باشد")]
    [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}