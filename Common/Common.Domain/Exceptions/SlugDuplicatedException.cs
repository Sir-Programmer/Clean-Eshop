namespace Common.Domain.Exceptions;

public class SlugDuplicatedException : BaseDomainException
{
    public SlugDuplicatedException() : base("Slug قبلا ثبت شده است")
    {
        
    }

    public SlugDuplicatedException(string message) : base(message)
    {
        
    }
}