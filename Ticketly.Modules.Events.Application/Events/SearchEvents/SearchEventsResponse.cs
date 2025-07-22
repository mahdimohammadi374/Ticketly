using System.Collections.Generic;
using Ticketly.Modules.Events.Application.Events.GetEvents;

namespace Ticketly.Modules.Events.Application.Events.SearchEvents;

public sealed record SearchEventsResponse(
    int Page,
    int PageSize,
    int TotalCount,
    IReadOnlyCollection<EventResponse> Events);
