using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class UnitOfQuantity : Entity<UnitOfQuantityId>
    {
        protected UnitOfQuantity()
        {
            Description = ShortDescription.None;
            IsoCode = string.Empty;
            Short = string.Empty;
        }

        public UnitOfQuantity(string isoCode, string @short, ShortDescription description) : this()
        {
            IsoCode = isoCode;
            Short = @short;
            Description = description;
        }

        public string IsoCode { get; set; }
        public string Short { get; set; }

        public ShortDescription Description { get; set; }
    }
}
