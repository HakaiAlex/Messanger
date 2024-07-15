using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Messenger.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.EntityTypeConfigurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(mes => mes.ID);
        builder.HasIndex(mes => mes.ID).IsUnique();
        builder.Property(mes => mes.Content).HasMaxLength(4096);
    }
}
