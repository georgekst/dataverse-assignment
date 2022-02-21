namespace API.Models;

public class Client
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<ContactInfo> ContactInfo { get; set; } = new List<ContactInfo>();
    public string Address { get; set; }
    public string Email { get; set; }
}