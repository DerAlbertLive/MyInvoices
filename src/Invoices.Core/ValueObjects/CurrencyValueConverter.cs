using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Invoices.Core.ValueObjects
{
    public class CurrencyValueConverter : ValueConverter<Currency, string>
    {
        public CurrencyValueConverter() : base(currency => currency.Code, currency => new Currency(currency))
        {
        }
    }
}
