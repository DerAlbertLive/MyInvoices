using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class ProductType : Entity<ProductTypeId>
    {
        protected ProductType()
        {
            Designation = Designation.None;
        }

        public ProductType(Designation designation)
        {
            Designation = designation;
        }

        public Designation Designation { get; set; }
    }
}
