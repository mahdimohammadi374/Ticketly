using System;
using System.Collections.Generic;
using Ticketly.Modules.Events.Application.Abstractions.Messaging;
using Ticketly.Modules.Events.Application.TicketTypes.GetTicketType;

namespace Ticketly.Modules.Events.Application.TicketTypes.GetTicketTypes;

public sealed record GetTicketTypesQuery(Guid EventId) : IQuery<IReadOnlyCollection<TicketTypeResponse>>;
