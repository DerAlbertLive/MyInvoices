using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public record ShortDescription(string Value)
    {
        public static ShortDescription None => new(string.Empty);
    }
}
