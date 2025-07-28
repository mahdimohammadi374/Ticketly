using Ticketly.Common.Application.Messaging;
using Ticketly.Modules.Events.Application.TicketTypes.GetTicketType;

namespace Ticketly.Modules.Events.Application.TicketTypes.GetTicketTypes;

public sealed record GetTicketTypesQuery(Guid EventId) : IQuery<IReadOnlyCollection<TicketTypeResponse>>;
