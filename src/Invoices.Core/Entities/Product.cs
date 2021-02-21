using System;
using Invoices.Core.ValueObjects;
using JetBrains.Annotations;

namespace Invoices.Core.Entities
{
    public class Product : Entity<ProductId>
    {
        protected Product()
        {
            Designation = Designation.None;
            UnitOfQuantityId = UnitOfQuantityId.None;
            ProductTypeId = ProductTypeId.None;
            Inactive = false;
        }

        public Product([NotNull] Designation description, UnitOfQuantityId unitOfQuantityId, ProductTypeId productTypeId,
            bool inactive) : this()
        {
            Designation = description ?? throw new ArgumentNullException(nameof(description));
            UnitOfQuantityId = unitOfQuantityId;
            ProductTypeId = productTypeId;
            Inactive = inactive;
        }

        public Designation Designation { get; set; }
        public UnitOfQuantityId UnitOfQuantityId { get; set; }
        public ProductTypeId ProductTypeId { get; set; }

        public bool Inactive { get; set; }
    }
}
