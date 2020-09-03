using System;
using Invoices.Core.ValueObjects;
using JetBrains.Annotations;

namespace Invoices.Core.Entities
{
    public class Product : Entity
    {
        protected Product()
        {
            Description = ShortDescription.Empty();
        }

        public Product([NotNull] ShortDescription description, long unitOfQuantityId, long productTypeId,
            bool inactive) : this()
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            UnitOfQuantityId = unitOfQuantityId;
            ProductTypeId = productTypeId;
            Inactive = inactive;
        }

        public ShortDescription Description { get; set; }
        public long UnitOfQuantityId { get; set; }
        public long ProductTypeId { get; set; }

        public bool Inactive { get; set; }
    }
}
