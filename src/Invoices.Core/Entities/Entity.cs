using System;
using System.Reflection;

namespace Invoices.Core.Entities
{
    public abstract class Entity<T> : IEntity<T> where T : EntityId<T>
    {
        public T Id { get; }

        public UserId CreatedById { get;  set; }
        public DateTime CreatedAt { get; private set; }
        public UserId ChangedById { get;  set; }
        public DateTime ChangedAt { get; private set; }

        public void Created(UserId userId)
        {
            CreatedAt = DateTime.UtcNow;
            ChangedAt = CreatedAt;
            CreatedById = userId;
            ChangedById = userId;
        }

        public void Changed(UserId userId)
        {
            ChangedAt = DateTime.UtcNow;
            ChangedById = userId;
        }

        protected Entity()
        {
            Id = EntityId<T>.New();
            CreatedById = UserId.None;
            ChangedById = UserId.None;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity<T> other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id.Id == Guid.Empty || other.Id.Id == Guid.Empty)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            if (left is null || right is null)
                return false;

            return left.Equals(right);
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
