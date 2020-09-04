using System;
using Invoices.Core.ValueObjects;
using JetBrains.Annotations;

namespace Invoices.Core.Entities
{
    public class Product : Entity<ProductId>
    {
        protected Product()
        {
            Description = ShortDescription.None;
            UnitOfQuantityId = UnitOfQuantityId.None;
            ProductTypeId = ProductTypeId.None;
        }

        public Product([NotNull] ShortDescription description, UnitOfQuantityId unitOfQuantityId, ProductTypeId productTypeId,
            bool inactive) : this()
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            UnitOfQuantityId = unitOfQuantityId;
            ProductTypeId = productTypeId;
            Inactive = inactive;
        }

        public ShortDescription Description { get; set; }
        public UnitOfQuantityId UnitOfQuantityId { get; set; }
        public ProductTypeId ProductTypeId { get; set; }

        public bool Inactive { get; set; }
    }
}
