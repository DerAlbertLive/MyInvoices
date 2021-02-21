using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class UnitOfQuantity : Entity<UnitOfQuantityId>
    {
        protected UnitOfQuantity()
        {
            Designation = Designation.None;
            IsoCode = string.Empty;
            Abbreviation = string.Empty;
        }

        public UnitOfQuantity(string isoCode, string abbreviation, Designation designation) : this()
        {
            IsoCode = isoCode;
            Abbreviation = abbreviation;
            Designation = designation;
        }

        public string IsoCode { get; set; }
        public string Abbreviation { get; set; }

        public Designation Designation { get; set; }
    }
}
