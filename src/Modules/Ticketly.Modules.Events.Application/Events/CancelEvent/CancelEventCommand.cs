using Ticketly.Common.Application.Messaging;

namespace Ticketly.Modules.Events.Application.Events.CancelEvent;

public sealed record CancelEventCommand(Guid EventId) : ICommand;
