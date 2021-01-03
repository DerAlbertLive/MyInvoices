using System;

namespace Invoices.Core.Entities
{
    public record UserId(Guid Id) : EntityId<UserId>(Id);
}
