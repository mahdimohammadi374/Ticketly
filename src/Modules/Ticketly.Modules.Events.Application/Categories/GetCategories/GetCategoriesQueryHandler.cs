using System.Data.Common;
using Dapper;
using Ticketly.Modules.Events.Application.Abstractions.Data;
using Ticketly.Modules.Events.Domain.Abstractions;
using Ticketly.Modules.Events.Application.Categories.GetCategory;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Ticketly.Modules.Events.Application.Abstractions.Messaging;

namespace Ticketly.Modules.Events.Application.Categories.GetCategories;

internal sealed class GetCategoriesQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetCategoriesQuery, IReadOnlyCollection<CategoryResponse>>
{
    public async Task<Result<IReadOnlyCollection<CategoryResponse>>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
             SELECT
                 id AS {nameof(CategoryResponse.Id)},
                 name AS {nameof(CategoryResponse.Name)},
                 is_archived AS {nameof(CategoryResponse.IsArchived)}
             FROM events.categories
             """;

        List<CategoryResponse> categories = (await connection.QueryAsync<CategoryResponse>(sql, request)).AsList();

        return categories;
    }
}
