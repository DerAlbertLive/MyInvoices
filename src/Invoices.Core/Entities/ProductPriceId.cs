using System;

namespace Invoices.Core.Entities
{
    public record ProductPriceId(Guid Id) : EntityId<ProductPriceId>(Id);
}
