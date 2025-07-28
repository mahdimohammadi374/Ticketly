using Ticketly.Common.Application.Messaging;

namespace Ticketly.Modules.Events.Application.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(Guid CategoryId, string Name) : ICommand;
