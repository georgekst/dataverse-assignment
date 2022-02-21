using API.Dtos.ContactInfo;

namespace API.Dtos.Client;

public class UpdateClientDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<UpdateContactInfoDto> ContactInfo { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
}