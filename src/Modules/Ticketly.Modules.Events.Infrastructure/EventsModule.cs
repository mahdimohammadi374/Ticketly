using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using Ticketly.Modules.Events.Application.Abstractions.Clock;
using Ticketly.Modules.Events.Application.Abstractions.Data;
using Ticketly.Modules.Events.Domain.Categories;
using Ticketly.Modules.Events.Domain.Events;
using Ticketly.Modules.Events.Domain.TicketTypes;
using Ticketly.Modules.Events.Infrastructure.Categories;
using Ticketly.Modules.Events.Infrastructure.Clock;
using Ticketly.Modules.Events.Infrastructure.Data;
using Ticketly.Modules.Events.Infrastructure.Database;
using Ticketly.Modules.Events.Infrastructure.Events;
using Ticketly.Modules.Events.Infrastructure.TicketTypes;
using Ticketly.Modules.Events.Presentation.Categories;
using Ticketly.Modules.Events.Presentation.Events;
using Ticketly.Modules.Events.Presentation.TicketTypes;

namespace Ticketly.Modules.Events.Infrastructure;
public static class EventsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        TicketTypeEndpoints.MapEndpoints(app);
        CategoryEndpoints.MapEndpoints(app);
        EventEndpoints.MapEndPoints(app);
    }

    public static IServiceCollection AddEventsModule(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        services.AddInfrastructure(configuration);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        
        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddDbContext<EventsDbContext>(opt =>
        opt
        .UseNpgsql(
            databaseConnectionString,
            npgsqlOptions => npgsqlOptions
            .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events))
        .UseSnakeCaseNamingConvention());
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbContext>());

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }

}
