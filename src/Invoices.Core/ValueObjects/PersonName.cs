namespace Invoices.Core.ValueObjects
{
    public record PersonName(string Given, string Middle, string Family)
    {
        public static PersonName None => new(string.Empty, string.Empty, string.Empty);
    }
}
