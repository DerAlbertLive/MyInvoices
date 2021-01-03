using System;

namespace Invoices.Core.Entities
{
    public record ProjectPriceId(Guid Id) : EntityId<ProjectPriceId>(Id);
}
