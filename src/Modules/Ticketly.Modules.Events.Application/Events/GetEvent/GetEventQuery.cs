using Ticketly.Common.Application.Messaging;

namespace Ticketly.Modules.Events.Application.Events.GetEvent;
public sealed record GetEventQuery(Guid EventId) : IQuery<EventResponse>;
