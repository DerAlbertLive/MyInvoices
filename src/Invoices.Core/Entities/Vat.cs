namespace Invoices.Core.Entities
{
    public class Vat : Entity
    {
        public Vat()
        {
            Description = string.Empty;
        }

        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool Inactive { get; set; }
    }
}