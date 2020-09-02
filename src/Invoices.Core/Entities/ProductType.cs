namespace Invoices.Core.Entities
{
    public class ProductType : Entity
    {
        public ProductType()
        {
            Description = string.Empty;
        }
        public string Description { get; set; }
    }
}
