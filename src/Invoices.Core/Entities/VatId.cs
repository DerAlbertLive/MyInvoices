using System;

namespace Invoices.Core.Entities
{
    public class VatId : EntityId<VatId>
    {
        public VatId(Guid id) : base(id)
        {
        }
    }
}