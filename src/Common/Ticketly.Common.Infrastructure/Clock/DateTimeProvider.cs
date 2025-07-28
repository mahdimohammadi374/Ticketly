using System;

using Ticketly.Common.Application.Clock;

namespace Ticketly.Common.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
