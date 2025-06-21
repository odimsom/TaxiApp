using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Core.Domain.Entities;

namespace TaxiApp.Infrastructure.Persistence.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.ToTable("Users");

        builder.Property(u => u.DocumentId)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(150);

        builder
            .HasMany(u => u.UserGroupDetails)
            .WithOne(ug => ug.User)
            .HasForeignKey(ugd => ugd.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(u => u.Trips)
            .WithOne(ug => ug.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}