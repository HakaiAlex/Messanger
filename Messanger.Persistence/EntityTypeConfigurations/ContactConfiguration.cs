using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.EntityTypeConfigurations;

public class ContactConfiguration : IEntityTypeConfiguration<ContactEntity>
{
    public void Configure(EntityTypeBuilder<ContactEntity> builder)
    {
        builder.HasKey(c => new { c.UserID, c.ContactID });
        builder.HasOne(c => c.User)
            .WithMany(u => u.Contacts)
            .HasForeignKey(c => c.UserID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(c => c.Contact)
            .WithMany()
            .HasForeignKey(c => c.ContactID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(c => c.Status)
            .IsRequired()
            .HasMaxLength(50);
    }
}
