using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApp.Core.Domain.Entities;

namespace TaxiApp.Infrastructure.Persistence.Configuration;

public class UserGroupEntityConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.HasKey(ug => ug.Id);
        builder.ToTable("UserGroups");

        builder
            .HasMany(ug => ug.UserGroupDetails)
            .WithOne(ugd => ugd.UserGroup)
            .HasForeignKey(ugd => ugd.UserGroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}