using Ticketly.Common.Application.Messaging;
using Ticketly.Modules.Events.Application.Categories.GetCategory;

namespace Ticketly.Modules.Events.Application.Categories.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<CategoryResponse>>;
