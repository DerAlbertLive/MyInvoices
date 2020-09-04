using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public class Percent : ValueObject
    {
        public decimal Value { get; }

        public Percent(decimal value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static Percent None => new Percent(0.0m);

    }
}
