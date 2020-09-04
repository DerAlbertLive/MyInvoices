namespace Invoices.Core.Entities
{
    public interface IEntityChangedBy
    {
        UserId CreatedById { get; set; }
        UserId ChangedById { get; set; }
    }
}
