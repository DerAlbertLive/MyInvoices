using System;

namespace Invoices.Core.Entities
{
    public abstract class EntityId<T> : IComparable<EntityId<T>>, IEquatable<EntityId<T>>
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

        public static T Zero => _zero;
        static T _zero = (T) Activator.CreateInstance(typeof(T), Guid.Empty);

        public static T New() => (T) Activator.CreateInstance(typeof(T), Guid.NewGuid());
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
