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

        public ProductPriceId ProductPriceId { get; set; }
        public ProjectId ProjectId { get; set; }
        public Money Price { get; set; }
        public bool Inactive { get; set; }
    }
}
