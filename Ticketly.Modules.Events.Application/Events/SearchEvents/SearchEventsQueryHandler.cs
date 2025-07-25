﻿using System.Data.Common;
using Dapper;
using Ticketly.Modules.Events.Application.Abstractions.Data;
using Ticketly.Modules.Events.Domain.Abstractions;
using Ticketly.Modules.Events.Domain.Events;
using Ticketly.Modules.Events.Application.Abstractions.Messaging;
using Ticketly.Modules.Events.Application.Events.GetEvents;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System;

namespace Ticketly.Modules.Events.Application.Events.SearchEvents;

internal sealed class SearchEventsQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<SearchEventsQuery, SearchEventsResponse>
{

    public async Task<Result<SearchEventsResponse>> Handle(
        SearchEventsQuery request,
        CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        var parameters = new SearchEventsParameters(
            (int)EventStatus.Published,
            request.CategoryId,
            request.StartDate?.Date,
            request.EndDate?.Date,
            request.PageSize,
            (request.Page - 1) * request.PageSize);

        IReadOnlyCollection<EventResponse> events = await GetEventsAsync(connection, parameters);

        int totalCount = await CountEventsAsync(connection, parameters);

        return new SearchEventsResponse(request.Page, request.PageSize, totalCount, events);
    }

    private static async Task<IReadOnlyCollection<EventResponse>> GetEventsAsync(
        DbConnection connection,
        SearchEventsParameters parameters)
    {
        const string sql =
            $"""
             SELECT
                 id AS {nameof(EventResponse.Id)},
                 category_id AS {nameof(EventResponse.CategoryId)},
                 title AS {nameof(EventResponse.Title)},
                 description AS {nameof(EventResponse.Description)},
                 location AS {nameof(EventResponse.Location)},
                 starts_at_utc AS {nameof(EventResponse.StartsAtUtc)},
                 ends_at_utc AS {nameof(EventResponse.EndsAtUtc)}
             FROM events.events
             WHERE
                status = @Status AND
                (@CategoryId IS NULL OR category_id = @CategoryId) AND
                (@StartDate::timestamp IS NULL OR starts_at_utc >= @StartDate::timestamp) AND
                (@EndDate::timestamp IS NULL OR ends_at_utc >= @EndDate::timestamp)
             ORDER BY starts_at_utc
             OFFSET @Skip
             LIMIT @Take
             """;

        List<EventResponse> events = (await connection.QueryAsync<EventResponse>(sql, parameters)).AsList();

        return events;
    }

    private static async Task<int> CountEventsAsync(DbConnection connection, SearchEventsParameters parameters)
    {
        const string sql =
            """
            SELECT COUNT(*)
            FROM events.events
            WHERE
               status = @Status AND
               (@CategoryId IS NULL OR category_id = @CategoryId) AND
               (@StartDate::timestamp IS NULL OR starts_at_utc >= @StartDate::timestamp) AND
               (@EndDate::timestamp IS NULL OR ends_at_utc >= @EndDate::timestamp)
            """;

        int totalCount = await connection.ExecuteScalarAsync<int>(sql, parameters);

        return totalCount;
    }

    private sealed record SearchEventsParameters(
        int Status,
        Guid? CategoryId,
        DateTime? StartDate,
        DateTime? EndDate,
        int Take,
        int Skip);
}
