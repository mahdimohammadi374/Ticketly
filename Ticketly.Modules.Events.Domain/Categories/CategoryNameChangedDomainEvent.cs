﻿
using System;
using Ticketly.Modules.Events.Domain.Abstractions;

namespace Ticketly.Modules.Events.Domain.Categories;

public sealed class CategoryNameChangedDomainEvent(Guid categoryId, string name) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;

    public string Name { get; init;  } = name;
}
