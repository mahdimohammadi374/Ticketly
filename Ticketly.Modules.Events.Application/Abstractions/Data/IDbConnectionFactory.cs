using System.Data.Common;
using System.Threading.Tasks;

namespace Ticketly.Modules.Events.Application.Abstractions.Data;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
