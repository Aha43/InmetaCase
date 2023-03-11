using InmetaCase.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InmetaCase.Infrastructure.Database;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
        var cs = Configuration.GetConnectionString("InmetaCaseDb");
        Database.SetConnectionString(cs);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var cs = Configuration.GetConnectionString("InmetaCaseDb");
        options.UseSqlServer(cs);
    }

#nullable disable
    public DbSet<Address> Address { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Order> Order { get; set; }
#nullable enable

}
