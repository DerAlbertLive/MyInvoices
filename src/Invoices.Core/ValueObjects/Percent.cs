using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public record Percent(decimal Value)
    {
        public static Percent None => new(0.0m);
    }
}
