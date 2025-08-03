using System;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using Ticketly.common.Presentation.ApiResults;
using Ticketly.common.Presentation.Endpoints;
using Ticketly.Common.Domain;
using Ticketly.Modules.Events.Application.TicketTypes.UpdateTicketTypePrice;

namespace Ticketly.Modules.Events.Presentation.TicketTypes;

internal class ChangeTicketTypePrice : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("ticket-types/{id}/price", async (Guid id, Request request, ISender sender) =>
            {
                Result result = await sender.Send(new UpdateTicketTypePriceCommand(id, request.Price));

                return result.Match(Results.NoContent, common.Presentation.ApiResults.ApiResults.Problem);
            })
            .WithTags(Tags.TicketTypes);
    }

    internal sealed class Request
    {
        public decimal Price { get; init; }
    }
}
