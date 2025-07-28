using Ticketly.Common.Application.Messaging;

namespace Ticketly.Modules.Events.Application.Categories.GetCategory;

public sealed record GetCategoryQuery(Guid CategoryId) : IQuery<CategoryResponse>;
