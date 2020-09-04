using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public class Money : ValueObject
    {
        public string Currency { get; }
        public decimal Amount { get; }

        public Money(string currency, decimal amount)
        {
            Currency = currency.ToUpperInvariant();
            Amount = amount;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Currency;
            yield return Amount;
        }

        public static Money None => new Money(string.Empty, 0.0m);
    }
}
