using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.EntityTypeConfigurations;

public class ChatConfiguration : IEntityTypeConfiguration<ChatEntity>
{
    public void Configure(EntityTypeBuilder<ChatEntity> builder)
    {
        builder.HasKey(c => c.ID);
        builder.HasMany(c => c.Participants)
            .WithMany(u => u.Chats);
        builder.HasMany(c => c.Messages)
            .WithOne()
            .HasForeignKey(m => m.ID);
    }
}
