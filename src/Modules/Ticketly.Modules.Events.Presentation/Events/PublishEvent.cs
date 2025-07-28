﻿using Ticketly.Modules.Events.Application.Events.PublishEvent;
using Ticketly.Modules.Events.Domain.Abstractions;
using Ticketly.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace Ticketly.Modules.Events.Presentation.Events;

internal static class PublishEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("events/{id}/publish", async (Guid id, ISender sender) =>
        {
            Result result = await sender.Send(new PublishEventCommand(id));

            return result.Match(Results.NoContent, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Events);
    }
}
