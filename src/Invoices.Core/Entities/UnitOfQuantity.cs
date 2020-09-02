namespace Invoices.Core.Entities
{
    public class UnitOfQuantity : Entity
    {
        public UnitOfQuantity()
        {
            IsoCode = string.Empty;
            Short = string.Empty;
            Description = string.Empty;
        }
        public string IsoCode { get; set; }
        public string Short { get; set; }

        public string Description { get; set; }
    }
}
