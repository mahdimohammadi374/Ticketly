﻿using Ticketly.Modules.Events.Application.Events.GetEvents;
using Ticketly.Modules.Events.Domain.Abstractions;
using Ticketly.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace Ticketly.Modules.Events.Presentation.Events;

internal static class GetEvents
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events", async (ISender sender) =>
        {
            Result<IReadOnlyCollection<EventResponse>> result = await sender.Send(new GetEventsQuery());

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Events);
    }
}
