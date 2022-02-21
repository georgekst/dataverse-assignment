using API.Models;

namespace API.Dtos.ContactInfo;

public class UpdateContactInfoDto
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public ContactType ContactType { get; set; }
}