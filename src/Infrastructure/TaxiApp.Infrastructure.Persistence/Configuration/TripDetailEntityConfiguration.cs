using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Core.Domain.Entities;

namespace TaxiApp.Infrastructure.Persistence.Configuration;

public class TripDetailEntityConfiguration : IEntityTypeConfiguration<TripDetail>
{
    public void Configure(EntityTypeBuilder<TripDetail> builder)
    {
        builder.HasKey(td => td.Id);
        builder.ToTable("TripDetails");

        builder.Property(td => td.Longitude)
            .HasMaxLength(100);

        builder.Property(td => td.Latitude)
            .HasMaxLength(100);

        builder.Property(td => td.Date)
            .IsRequired();

        builder.Property(td => td.TripId)
            .IsRequired();

        builder
            .HasOne(td => td.Trip)
            .WithMany(t => t.TripDetails)
            .HasForeignKey(td => td.TripId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}