﻿using System;

namespace Ticketly.Modules.Events.Application.Categories.GetCategory;

public sealed record CategoryResponse(Guid Id, string Name, bool IsArchived);
