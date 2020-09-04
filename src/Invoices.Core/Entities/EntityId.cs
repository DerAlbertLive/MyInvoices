using System;

namespace Invoices.Core.Entities
{
    public abstract class EntityId<T> : IComparable<EntityId<T>>, IEquatable<EntityId<T>> where T : EntityId<T>
    {
        public Guid Id { get; }

        public EntityId(Guid id)
        {
            Id = id;
        }

        public EntityId()
        {
            Id = Guid.Empty;
        }

        public int CompareTo(EntityId<T> other)
        {
            return Id.CompareTo(other.Id);
        }

        public bool Equals(EntityId<T> other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is EntityId<T> entityId)
            {
                return Id.Equals(entityId.Id);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(EntityId<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityId<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public static T None => _none;
        static T _none = (T) Activator.CreateInstance(typeof(T), Guid.Empty);

        public static T New() => (T) Activator.CreateInstance(typeof(T), Guid.NewGuid());
    }
}
