using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketly.Modules.Events.Domain.Events;
using Ticketly.Modules.Events.Domain.TicketTypes;

namespace Ticketly.Modules.Events.Infrastructure.TicketTypes;

internal sealed class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
{
    public void Configure(EntityTypeBuilder<TicketType> builder)
    {
        builder.HasOne<Event>().WithMany().HasForeignKey(t => t.EventId);
    }
}
