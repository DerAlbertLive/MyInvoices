using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public record EMail(string Value)
    {
        public static EMail None => new(string.Empty);
    }
}
