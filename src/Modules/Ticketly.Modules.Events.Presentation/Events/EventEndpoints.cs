using Microsoft.AspNetCore.Routing;

namespace Ticketly.Modules.Events.Presentation.Events;

public static class EventEndpoints
{
    public static void MapEndPoints(IEndpointRouteBuilder app)
    {
        CancelEvent.MapEndpoint(app);
        CreateEvent.MapEndpoint(app);
        GetEvent.MapEndpoint(app);
        GetEvents.MapEndpoint(app);
        PublishEvent.MapEndpoint(app);
        RescheduleEvent.MapEndpoint(app);
        SearchEvents.MapEndpoint(app);
    }
}
