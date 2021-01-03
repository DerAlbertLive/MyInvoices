using System;

namespace Invoices.Core.Entities
{
    public record ProductTypeId(Guid Id) : EntityId<ProductTypeId>(Id);
}
