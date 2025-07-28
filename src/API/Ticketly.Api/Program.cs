using Ticketly.Api.Extensions;
using Ticketly.Modules.Events.Infrastructure;
using Ticketly.Common.Application;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddApplication([Ticketly.Modules.Events.Application.AssemblyReference.Assembly]);
builder.Services.AddEventsModule(builder.Configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.ApplyMigration();
}

EventsModule.MapEndpoints(app);

await app.RunAsync();
