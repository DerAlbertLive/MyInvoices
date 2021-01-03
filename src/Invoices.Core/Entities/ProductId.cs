using System;

namespace Invoices.Core.Entities
{
    public record ProductId(Guid Id) : EntityId<ProductId>(Id);
}
