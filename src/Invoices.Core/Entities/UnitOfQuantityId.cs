using System;

namespace Invoices.Core.Entities
{
    public record UnitOfQuantityId(Guid Id) : EntityId<UnitOfQuantityId>(Id);
}
