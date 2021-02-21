using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class ProjectRate : Entity<ProjectRateId>
    {
        protected ProjectRate()
        {
            Price = Money.None;
            ProductPriceId = ProductPriceId.None;
            ProjectId = ProjectId.None;
        }

        public ProjectRate(Money price, ProductPriceId productPriceId, ProjectId projectId, bool inactive) : this()
        {
            Price = price;
            ProductPriceId = productPriceId;
            ProjectId = projectId;
            Inactive = inactive;
        }

        public ProductPriceId ProductPriceId { get; }
        public ProjectId ProjectId { get; }
        public Money Price { get; private set; }
        public bool Inactive { get; }
    }
}
