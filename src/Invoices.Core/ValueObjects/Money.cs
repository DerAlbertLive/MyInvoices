using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public record Money (Currency Currency, decimal Amount)
    {
        public static Money None => new(Currency.None, 0.0m);

        public static Money operator +(Money left, Money right)
        {
            EnsureSameCurrency(left, right);
            return left with
            {
                Amount = left.Amount + right.Amount
            };
        }

        public static Money operator -(Money left, Money right)
        {
            EnsureSameCurrency(left, right);
            return left with
            {
                Amount = left.Amount - right.Amount
            };
        }

        public static Money operator *(Money left, Money right)
        {
            EnsureSameCurrency(left, right);
            return left with
            {
                Amount = left.Amount * right.Amount
            };
        }

        public static Money operator /(Money left, Money right)
        {
            EnsureSameCurrency(left, right);
            return left with
            {
                Amount = left.Amount / right.Amount
            };
        }

        private static void EnsureSameCurrency(Money left, Money right)
        {
            if (left.Currency != right.Currency)
            {
                throw new NotMatchingCurrencyException();
            }
        }
    }
}
