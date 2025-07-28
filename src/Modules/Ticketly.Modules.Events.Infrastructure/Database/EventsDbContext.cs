using Microsoft.EntityFrameworkCore;

using Ticketly.Modules.Events.Application.Abstractions.Data;
using Ticketly.Modules.Events.Domain.Categories;
using Ticketly.Modules.Events.Domain.Events;
using Ticketly.Modules.Events.Domain.TicketTypes;
using Ticketly.Modules.Events.Infrastructure.Events;
using Ticketly.Modules.Events.Infrastructure.TicketTypes;

namespace Ticketly.Modules.Events.Infrastructure.Database;
public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Event> Events { get; set; }

    internal DbSet<Category> Categories { get; set; }

    internal DbSet<TicketType> TicketTypes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);

        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new TicketTypeConfiguration());
    }
}
