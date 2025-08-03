﻿using Microsoft.AspNetCore.Routing;

namespace Ticketly.common.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
