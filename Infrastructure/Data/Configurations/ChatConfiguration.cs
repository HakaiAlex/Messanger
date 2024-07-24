using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.IsGroupChat)
            .IsRequired();
        builder.Property(c => c.AdminId)
            .IsRequired();

        builder.HasOne(c => c.Admin)
            .WithMany(u => u.Chats)
            .HasForeignKey(c => c.AdminId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(c => c.Participants)
            .WithMany(u => u.Chats)
            .UsingEntity<Dictionary<string, object>>(
                      "ChatUser",
                      j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                      j => j.HasOne<Chat>().WithMany().HasForeignKey("ChatId"));
        builder.HasMany(c => c.Messages)
            .WithOne(m => m.Chat)
            .HasForeignKey(m => m.ChatId);
    }
}
