using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class Vat : Entity<VatId>
    {
        protected Vat()
        {
            Percent = Percent.None;
            Designation = Designation.None;
            Inactive = false;
        }

        public Vat(Percent percent, Designation designation) : this()
        {
            Percent = percent;
            Designation = designation;
        }

        public Designation Designation { get; private set; }
        public Percent Percent { get; set; }
        public bool Inactive { get; set; }

        public void ChangeDescription(Designation designation)
        {
            Designation = designation;
        }
    }
}
