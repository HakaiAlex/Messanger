using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Content)
            .IsRequired();
        builder.Property(m => m.Timestamp)
            .IsRequired();
        builder.HasOne(m => m.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(m => m.SenderID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(m => m.Receiver)
            .WithMany(u => u.ReceivedMessages)
            .HasForeignKey(m => m.ReceiverID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
