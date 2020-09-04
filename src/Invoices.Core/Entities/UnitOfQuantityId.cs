using System;

namespace Invoices.Core.Entities
{
    public class UnitOfQuantityId : EntityId<UnitOfQuantityId>
    {
        public UnitOfQuantityId(Guid id) : base(id)
        {
        }
    }
}