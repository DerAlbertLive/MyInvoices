namespace Invoices.Core.Entities
{
    public interface IEntityChangedBy
    {
        long CreatedById { get; set; }
        long ChangedById { get; set; }
    }
}