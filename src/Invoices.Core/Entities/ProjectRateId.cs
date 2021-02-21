using System;

namespace Invoices.Core.Entities
{
    public record ProjectRateId(Guid Id) : EntityId<ProjectRateId>(Id);
}
