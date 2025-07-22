using Npgsql;
using System.Data.Common;
using System.Threading.Tasks;
using Ticketly.Modules.Events.Application.Abstractions.Data;

namespace Ticketly.Modules.Events.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}
