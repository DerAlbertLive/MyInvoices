using System;
using System.Reflection;

namespace Invoices.Core.Entities
{
    public abstract class Entity<T> : IEntity<T> where T : EntityId<T>
    {
        public T Id { get; }

        public UserId CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserId ChangedById { get; set; }
        public DateTime ChangedAt { get; set; }

        protected Entity()
        {
            Id = EntityId<T>.New();
            CreatedById = UserId.None;
            ChangedById = UserId.None;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Entity<T> other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id.Id == Guid.Empty || other.Id.Id == Guid.Empty)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), Id);
        }
    }
}
