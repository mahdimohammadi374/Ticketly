﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ticketly.Modules.Events.Domain.TicketTypes;

public interface ITicketTypeRepository
{
    Task<TicketType> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Guid eventId, CancellationToken cancellationToken = default);

    void Insert(TicketType ticketType);
}
