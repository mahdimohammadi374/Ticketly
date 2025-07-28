using System;
using Ticketly.Modules.Events.Application.Abstractions.Messaging;

namespace Ticketly.Modules.Events.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : ICommand<Guid>;
