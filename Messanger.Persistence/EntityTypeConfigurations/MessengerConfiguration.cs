using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Messenger.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.EntityTypeConfigurations;

public class MessengerConfiguration : IEntityTypeConfiguration<Msger>
{
    public void Configure(EntityTypeBuilder<Msger> builder)
    {
        
    }
}
