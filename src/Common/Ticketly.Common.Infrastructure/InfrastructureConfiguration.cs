using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Npgsql;

using StackExchange.Redis;

using Ticketly.Common.Application.Caching;
using Ticketly.Common.Application.Clock;
using Ticketly.Common.Application.Data;
using Ticketly.Common.Infrastructure.Caching;
using Ticketly.Common.Infrastructure.Clock;
using Ticketly.Common.Infrastructure.Data;

namespace Ticketly.Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        string databaseConnectionString, 
        string redisConnectionString)
    {
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
        services.TryAddSingleton(connectionMultiplexer);

        services.AddStackExchangeRedisCache(option =>
        option.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
        
        services.TryAddSingleton<ICacheService, CacheService>();

        return services;
    }
}
