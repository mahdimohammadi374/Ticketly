using System;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using Ticketly.common.Presentation.ApiResults;
using Ticketly.common.Presentation.Endpoints;
using Ticketly.Common.Domain;
using Ticketly.Modules.Events.Application.Categories.GetCategory;

namespace Ticketly.Modules.Events.Presentation.Categories;

internal class GetCategory : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories/{id}", async (Guid id, ISender sender) =>
        {
            Result<CategoryResponse> result = await sender.Send(new GetCategoryQuery(id));

            return result.Match(Results.Ok, common.Presentation.ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
