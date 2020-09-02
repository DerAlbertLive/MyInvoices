namespace Invoices.Core.Entities
{
    public class ProjectRate : Entity
    {
        public long ProductRateId { get; set; }
        public long ProjectId { get; set; }
        public decimal Rate { get; set; }
        public bool Inactive { get; set; }
    }

}
