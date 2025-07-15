namespace Common.Domain.Exceptions;

public class NullOrEmptyDomainException : BaseDomainException
{
    public NullOrEmptyDomainException()
    {
        
    }

    public NullOrEmptyDomainException(string message) : base(message)
    {
        
    }

    public static void CheckString(string value, string nameOfField)
    {
        if (string.IsNullOrEmpty(value))
            throw new NullOrEmptyDomainException($"{nameOfField} cannot be null or empty.");
    }
}