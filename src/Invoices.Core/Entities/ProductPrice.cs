using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class ProductPrice : Entity<ProductPriceId>
    {
        protected ProductPrice()
        {
            Price = Money.None;
            VatId = VatId.None;
            ProductId = ProductId.None;
        }

        public ProductPrice(Money price, VatId vatId, ProductId productId,
            bool inactive) : this()
        {
            Price = price;
            VatId = vatId;
            ProductId = productId;
            Inactive = inactive;
        }

        public Money Price { get; set; }
        public VatId VatId { get; set; }
        public ProductId ProductId { get; set; }
        public bool Inactive { get; set; }
    }
}
