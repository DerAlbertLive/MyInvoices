using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

        public static T Zero => _zero;
        static T _zero = (T) Activator.CreateInstance(typeof(T), Guid.Empty);

        public static T New() => (T) Activator.CreateInstance(typeof(T), Guid.NewGuid());
    }

    public class EntityIdValueComparer<T> : ValueComparer<T>
        where T : EntityId<T>
    {
        public EntityIdValueComparer() : base((l, r) => l.Equals(r), id => id.GetHashCode())
        {
        }
    }

    public class EntityIdValueConversion<T> : ValueConverter<T, Guid> where T : EntityId<T>
    {
        public EntityIdValueConversion() : base(id => id.Id, guid => (T) Activator.CreateInstance(typeof(T), guid))
        {
        }
    }

    public class VatId : EntityId<VatId>
    {
        public VatId(Guid id) : base(id)
        {
        }
    }

    public class CustomerId : EntityId<CustomerId>
    {
        public CustomerId(Guid id) : base(id)
        {
        }
    }

    public class ProductId : EntityId<ProductId>
    {
        public ProductId(Guid id) : base(id)
        {
        }
    }

    public class ProductPriceId : EntityId<ProductPriceId>
    {
        public ProductPriceId(Guid id) : base(id)
        {
        }
    }

    public class ProjectId : EntityId<ProjectId>
    {
        public ProjectId(Guid id) : base(id)
        {
        }
    }

    public class ProductTypeId : EntityId<ProductTypeId>
    {
        public ProductTypeId(Guid id) : base(id)
        {
        }
    }

    public class ProjectPriceId : EntityId<ProjectPriceId>
    {
        public ProjectPriceId(Guid id) : base(id)
        {
        }
    }

    public class UnitOfQuantityId : EntityId<UnitOfQuantityId>
    {
        public UnitOfQuantityId(Guid id) : base(id)
        {
        }
    }

    public class UserId : EntityId<UserId>
    {
        public UserId(Guid id) : base(id)
        {
        }
    }
}
