using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<ContactInfo> ContactInfo { get; set; }
}