using System.Collections.Generic;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using Ticketly.common.Presentation.ApiResults;
using Ticketly.common.Presentation.Endpoints;
using Ticketly.Common.Domain;
using Ticketly.Modules.Events.Application.Events.GetEvents;

namespace Ticketly.Modules.Events.Presentation.Events;

internal class GetEvents : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events", async (ISender sender) =>
        {
            Result<IReadOnlyCollection<EventResponse>> result = await sender.Send(new GetEventsQuery());

            return result.Match(Results.Ok, common.Presentation.ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Events);
    }
}
