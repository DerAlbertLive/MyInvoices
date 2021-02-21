using System;
using FluentAssertions;
using Invoices.Core.ValueObjects;
using Xunit;

namespace Invoices.Core.Tests.ValueObjects
{
    public class MoneyAddingTests
    {
        [Fact]
        public void Money_with_different_currency_should_throw_on_add()
        {
            var val1 = new Money(Currencies.UsDollar, 1.5m);
            var val2 = new Money(Currencies.Euro, 2.5m);

            Func<Money> action = () => val2 + val1;

            action.Should().Throw<NotMatchingCurrencyException>();

            action = () => val2 - val1;

            action.Should().Throw<NotMatchingCurrencyException>();

            action = () => val2 * val1;

            action.Should().Throw<NotMatchingCurrencyException>();

            action = () => val2 / val1;

            action.Should().Throw<NotMatchingCurrencyException>();

        }

        [Fact]
        public void Money_with_same_currency_add_values()
        {
            var val1 = new Money(Currencies.Euro, 1.5m);
            var val2 = new Money(Currencies.Euro, 2.5m);

            var result = val2 + val1;

            result.Amount.Should().Be(4.0m);
        }

        [Fact]
        public void Money_with_same_currency_sub_values()
        {
            var val1 = new Money(Currencies.Euro, 1.5m);
            var val2 = new Money(Currencies.Euro, 2.5m);

            var result = val1 - val2;

            result.Amount.Should().Be(-1.0m);
        }

        [Fact]
        public void Money_with_same_currency_multiply_values()
        {
            var val1 = new Money(Currencies.Euro, 1.5m);
            var val2 = new Money(Currencies.Euro, 2.5m);

            var result = val1 * val2;

            result.Amount.Should().Be(3.75m);
        }

        [Fact]
        public void Money_with_same_currency_divide_values()
        {
            var val1 = new Money(Currencies.Euro, 1.5m);
            var val2 = new Money(Currencies.Euro, 2.5m);

            var result = val1 / val2;

            result.Amount.Should().Be(0.6m);
        }
    }
}
