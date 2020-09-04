using System;

namespace Invoices.Core.Entities
{
    public class ProductId : EntityId<ProductId>
    {
        public ProductId(Guid id) : base(id)
        {
        }
    }
}