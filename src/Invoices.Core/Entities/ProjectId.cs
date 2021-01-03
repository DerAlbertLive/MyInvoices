using System;

namespace Invoices.Core.Entities
{
    public record ProjectId(Guid Id) : EntityId<ProjectId>(Id);
}
