using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class Vat : Entity<VatId>
    {
        protected Vat()
        {
            Percent = Percent.Empty();
            Description = ShortDescription.Empty();
        }

        public Vat(Percent percent, ShortDescription description) : this()
        {
            Percent = percent;
            Description = description;
        }

        public ShortDescription Description { get; set; }

        public Percent Percent { get; set; }
        public bool Inactive { get; set; }

        public void ChangeDescription(ShortDescription shortDescription)
        {
            Description = shortDescription;
        }
    }
}
