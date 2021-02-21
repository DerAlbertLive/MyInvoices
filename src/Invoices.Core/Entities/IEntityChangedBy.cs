namespace Invoices.Core.Entities
{
    public interface IEntityChangedBy
    {
        void Created(UserId userId);
        void Changed(UserId userId);
    }

    public interface IEntityChangedByIdentifier : IEntityChangedBy
    {
        UserId CreatedById { get; }
        UserId ChangedById { get; }
    }
}
