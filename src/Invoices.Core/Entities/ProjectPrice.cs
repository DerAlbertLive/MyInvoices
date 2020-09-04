using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class ProjectPrice : Entity<ProjectPriceId>
    {
        protected ProjectPrice()
        {
            Price = Money.Empty();
            ProductPriceId = ProductPriceId.Zero;
            ProjectId = ProjectId.Zero;
        }

        public ProjectPrice(Money price, ProductPriceId productPriceId, ProjectId projectId, bool inactive) : this()
        {
            Price = price;
            ProductPriceId = productPriceId;
            ProjectId = projectId;
            Inactive = inactive;
        }

        public ProductPriceId ProductPriceId { get; set; }
        public ProjectId ProjectId { get; set; }

        public Money Price { get; set; }

        public bool Inactive { get; set; }
    }
}
