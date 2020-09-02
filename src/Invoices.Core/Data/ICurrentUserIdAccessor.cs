namespace Invoices.Core.Data
{
    public interface ICurrentUserIdAccessor
    {
        int UserId { get; set; }
    }
}
