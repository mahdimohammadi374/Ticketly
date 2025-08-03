using System;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using Ticketly.common.Presentation.ApiResults;
using Ticketly.common.Presentation.Endpoints;
using Ticketly.Common.Domain;
using Ticketly.Modules.Events.Application.Events;
using Ticketly.Modules.Events.Application.Events.GetEvent;

namespace Ticketly.Modules.Events.Presentation.Events;
internal class GetEvent : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id}", async (Guid id, ISender sender) =>
        {
            Result<EventResponse> result = await sender.Send(new GetEventQuery(id));

            return result.Match(Results.Ok, common.Presentation.ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Events);
    }
}

