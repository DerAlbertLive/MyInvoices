using System;

namespace Invoices.Core.Entities
{
    public record CustomerId(Guid Id) : EntityId<CustomerId>(Id);
}
