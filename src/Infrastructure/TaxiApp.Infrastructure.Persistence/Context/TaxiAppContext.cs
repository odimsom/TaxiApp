using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Core.Domain.Entities;

namespace TaxiApp.Infrastructure.Persistence.Context;

public class TaxiAppContext : DbContext
{
    public TaxiAppContext(DbContextOptions<TaxiAppContext> options) : base(options) { }
    
    #region Dbsets
    public DbSet<Taxi> Taxis { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<TripDetail> TripDetails { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserGroupDetail> UserGroupDetails { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}