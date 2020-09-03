using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class ProductPrice : Entity
    {
        protected ProductPrice()
        {
        }

        public ProductPrice(ShortDescription description, Money price, long vatId, long productId,
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
        public long VatId { get; set; }
        public long ProductId { get; set; }
        public bool Inactive { get; set; }
    }
}
