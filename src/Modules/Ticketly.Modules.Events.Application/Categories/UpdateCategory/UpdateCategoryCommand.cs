using System;
using Ticketly.Modules.Events.Application.Abstractions.Messaging;

namespace Ticketly.Modules.Events.Application.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(Guid CategoryId, string Name) : ICommand;
