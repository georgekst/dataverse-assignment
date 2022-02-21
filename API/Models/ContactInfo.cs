using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public enum ContactType
{
    Home,
    Work,
    Mobile
}

public class ContactInfo
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; } = null;
    public string PhoneNumber { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public ContactType ContactType { get; set; }
}