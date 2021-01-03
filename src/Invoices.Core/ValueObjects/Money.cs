using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public record Money (string Currency, decimal Amount)
    {
        public static Money None => new(string.Empty, 0.0m);
    }
}
