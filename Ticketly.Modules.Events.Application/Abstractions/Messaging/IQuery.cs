using Ticketly.Modules.Events.Domain.Abstractions;
using MediatR;

namespace Ticketly.Modules.Events.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
