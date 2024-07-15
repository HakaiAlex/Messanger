using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.EntityTypeConfigurations;

public class GroupConfiguration : IEntityTypeConfiguration<GroupEntity>
{
    public void Configure(EntityTypeBuilder<GroupEntity> builder)
    {
        builder.HasKey(g => g.ID);
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasMany(g => g.Participants)
            .WithMany(u => u.Groups);
        builder.HasOne(g => g.Admin)
            .WithMany()
            .HasForeignKey(g => g.AdminID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
