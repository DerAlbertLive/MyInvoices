using System;

namespace Invoices.Core.Entities
{
    public record VatId(Guid Id) : EntityId<VatId>(Id);
}
