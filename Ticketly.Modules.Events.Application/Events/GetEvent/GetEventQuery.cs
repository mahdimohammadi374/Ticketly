using MediatR;
using System;
using Ticketly.Modules.Events.Application.Abstractions.Messaging;

namespace Ticketly.Modules.Events.Application.Events.GetEvent;
public sealed record GetEventQuery(Guid EventId) : IQuery<EventResponse>;
