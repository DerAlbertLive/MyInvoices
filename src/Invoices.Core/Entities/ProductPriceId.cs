using System;

namespace Invoices.Core.Entities
{
    public class ProductPriceId : EntityId<ProductPriceId>
    {
        public ProductPriceId(Guid id) : base(id)
        {
        }
    }
}