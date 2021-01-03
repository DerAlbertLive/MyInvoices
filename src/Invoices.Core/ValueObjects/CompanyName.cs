using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public record CompanyName (string Name1, string Name2)
    {
        public static CompanyName Empty => new(string.Empty, string.Empty);
    }
}
