using System;

namespace Invoices.Core.Entities
{
    public class UserId : EntityId<UserId>
    {
        public UserId(Guid id) : base(id)
        {
        }
    }
}