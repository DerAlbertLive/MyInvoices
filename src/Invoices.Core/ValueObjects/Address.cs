namespace Invoices.Core.ValueObjects
{
    public record Address(string Street, string City, string ZipCode)
    {
        public static Address None => new(string.Empty, string.Empty, string.Empty);
    }
}
