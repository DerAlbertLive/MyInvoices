using System;

namespace Invoices.Core.Entities
{
    public interface IEntityChangedAt
    {
        DateTime CreatedAt { get; set; }
        DateTime ChangedAt { get; set; }
    }
}