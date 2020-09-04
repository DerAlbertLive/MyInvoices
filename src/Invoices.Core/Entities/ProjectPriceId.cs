using System;

namespace Invoices.Core.Entities
{
    public class ProjectPriceId : EntityId<ProjectPriceId>
    {
        public ProjectPriceId(Guid id) : base(id)
        {
        }
    }
}