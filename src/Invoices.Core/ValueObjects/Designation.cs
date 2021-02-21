using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public record Designation(string Value)
    {
        public static Designation None => new(string.Empty);
    }
}
