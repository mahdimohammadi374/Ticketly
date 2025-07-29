using Ticketly.Common.Domain;
namespace Ticketly.Common.Application.Exceptions;

public sealed class TicketlyException : Exception
{
    public TicketlyException(string requestName, Error error , Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }
    public TicketlyException(string requestName,  Exception? innerException = default)
    : base("Application exception", innerException)
    {
        RequestName = requestName;
    }
    public string RequestName { get; }

    public Error Error { get; }
}
