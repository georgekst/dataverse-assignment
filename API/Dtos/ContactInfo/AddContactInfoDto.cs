using API.Models;

namespace API.Dtos.ContactInfo;

public class AddContactInfoDto
{
    public string PhoneNumber { get; set; }
    public ContactType ContactType { get; set; }
}