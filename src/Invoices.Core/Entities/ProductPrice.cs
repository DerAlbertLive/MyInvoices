using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class ProductPrice : Entity<ProductPriceId>
    {
        protected ProductPrice()
        {
            Description = ShortDescription.Empty();
            Price = Money.Empty();
            VatId = VatId.Zero;
            ProductId = ProductId.Zero;
        }

        public ProductPrice(ShortDescription description, Money price, VatId vatId, ProductId productId,
            bool inactive) : this()
        {
            Description = description;
            Price = price;
            VatId = vatId;
            ProductId = productId;
            Inactive = inactive;
        }

        public ShortDescription Description { get; set; }
        public Money Price { get; set; }
        public VatId VatId { get; set; }
        public ProductId ProductId { get; set; }
        public bool Inactive { get; set; }
    }
}
