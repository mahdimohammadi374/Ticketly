using System;
using Ticketly.Modules.Events.Domain.Abstractions;

namespace Ticketly.Modules.Events.Application.Abstractions.Exceptions;

public sealed class TicketlyException : Exception
{
    public TicketlyException(string requestName, Error error , Exception innerException )
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public Error Error { get; }
}
