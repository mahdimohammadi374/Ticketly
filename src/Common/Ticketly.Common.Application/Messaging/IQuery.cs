using MediatR;
using Ticketly.Common.Domain;

namespace Ticketly.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
