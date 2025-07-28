using Ticketly.Common.Application.Messaging;

namespace Ticketly.Modules.Events.Application.Events.PublishEvent;

public sealed record PublishEventCommand(Guid EventId) : ICommand;
