using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public class EMail : ValueObject
    {
        public string Value { get; }

        public EMail(string value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static EMail None => new EMail(string.Empty);
    }
}
