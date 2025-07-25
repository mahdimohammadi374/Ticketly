﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Ticketly.Modules.Events.Domain.Events;
using Ticketly.Modules.Events.Infrastructure.Database;

namespace Ticketly.Modules.Events.Infrastructure.Events;

internal sealed class EventRepository(EventsDbContext context) : IEventRepository
{
    public async Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Events.SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
    public void Insert(Event @event)
    {
        context.Events.Add(@event);
    }
}
