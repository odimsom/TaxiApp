using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Core.Domain.Entities;

namespace TaxiApp.Infrastructure.Persistence.Configuration;

public class TripEntityConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.HasKey(t => t.Id);
        builder.ToTable("Trips");

        builder.Property(t => t.StartDate)
            .IsRequired();

        builder.Property(t => t.EndDate)
            .IsRequired();

        builder.Property(t => t.From)
            .HasMaxLength(500);

        builder.Property(t => t.To)
            .HasMaxLength(500);

        builder.Property(t => t.UserId)
            .IsRequired();

        builder
            .HasOne(t => t.User)
            .WithMany(u => u.Trips)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(t => t.TripDetails)
            .WithOne(td => td.Trip)
            .HasForeignKey(d => d.TripId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}