using CosmosDb.Model;
using Microsoft.EntityFrameworkCore;

namespace CosmosDb.Data;

public class CosmosContext : DbContext
{
    public CosmosContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Employee>().
                   ToContainer("").// Container name
                   HasPartitionKey(d => d.Id);
    }


}
