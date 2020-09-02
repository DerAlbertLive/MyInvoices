namespace Invoices.Core.Entities
{
    public class Product : Entity
    {
        public Product()
        {
            Description = string.Empty;
        }

        public string Description { get; set; }
        public long UnitOfQuantityId { get; set; }
        public long ProductTypeId { get; set; }

        public bool Inactive { get; set; }
    }
}
