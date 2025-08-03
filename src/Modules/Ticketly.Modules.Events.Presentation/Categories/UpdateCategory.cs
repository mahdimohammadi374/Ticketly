using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using Ticketly.common.Presentation.ApiResults;
using Ticketly.common.Presentation.Endpoints;
using Ticketly.Common.Domain;
using Ticketly.Modules.Events.Application.Categories.UpdateCategory;

namespace Ticketly.Modules.Events.Presentation.Categories;

internal class UpdateCategory : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id}", async (Guid id, Request request, ISender sender) =>
        {
            Result result = await sender.Send(new UpdateCategoryCommand(id, request.Name));

            return result.Match(() => Results.Ok(), common.Presentation.ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }

    internal sealed class Request
    {
        public string Name { get; init; }
    }
}
