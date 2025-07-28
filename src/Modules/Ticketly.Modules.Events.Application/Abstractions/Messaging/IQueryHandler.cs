using Ticketly.Modules.Events.Domain.Abstractions;
using MediatR;

namespace Ticketly.Modules.Events.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
