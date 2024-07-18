using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.Participants)
            .WithMany(u => u.Chats);
        builder.HasMany(c => c.Messages)
            .WithOne()
            .HasForeignKey(m => m.Id);
        builder.HasOne(g => g.Admin)
                .WithMany()
                .HasForeignKey(g => g.AdminId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
