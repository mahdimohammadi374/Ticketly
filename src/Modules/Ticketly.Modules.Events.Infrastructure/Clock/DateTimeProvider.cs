using System;
using Ticketly.Modules.Events.Application.Abstractions.Clock;

namespace Ticketly.Modules.Events.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
