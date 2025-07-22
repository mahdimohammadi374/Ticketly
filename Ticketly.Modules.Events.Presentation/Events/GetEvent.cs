using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using Ticketly.Modules.Events.Application.Events;
using Ticketly.Modules.Events.Application.Events.GetEvent;
using Ticketly.Modules.Events.Domain.Abstractions;
using Ticketly.Modules.Events.Presentation.ApiResults;

namespace Ticketly.Modules.Events.Presentation.Events;
internal static class GetEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id}", async (Guid id, ISender sender) =>
        {
            Result<EventResponse> result = await sender.Send(new GetEventQuery(id));

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Events);
    }
}

