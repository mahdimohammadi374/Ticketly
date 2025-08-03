using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using Ticketly.common.Presentation.ApiResults;
using Ticketly.common.Presentation.Endpoints;
using Ticketly.Common.Domain;
using Ticketly.Modules.Events.Application.TicketTypes.GetTicketType;
using Ticketly.Modules.Events.Application.TicketTypes.GetTicketTypes;

namespace Ticketly.Modules.Events.Presentation.TicketTypes;

internal class GetTicketTypes : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("ticket-types", async (Guid eventId, ISender sender) =>
        {
            Result<IReadOnlyCollection<TicketTypeResponse>> result = await sender.Send(
                new GetTicketTypesQuery(eventId));

            return result.Match(Results.Ok, common.Presentation.ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.TicketTypes);
    }
}
