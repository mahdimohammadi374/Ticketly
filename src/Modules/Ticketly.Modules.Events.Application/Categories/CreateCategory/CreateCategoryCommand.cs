using Ticketly.Common.Application.Messaging;

namespace Ticketly.Modules.Events.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : ICommand<Guid>;
