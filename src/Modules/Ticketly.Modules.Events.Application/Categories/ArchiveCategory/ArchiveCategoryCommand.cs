using Ticketly.Common.Application.Messaging;

namespace Ticketly.Modules.Events.Application.Categories.ArchiveCategory;

public sealed record ArchiveCategoryCommand(Guid CategoryId) : ICommand;
