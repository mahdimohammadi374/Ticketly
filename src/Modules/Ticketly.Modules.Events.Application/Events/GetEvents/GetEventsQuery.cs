using Ticketly.Common.Application.Messaging;

namespace Ticketly.Modules.Events.Application.Events.GetEvents;

public sealed record GetEventsQuery : IQuery<IReadOnlyCollection<EventResponse>>;
