using Microsoft.EntityFrameworkCore;
using MyCrmNet.Infrastructure.Models;

namespace MyCrmNet.Infrastructure;

public class MyCrmNetDbContext : DbContext
{
    public MyCrmNetDbContext(DbContextOptions<MyCrmNetDbContext> options)
        : base(options) { }

    public DbSet<OpportunityDbModel> Opportunities { get; set; }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<ContactDbModel> Contacts { get; set; }

    public DbSet<LeadDbModel> Leads { get; set; }
}
