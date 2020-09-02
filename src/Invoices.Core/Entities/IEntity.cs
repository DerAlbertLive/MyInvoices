namespace Invoices.Core.Entities
{
    public interface IEntity : IEntityChangedBy, IEntityChangedAt
    {
        public long Id { get; }
    }
}
