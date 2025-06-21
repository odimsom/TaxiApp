using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Core.Domain.Entities;

namespace TaxiApp.Infrastructure.Persistence.Configuration;

public class TaxiEntityConfiguration : IEntityTypeConfiguration<Taxi>
{
    public void Configure(EntityTypeBuilder<Taxi> builder)
    {
        builder.HasKey(t => t.Id);
        builder.ToTable("Taxis");

        builder.Property(t => t.Plate)
            .HasMaxLength(50);

        builder.Property(t => t.TripId)
            .IsRequired();

        builder
            .HasOne(t => t.Trip)
            .WithOne(t => t.Taxi)
            .HasForeignKey<Taxi>(t => t.TripId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}