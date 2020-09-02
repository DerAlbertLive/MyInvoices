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

        public static EMail Empty()
        {
            return new EMail(string.Empty);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
