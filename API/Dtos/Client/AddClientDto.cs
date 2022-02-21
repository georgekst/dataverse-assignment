using API.Dtos.ContactInfo;

namespace API.Dtos.Client;

public class AddClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<AddContactInfoDto> ContactInfo { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
}