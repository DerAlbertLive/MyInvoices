namespace Invoices.Core.ValueObjects
{
    public record Currency (string Code)
    {
        public static Currency None => new(string.Empty);
    }
}
