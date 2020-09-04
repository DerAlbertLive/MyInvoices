using System;

namespace Invoices.Core.Entities
{
    public class ProductTypeId : EntityId<ProductTypeId>
    {
        public ProductTypeId(Guid id) : base(id)
        {
        }
    }
}