using Microsoft.AspNetCore.Routing;

namespace Ticketly.Modules.Events.Presentation.Events;

public static class EventEndpoints
{
    public static void MapEndPoints(IEndpointRouteBuilder app)
    {
        CreateEvent.MapEndpoint(app);
        GetEvent.MapEndpoint(app);
    }
}
