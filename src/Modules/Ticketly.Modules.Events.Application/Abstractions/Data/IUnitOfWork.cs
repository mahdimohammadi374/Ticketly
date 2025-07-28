using System.Threading;
using System.Threading.Tasks;

namespace Ticketly.Modules.Events.Application.Abstractions.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
