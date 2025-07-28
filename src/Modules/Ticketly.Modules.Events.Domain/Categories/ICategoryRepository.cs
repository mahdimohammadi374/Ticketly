using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ticketly.Modules.Events.Domain.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Category category);
}
