using System;

namespace Invoices.Core.Entities
{
    public class CustomerId : EntityId<CustomerId>
    {
        public CustomerId(Guid id) : base(id)
        {
        }
    }
}