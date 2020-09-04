using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Invoices.Core.Entities
{
    public class EntityIdValueComparer<T> : ValueComparer<T>
        where T : EntityId<T>
    {
        public EntityIdValueComparer() : base((l, r) => l.Equals(r), id => id.GetHashCode())
        {
        }
    }
}