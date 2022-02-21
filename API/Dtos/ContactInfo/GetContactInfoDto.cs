using API.Models;

namespace API.Dtos.ContactInfo;

public class GetContactInfoDto
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public ContactType ContactType { get; set; }
}