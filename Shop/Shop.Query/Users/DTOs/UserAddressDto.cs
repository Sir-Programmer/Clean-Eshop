namespace Shop.Query.Users.DTOs;

public class UserAddressDto
{
    public Guid UserId { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string FullName { get; set; }
    public string PostalAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalId { get; set; }
    public bool IsActive { get; set; }
}