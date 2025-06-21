using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Core.Domain.Entities;

namespace TaxiApp.Infrastructure.Persistence.Configuration;

public class UserGroupDetailEntityConfiguration : IEntityTypeConfiguration<UserGroupDetail>
{
    public void Configure(EntityTypeBuilder<UserGroupDetail> builder)
    {
        builder.HasKey(ugd => ugd.Id);
        builder.ToTable("UserGroupDetails");

        builder.Property(ugd => ugd.UserId).IsRequired();
        builder.Property(ugd => ugd.UserGroupId).IsRequired();

        builder
            .HasOne(ugd => ugd.User)
            .WithMany(u => u.UserGroupDetails)
            .HasForeignKey(ugd => ugd.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(ugd => ugd.UserGroup)
            .WithMany(ug => ug.UserGroupDetails)
            .HasForeignKey(ugd => ugd.UserGroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}