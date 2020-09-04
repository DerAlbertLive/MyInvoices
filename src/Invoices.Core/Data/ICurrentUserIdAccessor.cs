using Invoices.Core.Entities;

namespace Invoices.Core.Data
{
    public interface ICurrentUserIdAccessor
    {
        UserId UserId { get; set; }
    }
}
