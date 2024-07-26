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

        builder.HasMany(c => c.Participants)
            .WithMany(u => u.Chats);
        builder.HasMany(c => c.Messages)
            .WithOne(t => t.Chat)
            .HasForeignKey(m => m.ChatId);
    }
}
