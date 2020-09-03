using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class ProductType : Entity
    {
        protected ProductType()
        {
            Description = ShortDescription.Empty();
        }

        public ProductType(ShortDescription description)
        {
            Description = description;
        }

        public ShortDescription Description { get; set; }
    }
}
