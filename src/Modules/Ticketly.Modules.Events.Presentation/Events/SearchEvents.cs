using System;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using Ticketly.common.Presentation.ApiResults;
using Ticketly.common.Presentation.Endpoints;
using Ticketly.Common.Domain;
using Ticketly.Modules.Events.Application.Events.SearchEvents;

namespace Ticketly.Modules.Events.Presentation.Events;

internal class SearchEvents : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/search", async(
            ISender sender,
            Guid ? categoryId,
            DateTime? startDate,
            DateTime? endDate,
            int page = 0,
            int pageSize = 15) =>
        {
            Result<SearchEventsResponse> result = await sender.Send(
                new SearchEventsQuery(categoryId, startDate, endDate, page, pageSize));

            return result.Match(Results.Ok, common.Presentation.ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Events);
    }
}
