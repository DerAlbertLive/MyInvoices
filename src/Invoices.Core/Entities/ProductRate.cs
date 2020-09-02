
namespace Invoices.Core.Entities
{
    public class ProductRate : Entity
    {
        public ProductRate()
        {
            Description = string.Empty;
        }

        public string Description { get; set; }
        public decimal Rate { get; set; }
        public long VatId { get; set; }
        public long ProductId { get; set; }
        public bool Inactive { get; set; }
    }
}
