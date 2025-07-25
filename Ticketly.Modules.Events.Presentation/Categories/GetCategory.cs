﻿using Ticketly.Modules.Events.Application.Categories.GetCategory;
using Ticketly.Modules.Events.Domain.Abstractions;
using Ticketly.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace Ticketly.Modules.Events.Presentation.Categories;

internal static class GetCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories/{id}", async (Guid id, ISender sender) =>
        {
            Result<CategoryResponse> result = await sender.Send(new GetCategoryQuery(id));

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
