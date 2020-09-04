using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class ProductType : Entity<ProductTypeId>
    {
        protected ProductType()
        {
            Description = ShortDescription.None;
        }

        public ProductType(ShortDescription description)
        {
            Description = description;
        }

        public ShortDescription Description { get; set; }
    }
}
