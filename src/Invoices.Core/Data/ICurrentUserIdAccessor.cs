namespace Invoices.Core.Data
{
    public interface ICurrentUserIdAccessor
    {
        long UserId { get; set; }
    }
}
