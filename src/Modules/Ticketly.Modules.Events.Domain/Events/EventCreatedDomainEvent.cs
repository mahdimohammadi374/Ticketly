using System;
using Ticketly.Modules.Events.Domain.Abstractions;

namespace Ticketly.Modules.Events.Domain.Events;

public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}

