using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => new { c.UserID, c.ContactID });
        builder.HasOne(c => c.User)
            .WithMany(u => u.Contacts)
            .HasForeignKey(c => c.UserID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(c => c.ContactUser)
            .WithMany()
            .HasForeignKey(c => c.ContactID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(c => c.Status)
            .IsRequired()
            .HasMaxLength(50);
    }
}
