using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class ProjectPrice : Entity
    {
        protected ProjectPrice()
        {
            Price = Money.Empty();
        }

        public ProjectPrice(Money price, long productPriceId, long projectId, bool inactive) : this()
        {
            Price = price;
            ProductPriceId = productPriceId;
            ProjectId = projectId;
            Inactive = inactive;
        }

        public long ProductPriceId { get; set; }
        public long ProjectId { get; set; }

        public Money Price { get; set; }

        public bool Inactive { get; set; }
    }
}
