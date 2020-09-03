using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public class ShortDescription : ValueObject
    {
        public string Value { get; }

        public ShortDescription(string value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static ShortDescription Empty() => _empty;
        static ShortDescription _empty = new ShortDescription(string.Empty);
    }
}
