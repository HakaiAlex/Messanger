using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Messenger.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.EntityTypeConfigurations;

public class MessengerConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        
    }
}
