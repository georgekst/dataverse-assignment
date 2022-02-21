using API.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Seed
{
    public static async Task SeedDatabase(DataContext context)
    {
        if (await context.Clients.AnyAsync()) return;
        
        var testContactInfo = new Faker<ContactInfo>()
            .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.ContactType, f => f.PickRandom<ContactType>());
        
        var testClients = new Faker<Client>()
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.ContactInfo, f => testContactInfo.Generate(2).ToList())
            .RuleFor(c => c.Address, f => f.Address.StreetAddress())
            .RuleFor(c => c.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName));

        var clients = testClients.Generate(5).ToList();
        await context.Clients.AddRangeAsync(clients);
        await context.SaveChangesAsync();
    }
}